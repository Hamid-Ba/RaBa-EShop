using Application.CommentAgg.ChangeStatus;
using Application.CommentAgg.Create;
using Framework.Application;
using Query.CommentAgg.DTOs;

namespace Presentation.Facade.CommentAgg
{
    public interface ICommentFacade
	{
        #region Command
        Task<OperationResult> Create(CreateCommentCommand command);
		Task<OperationResult> ChangeStatus(ChangeStatusCommentCommand command);
        #endregion

        #region Query
        Task<CommentDto> GetBy(long id);
        Task<CommentFilterResult> GetAll(CommentFilterParam filter);
        #endregion
    }
}

