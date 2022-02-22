namespace Domain.ProductAgg.Services
{
    public interface IProductDomainService
    {
        Task<bool> IsSlugExist(string slug);
    }
}