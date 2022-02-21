namespace Domain.RoleAgg.Services
{
    public interface IRoleDomainService
    {
        Task<bool> IsThisTitleExist(string title);
    }
}
