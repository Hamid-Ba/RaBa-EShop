using Framework.Application;

namespace Application.UserAgg.Register
{
    public record RegisterUserCommand(string PhoneNumber, string Password) : IBaseCommand;
}