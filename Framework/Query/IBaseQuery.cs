using MediatR;

namespace Framework.Query
{
    public interface IBaseQuery<TQuery> : IRequest<TQuery> where TQuery : class
	{
		
	}
}