using Framework.Application;

namespace Application.UserAgg.ChangePassword
{
    public record ChangePasswordCommand(long Id , string NewPassword) : IBaseCommand;
}