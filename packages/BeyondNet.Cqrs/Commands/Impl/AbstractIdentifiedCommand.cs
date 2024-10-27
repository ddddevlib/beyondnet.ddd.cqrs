namespace BeyondNet.Cqrs.Commands.Impl
{
    public class AbstractIdentifiedCommand<TCommand, TResult> : IRequest<TResult>
       where TCommand: ICommand
       where TResult : ResultSet
    {
        public TCommand Command { get; }
        public Guid Id { get; }
        public AbstractIdentifiedCommand(TCommand command, Guid id)
        {
            Command = command;
            Id = id;
        }
    }
}
