namespace Domain.SellerAgg.Services
{
    public interface ISellerDomainService
    {
        bool IsSellerExistWithThis(long userId);
        bool IsSellerExistWithThis(string nationalCode);
    }
}