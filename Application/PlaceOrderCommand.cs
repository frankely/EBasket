using System.Threading.Tasks;
using EBasket.Application.Core;
using EBasket.Application.Models;

namespace EBasket.Application
{
    public class PlaceOrderCommand : ICommand
    {
        public OrderReadModel OrderReadModel { get; set; }

        public class Handler : ICommandHandler<PlaceOrderCommand>
        {
            public async Task ExecuteAsync(PlaceOrderCommand request)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}