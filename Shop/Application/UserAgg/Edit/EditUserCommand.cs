using Domain.UserAgg.Enums;
using Framework.Application;
using Microsoft.AspNetCore.Http;

namespace Application.UserAgg.Edit
{
    public record EditUserCommand(long Id, string FirstName, string LastName, string Email, string PhoneNumber, IFormFile Avatar,
            string AvatarName, Gender Gender, List<long> Roles) : IBaseCommand;
}