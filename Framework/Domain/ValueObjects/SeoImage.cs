using Common.Domain;

namespace Framework.Domain.ValueObjects
{
    public class SeoImage : ValueObject
    {
        private SeoImage()
        {
        }

        public SeoImage(string title, string alternative)
        {
            Title = title;
            Alternative = alternative;
        }

        public static SeoImage CreateEmpty()
        {
            return new SeoImage();
        }

        

        public string Title { get; private set; }
        public string Alternative { get; private set; }
    }
}