namespace BeyondNet.Cqrs.Commands.Interfaces
{
    public interface ICommand : IRequest<ResultSet>, IMessage
    {
    }
}
