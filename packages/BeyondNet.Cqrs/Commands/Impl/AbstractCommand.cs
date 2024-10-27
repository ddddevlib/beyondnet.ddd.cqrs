namespace BeyondNet.Cqrs.Commands.Impl
{
    public abstract class AbstractCommand : ICommand 
    {
        public Guid Id { get; }

        protected AbstractCommand()
        {
            Id = Guid.NewGuid();
        }

    }
}
