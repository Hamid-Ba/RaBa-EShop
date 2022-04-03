using Framework.Application;

namespace Application.UserAgg.DeActive
{
    public record DeActiveUserCommand(long UserId) : IBaseCommand;
}