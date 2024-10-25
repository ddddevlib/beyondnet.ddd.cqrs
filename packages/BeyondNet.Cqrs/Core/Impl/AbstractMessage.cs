using BeyondNet.Cqrs.Core.Interfaces;

namespace BeyondNet.Cqrs.Core.Impl
{
    public abstract class AbstractMessage : IMessage
    {
        public Guid Id { get; set; }
    }
}
