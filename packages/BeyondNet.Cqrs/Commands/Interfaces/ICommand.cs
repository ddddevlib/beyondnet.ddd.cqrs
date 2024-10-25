using BeyondNet.Cqrs.Core.Interfaces;

namespace BeyondNet.Cqrs.Commands.Interfaces
{
    public interface ICommand : IMessage
    {
        public DateTime SentAt { get; }
    }
}
