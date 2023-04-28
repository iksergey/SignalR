using ChatLibrary;
using Microsoft.AspNetCore.SignalR.Client;

public class ChatCore<T> : IChat<T>
    where T : IModel, new()
{
  private IStorage<T> storage;
  private IUserInterface ui;
  private HubConnection connection;
  public ChatCore(string url, IStorage<T> storage, IUserInterface ui)
  {
    connection = new HubConnectionBuilder()
        .WithUrl(url)
        .Build();
    this.ui = ui;
    this.storage = storage;
  }

  public async void ClientSendMessage(T model)
  {
    storage.Append(model);
    await connection.SendAsync("Send", model);
  }

  public async void StartReceive()
  {
    connection.On<T>("ChatRoom", user =>
    {
      ui.Print(user);
      storage.Append(user);
    });
    await connection.StartAsync();
  }
}