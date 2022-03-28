namespace Domain.ProductAgg.Services
{
    public interface IProductDomainService
    {
        bool IsSlugExist(string slug);
    }
}