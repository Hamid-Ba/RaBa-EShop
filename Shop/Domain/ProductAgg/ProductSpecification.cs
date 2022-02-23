using Framework.Domain;
using Framework.Domain.Exceptions;

namespace Domain.ProductAgg
{
    public class ProductSpecification : BaseEntity
    {
        public long ProductId { get; internal set; }
        public string Key { get; private set; }
        public string Value { get; private set; }

        public ProductSpecification(string key, string value)
        {
            Guard(key, value);

            Key = key;
            Value = value;
        }

        public void Edit(string key, string value)
        {
            Guard(key, value);

            Key = key;
            Value = value;
        }

        public void Guard(string key, string value)
        {
            NullOrEmptyDomainDataException.CheckString(key, nameof(key));
            NullOrEmptyDomainDataException.CheckString(value, nameof(value));
        }
    }
}