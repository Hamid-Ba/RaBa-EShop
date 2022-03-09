using Domain.UserAgg.Enums;
using Framework.Domain;
using Framework.Domain.Exceptions;

namespace Domain.UserAgg
{
    public class UserWallet : BaseEntity
	{
        public long UserId { get; internal set; }
        public double Amount { get; private set; }
        public WalletType Type { get; private set; }
        public bool IsPayed { get; private set; }
        public DateTime? PayedDate { get; private set; }
        public string RefId { get; private set; }

        public User User { get; set; }

        public UserWallet(double amount)
        {
            Amount = amount;
            IsPayed = false;
        }

        public void Finally(string refId)
        {
            RefId = refId;
            IsPayed = true;
            PayedDate = DateTime.Now;
        }

        public void Deposit(double amount,string refId)
        {
            Amount += amount;
            IsPayed = true;
            RefId = refId;
            PayedDate = DateTime.Now;
            Type = WalletType.Deposit;
        }

        public void WithRaw(double amount)
        {
            if (Amount - amount < 0)
                throw new InvalidDomainDataException("مبلغ درخواستی بیشتر از موجودی است");

            Amount -= amount;
            IsPayed = true;
            PayedDate = DateTime.Now;
            Type = WalletType.Deposit;
        }
    }
}