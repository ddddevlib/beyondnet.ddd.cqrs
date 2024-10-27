namespace BeyondNet.Cqrs.Commands.Interfaces
{
    public interface ICommandDispatcher
    {
        void RegisterHandler<TCommand>(Func<TCommand, Task> handler) where TCommand : ICommand;

        Task SendAsync(ICommand command);
    }
}
