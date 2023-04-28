using System.Collections.ObjectModel;

public class Storage<T> : IStorage<T>
    where T : IModel
{
  public Storage() => history = new();
  public void Append(T data) => history.Add(data);
  public IEnumerable<T> Read() => history;
  private ObservableCollection<T> history;
}