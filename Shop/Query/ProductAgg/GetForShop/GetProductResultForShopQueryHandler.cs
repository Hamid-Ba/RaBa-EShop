using Domain.SellerAgg;
using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.CategoryAgg;
using Query.CategoryAgg.DTOs;
using Query.ProductAgg.DTOs;

namespace Query.ProductAgg.GetForShop
{
    public class GetProductResultForShopQueryHandler : IBaseQueryHandler<GetProductResultForShopQuery, ProductShopFilterResult>
    {
        private readonly ShopContext _context;

        public GetProductResultForShopQueryHandler(ShopContext context) => _context = context;

        public async Task<ProductShopFilterResult> Handle(GetProductResultForShopQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;

            var inventories = await _context.Sellers.Select(s => s.Inventories).ToListAsync();
            CategoryDto category = new();
            var products = await _context.Products.Where(p => inventories.Any(i => i.Any(s => s.ProductId == p.Id))).ToListAsync();

            if (!string.IsNullOrWhiteSpace(@params.CategorySlug))
            {
                var categories = await _context.Categories.FirstOrDefaultAsync(c => c.Title.Contains(@params.CategorySlug));
                category = categories.Map();
            }

            if (!string.IsNullOrWhiteSpace(@params.Search))
                products = products.Where(p => p.Title.Contains(@params.Search)).ToList();

          
            //Get First Inventory That Contain Chipest Cost Of The Product
            List<Inventory> productInventories = new List<Inventory>();

            foreach (var product in products)
            {
                var productInventory = await _context.Sellers
                    .Select(s => s.Inventories.Where(i => i.ProductId == product.Id).OrderByDescending(o => o.Price).FirstOrDefault())
                    .FirstOrDefaultAsync();

                productInventories.Add(productInventory);
            }
            //End Of Above Comment

            var skip = (@params.PageId - 1) * @params.Take;
            var productShopDto = products.Skip(skip).Take(@params.Take).ToList().MapProductShop(productInventories);

            switch (@params.SearchOrderBy)
            {
                case ProductSearchOrderBy.Latest:
                    productShopDto = productShopDto.OrderByDescending(o => o.Id).ToList();
                    break;

                case ProductSearchOrderBy.Expensive:
                    productShopDto = productShopDto.OrderByDescending(o => o.Price).ToList();
                    break;

                case ProductSearchOrderBy.Cheapest:
                    productShopDto = productShopDto.OrderBy(o => o.Price).ToList();
                    break;
            }

            var result = new ProductShopFilterResult(productShopDto, @params);
            result.Category = category;
            result.GeneratePaging(products.AsQueryable(), @params.Take, @params.PageId);

            return result;
        }
    }
}