using BeyondNet.Cqrs.Commands.Interfaces;
using BeyondNet.Cqrs.Core.Impl;

namespace BeyondNet.Cqrs.Commands.Impl
{
    public abstract class AbstractCommand : AbstractMessage, ICommand
    {        
        public DateTime SentAt { get; private set; }

        protected AbstractCommand()
        {
            SentAt = DateTime.Now;
        }
    }
}
