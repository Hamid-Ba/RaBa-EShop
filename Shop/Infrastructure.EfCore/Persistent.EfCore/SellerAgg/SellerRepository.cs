using Application.Contract.SellerAgg;
using Dapper;
using Domain.SellerAgg;
using Domain.SellerAgg.Repository;
using Framework.Infrastructure;
using Infrastructure.Persistent.Dapper;

namespace Infrastructure.Persistent.EfCore.SellerAgg
{
    public class SellerRepository : Repository<Seller> , ISellerRepository
	{
        private readonly DapperContext _dapperContext;

        public SellerRepository(ShopContext context, DapperContext dapperContext) : base(context) => _dapperContext = dapperContext;

        public async Task<InventoryDto> GetInventoryBy(long id)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = $"select * from {_dapperContext.Inventories} where id=@id";
            return await connection.QueryFirstOrDefaultAsync<InventoryDto>(sql, new { id });
        }
    }
}