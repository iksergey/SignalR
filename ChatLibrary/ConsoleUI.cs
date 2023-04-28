using System.Diagnostics;

namespace ChatLibrary
{
  public class ConsoleUI : IUserInterface
  {
    public void Print(IModel model)
    {

      if (model is ConsoleUserModel m) Console.ForegroundColor = m.Color;
      else Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine(model);
      Console.ForegroundColor = ConsoleColor.Gray;
    }
  }
  public class DebugUI : IUserInterface
  {
    public void Print(IModel model)
    {
      Debug.WriteLine($"{DateTime.Now} {model} ");
    }
  }
}