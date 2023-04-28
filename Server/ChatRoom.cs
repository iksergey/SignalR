using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

public class ChatRoom<T> : Hub
    where T : class, IModel
{
  public Task Send(T msg) => Clients.Others.SendAsync("ChatRoom", msg);
}