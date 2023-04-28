public interface IChat<T>
{
  void ClientSendMessage(T model);
}