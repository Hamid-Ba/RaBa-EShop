namespace Domain.UserAgg.Services
{
    public interface IUserDomainService
    {
        Task<bool> IsEmailExist(string email);
        Task<bool> IsPhoneNumberExist(string phoneNumber);
    }
}
