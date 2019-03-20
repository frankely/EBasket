using System.Threading;
using System.Threading.Tasks;

namespace EBasket.Application.Core
{
    public interface IRequestHandler<in TQuery, TResult>
    {
        Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken);
    }
}