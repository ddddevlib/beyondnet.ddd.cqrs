namespace BeyondNet.Cqrs.Interfaces
{
    public interface IQuery<out T> : IRequest<T>
       where T : notnull
    {
    }
}
