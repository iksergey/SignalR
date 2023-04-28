public class UserModel : IModel
{
  public string Username { get; set; }
  public string TextMessage { get; set; }
  public override string ToString()
  {
    return $"{Username}: {TextMessage}";
  }
}