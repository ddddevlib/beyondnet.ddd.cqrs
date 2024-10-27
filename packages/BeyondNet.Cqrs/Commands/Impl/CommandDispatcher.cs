﻿namespace BeyondNet.Cqrs.Commands.Impl
{
    public class CommandDispatcher : ICommandDispatcher
    {

        private readonly Dictionary<Type, Func<ICommand, Task>> _handlers = new();

        public void RegisterHandler<T>(Func<T, Task> handler) where T : ICommand
        {
            if (handler is null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            if (_handlers.ContainsKey(typeof(T)))
                throw new InvalidOperationException($"Handler for {typeof(T).Name} is already registered.");

            _handlers.Add(typeof(T), command => handler((T)command));
        }

        public async Task SendAsync(ICommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (_handlers.TryGetValue(command.GetType(), out var handler))
            {
                await handler(command);
            }
            else
            {
                throw new InvalidOperationException($"Handler for {command.GetType().Name} is not registered.");
            }
        }
    }
}
