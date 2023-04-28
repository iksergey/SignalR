public class ConsoleUserModel : IModel
{
  public ConsoleUserModel()
  {
    Color = ConsoleColor.Yellow;
  }
  public string Username { get; set; }
  public ConsoleColor Color { get; set; }
  public string TextMessage { get; set; }
  public override string ToString()
  {
    return $"{Username}: {TextMessage}";
  }
}