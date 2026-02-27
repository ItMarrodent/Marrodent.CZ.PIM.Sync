namespace Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Rest;

public interface ISendingController<T>
{
    Task Execute(HttpMethod method, Uri address, ICollection<T> payload);
}