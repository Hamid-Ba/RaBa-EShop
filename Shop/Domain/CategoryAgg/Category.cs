using Domain.CategoryAgg.Services;
using Framework.Domain;
using Framework.Domain.Exceptions;
using Framework.Domain.Utils;
using Framework.Domain.ValueObjects;

namespace Domain.CategoryAgg
{
    public class Category : AggregateRoot
    {
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public long? ParentId { get; private set; }

        public List<Category> Children { get; private set; }

        private Category() { }

        public Category(string title, string slug, SeoData seoData, ICategoryDomainService categoryService)
        {
            Guard(title, slug.ToSlug(), categoryService);

            Title = title;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService categoryService)
        {
            Guard(title, slug.ToSlug(), categoryService);

            Title = title;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        #region SubsCat

        public void AddChild(Category child)
        {
            child.ParentId = Id;
            Children.Add(child);
        }

        #endregion

        public async void Guard(string title, string slug, ICategoryDomainService categoryService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

            if (Slug != slug)
                if (await categoryService.IsSlugExist(slug)) throw new InvalidDomainDataException("این اسلاگ ثبت شده است");
        }

    }
}