using Domain.CategoryAgg;
using Query.CategoryAgg.DTOs;

namespace Query.CategoryAgg
{
    public static class CategoryMapper
	{
		public static List<CategoryDto> MapAll(this List<Category> categories)
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
				Children = c.Children.MapChildren()
			}).ToList();
        }

		public static List<CategoryChildrenDto> MapChildren(this List<Category> children)
        {
			if (children is null) return null;

			return children.Select(c => new CategoryChildrenDto
			{
				Id = c.Id,
				Title = c.Title,
				Slug = c.Slug,
				SeoData = c.SeoData,
				ParentId = c.ParentId,
				CreationDate = c.CreationDate,
				Children = c.Children.MapSecondaryChildren()
			}).ToList();
        }

		public static List<SecondaryCategoryChildren> MapSecondaryChildren(this List<Category> children)
        {
			if (children is null) return null;

			return children.Select(c => new SecondaryCategoryChildren
			{
				Id = c.Id,
				Title = c.Title,
				Slug = c.Slug,
				SeoData = c.SeoData,
				ParentId = c.ParentId,
				CreationDate = c.CreationDate,
			}).ToList();
		}
	}
}