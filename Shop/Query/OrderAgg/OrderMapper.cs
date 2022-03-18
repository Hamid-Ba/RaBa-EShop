using Domain.OrderAgg;
using Infrastructure.Persistent.EfCore;
using Query.OrderAgg.DTOs;

namespace Query.OrderAgg
{
    public static class OrderMapper
    {
        public static List<OrderDto> Map(this List<Order> orders, ShopContext context)
        {
            if (orders is null) return null;

            //using var connection = dapperContext.CreateConnection();
            //var sql = $"select * from {dapperContext.Orders} o " +
            //    $"inner join {dapperContext.Users} u on o.UserId = u.Id";
            //var result = connection.Query<OrderDto>(sql).ToList();

            var user = context.Users.Select(u => new { Id = u.Id, FullName = $"{u.FirstName} {u.LastName}" }).ToList();

            var result = orders.Select(o => new OrderDto
            {
                Id = o.Id,
                UserId = o.UserId,
                FullName = "",
                TotalPrice = o.TotalPrice,
                DiscountPrice = o.DiscountPrice,
                PayAmount = o.PayAmount,
                Method = o.Method,
                Status = o.Status,
                CreationDate = o.CreationDate,
                //Items = o.Items.MapItems(context),
                Address = o.Address.MapAddress(),
            }).ToList();

            result.ForEach(o => o.FullName = user.FirstOrDefault(u => u.Id == o.UserId)?.FullName);

            return result;
        }

        public static List<OrderItemDto> MapItems(this List<OrderItem> items,ShopContext context)
        {
            if (items is null) return null;

            var sellers = context.Sellers.Select(s => new { InventoriesId = s.Inventories.Select(i => new {Id = i.Id,ProductId = i.ProductId})
                , ShopName = s.ShopName }).ToList();

            var products = context.Products.Select(p => new { Id = p.Id, Name = p.Title ,ImageName = p.ImageName}).ToList();

            var result = items.Select(i => new OrderItemDto
            {
                Id = i.Id,
                OrderId = i.OrderId,
                InventoryId = i.InventoryId,
                ShopName = "",
                ProductName = "",
                ImageName = "",
                Count = i.Count,
                Discount = i.Discount,
                PayAmount = i.PayAmount,
                TotalPrice = i.TotalPrice,
                CreationDate = i.CreationDate
            }).ToList();

            result.ForEach(i => i.ShopName = sellers.FirstOrDefault(s => s.InventoriesId.Any(z => z.Id == i.InventoryId))?.ShopName);

            result.ForEach(i => i.ProductName = products.FirstOrDefault(p=>sellers.Any(z => z.InventoriesId.Any(y => y.Id == i.InventoryId)))?.Name);
            result.ForEach(i => i.ImageName = products.FirstOrDefault(p=>sellers.Any(z => z.InventoriesId.Any(y => y.Id == i.InventoryId)))?.ImageName);

            return result;
        }

        public static OrderAddressDto MapAddress(this OrderAddress address)
        {
            if (address is null) return null;

            return new OrderAddressDto
            {
                Id = address.Id,
                OrderId = address.OrderId,
                FullName = address.FullName,
                NationalCode = address.NationalCode,
                PhoneNumber = address.PhoneNumber,
                Province = address.Province,
                City = address.City,
                Address = address.Address,
                PostalCode = address.PostalCode,
                CreationDate = address.CreationDate
            };
        }
    }
}