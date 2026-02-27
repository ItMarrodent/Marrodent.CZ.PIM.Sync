namespace Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Sql;

public interface ISqlController<T>
{
    Task<T> Single(string query);
    Task<ICollection<T>> List(string query);
}