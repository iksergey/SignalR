public interface IStorage<T>
{
  void Append(T data);
  IEnumerable<T> Read();
}