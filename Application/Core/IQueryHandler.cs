using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBasket.Application.Core
{
    public interface IQueryHandler<in TQuery, TModel> where TQuery : IQuery<TModel>
    {
        Task<TModel> ExecuteAsync(TQuery request);
    }
}