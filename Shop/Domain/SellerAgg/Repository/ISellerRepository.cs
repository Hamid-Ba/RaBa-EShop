using Application.Contract.SellerAgg;
using Framework.Domain.Repository;

namespace Domain.SellerAgg.Repository
{
    public interface ISellerRepository : IRepository<Seller>
    {
        Task<InventoryDto> GetInventoryBy(long id);
    }
}