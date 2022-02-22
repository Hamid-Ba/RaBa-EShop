namespace Domain.CategoryAgg.Services
{
    public interface ICategoryDomainService
    {
        Task<bool> IsSlugExist(string slug);
    }
}