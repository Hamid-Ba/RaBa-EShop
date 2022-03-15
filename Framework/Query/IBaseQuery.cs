using Framework.Query.Filter;
using MediatR;

namespace Framework.Query
{
    public interface IBaseQuery<TQuery> : IRequest<TQuery> where TQuery : class
	{
		
	}

    public class QueryFilter<TResponse, TParam> : IBaseQuery<TResponse>
    where TResponse : BaseFilter
    where TParam : BaseFilterParam
    {
        public TParam FilterParams { get; set; }
        public QueryFilter(TParam filterParams) => FilterParams = filterParams;
    }
}