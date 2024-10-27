namespace BeyondNet.Cqrs.Queries.Impl
{
    public abstract class AbstractQuery : IMessage, IQuery<ResultSet>
    {
        public Guid Id { get; } = Guid.NewGuid();

    }
}
