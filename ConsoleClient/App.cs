using static System.Console;
using ChatLibrary;

namespace ConsoleClient
{
  public class App
  {
    private string clientId;
    private ConsoleUserModel person;
    private ChatCore<ConsoleUserModel> chat;
    private IStorage<ConsoleUserModel> storage;
    public App()
    {
      clientId = Guid.NewGuid().ToString()[..5];
    }

    private ConsoleColor CustomColor()
    {
      var consoleColors = Enum.GetValues(typeof(ConsoleColor));
      return (ConsoleColor)consoleColors.GetValue(new Random().Next(1, consoleColors.Length));
    }

    private void UserInit()
    {
      person = new() { Username = $"user {clientId}" };
      person.Color = CustomColor();
    }

    private void UIConfig()
    {
      Title = $"[{clientId}] chat";
      ForegroundColor = person.Color;
      WriteLine($"username: {person.Username}");
      ForegroundColor = ConsoleColor.Gray;
    }

    private void AppConfig()
    {
      storage = new Storage<ConsoleUserModel>();
      string host = "https://localhost:5001/notify";
      var ui = new ConsoleUI();
      chat = new(host, storage, ui);
      chat.StartReceive();
    }

    public void Start()
    {
      UserInit();
      UIConfig();
      AppConfig();

      while (true)
      {
        string text = ReadLine()!;

        switch (text)
        {
          case "exit": return;
          case "log":
            WriteLine();
            foreach (var m in storage.Read()) WriteLine(m);
            break;
          default:
            person.TextMessage = text;
            chat.ClientSendMessage(person);
            break;
        }
      }
    }
  }
}