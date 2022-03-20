using Domain.UserAgg.Services;

namespace Application.UserAgg
{
    public class UserDomainService : IUserDomainService
    {
        public Task<bool> IsEmailExist(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsPhoneNumberExist(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}