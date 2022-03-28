using Domain.UserAgg.Repository;
using Domain.UserAgg.Services;

namespace Application.UserAgg
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _userRepository;

        public UserDomainService(IUserRepository userRepository) => _userRepository = userRepository;

        public bool IsEmailExist(string email) => _userRepository.Exists(u => u.Email == email);

        public bool IsPhoneNumberExist(string phoneNumber) => _userRepository.Exists(u => u.PhoneNumber == phoneNumber);
        
    }
}