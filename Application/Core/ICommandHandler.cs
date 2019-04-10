using System.Threading.Tasks;

namespace EBasket.Application.Core
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand request);
    }
}