using BeyondNet.Cqrs.Queries.Impl;

namespace BeyondNet.Cqrs.Queries.Interfaces
{
    public interface IQueryDispatcher<TEntity>
    {
        void RegisterHandler<TQuery>(Func<TQuery, Task<List<TEntity>>> handler) where TQuery: AbstractQuery;
        Task<List<TEntity>> SendAsync(AbstractQuery query);
    }
}