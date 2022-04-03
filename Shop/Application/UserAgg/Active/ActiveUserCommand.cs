using Framework.Application;

namespace Application.UserAgg.Active
{
    public record ActiveUserCommand(long UserId) : IBaseCommand;
}