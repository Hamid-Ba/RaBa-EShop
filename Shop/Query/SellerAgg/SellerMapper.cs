﻿using Domain.SellerAgg;
using Infrastructure.Persistent.EfCore;
using Query.SellerAgg.DTOs;

namespace Query.SellerAgg
{
    public static class SellerMapper
	{
		public static SellerDto? MapSingle(this Seller? seller,ShopContext context)
        {
			if (seller is null) return null;

			var user = context.Users.Select(u =>new { Id = u.Id , UserFullName = $"{u.FirstName} {u.LastName}" }).FirstOrDefault(u => u.Id == seller.UserId);

			return new SellerDto
			{
				Id = seller.Id,
				UserId = seller.UserId,
				UserFullName = user is null ? "" : user.UserFullName ,
				ShopName = seller.ShopName,
				NationalCode = seller.NationalCode,
				Inventories = seller.MapInventories(),
				CreationDate = seller.CreationDate,
				Status = seller.Status,
				StatusDescriber = seller.StatusDescriber
			};
        }

		public static SellerDto? Map(this Seller? seller,ShopContext context)
        {
			if (seller is null) return null;

			var user = context.Users.Select(u => new { Id = u.Id, UserFullName = $"{u.FirstName} {u.LastName}" }).FirstOrDefault(u => u.Id == seller.UserId);

			return new SellerDto
			{
				Id = seller.Id,
				UserId = seller.UserId,
				UserFullName = user is null ? "" : user.UserFullName,
				ShopName = seller.ShopName,
				NationalCode = seller.NationalCode,
				CreationDate = seller.CreationDate,
				Status = seller.Status,
				StatusDescriber = seller.StatusDescriber
			};
		}

		public static List<InventoryDto>? MapInventories(this Seller seller)
        {
			if (seller.Inventories is null) return null;

			return seller.Inventories.Select(i => new InventoryDto
			{
				Id = i.Id,
				SellerId = i.SellerId,
				ProductId = i.ProductId,
				Price = i.Price,
				Count = i.Count,
				CreationDate = i.CreationDate
			}).ToList();
        }
	}
}