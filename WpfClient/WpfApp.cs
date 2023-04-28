using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatLibrary;
using System;
using System.Windows;

namespace WpfClient
{
  public class WpfApp
  {
    string clientId;
    UserModel person;
    ChatCore<UserModel> chat;
    IStorage<UserModel> storage;
    public IStorage<UserModel> Storage => storage;
    Window window;
    public WpfApp(Window w)
    {
      clientId = Guid.NewGuid().ToString()[..5];
      window = w;
    }
    private void UserInit()
    {
      person = new()
      {
        Username = $"user {clientId}"
      };
    }

    private void UIConfig()
    {
      window.Title = $"[{clientId}] chat";
    }
    private void AppConfig()
    {
      storage = new Storage<UserModel>();
      string url = "https://localhost:5001/notify"; ;
      chat = new(url, storage, new DebugUI());
      chat.StartReceive();
    }
    public void Start()
    {
      UserInit();
      UIConfig();
      AppConfig();
    }

    public void Send(string tm)
    {
      person.TextMessage = tm;
      chat.ClientSendMessage(person);
    }
  }
}