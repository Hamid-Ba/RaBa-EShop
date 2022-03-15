using Domain.CategoryAgg;
using Query.CategoryAgg.DTOs;

namespace Query.CategoryAgg
{
    public static class CategoryMapper
	{
		public static CategoryDto Map(this Category? category)
        {
			if(category is null) return null;

			return new CategoryDto
			{
				Id = category.Id,
				ParentId = category.ParentId,
				Title = category.Title,
				Slug = category.Slug,
				SeoData = category.SeoData,
				CreationDate = category.CreationDate,
				Children = category.Children.Map()
			};
        }

		public static List<CategoryDto> Map(this List<Category> categories)
        {
			if (categories is null) return null;

			return categories.Select(c => new CategoryDto
			{
				Id = c.Id,
				Title = c.Title,
				Slug = c.Slug,
				SeoData = c.SeoData,
				ParentId = c.ParentId,
				CreationDate = c.CreationDate,
				Children = c.Children.Map()
			}).ToList();
        }
	}
}