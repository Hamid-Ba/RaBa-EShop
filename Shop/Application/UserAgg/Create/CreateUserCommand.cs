using Domain.UserAgg.Enums;
using Framework.Application;
using Microsoft.AspNetCore.Http;

namespace Application.UserAgg.Create
{
    public record CreateUserCommand(string FirstName, string LastName, string Email, string PhoneNumber, string Password, IFormFile Avatar,
            Gender Gender, List<long> Roles) : IBaseCommand;
}