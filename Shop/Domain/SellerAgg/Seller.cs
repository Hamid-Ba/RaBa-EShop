using Domain.SellerAgg.Enums;
using Domain.SellerAgg.Services;
using Framework.Domain;
using Framework.Domain.Exceptions;

namespace Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public SellerStatus Status { get; private set; }
        public string StatusDescriber { get; private set; }

        public List<Inventory> Inventories { get; private set; }

        public Seller(long userId, string shopName, string nationalCode, ISellerDomainService sellerService)
        {
            Guard(shopName, nationalCode, sellerService);

            if (sellerService.IsSellerExistWithThis(userId))
                throw new InvalidDomainDataException("فروشگاه این شخص قبلا ثبت شده است");
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            Status = SellerStatus.New;
            StatusDescriber = "تازه به ثبت رسیده";

            Inventories = new List<Inventory>();
        }

        public void Edit(string shopName, string nationalCode, ISellerDomainService sellerService)
        {
            Guard(shopName, nationalCode, sellerService);

            ShopName = shopName;
            NationalCode = nationalCode;
            Status = SellerStatus.Pending;
            StatusDescriber = "مشخصات تغییر یافت";
        }

        public void ChangeStatus(SellerStatus sellerStatus, string description)
        {
            Status = sellerStatus;
            StatusDescriber = description;
        }

        #region Inventory

        public void AddInventory(Inventory inventory)
        {
            var isInventoryExist = Inventories.Any(i => i.Id == inventory.Id);

            if (!isInventoryExist)
            {
                inventory.SellerId = Id;
                Inventories.Add(inventory);
            }
            else throw new InvalidDomainDataException("این محصول قبلا ثبت شده است");
        }

        public void EditInventory(long inventoryId,long productId,int count,double price)
        {
            var inventory = Inventories.FirstOrDefault(i => i.Id == inventoryId);
            if (inventory is null) throw new InvalidDomainDataException("همچین محصولی در انبار شما وجود ندارد");

            inventory.Edit(productId, count, price);
        }

        public void DeleteInventory(long inventoryId)
        {
            var oldInventory = Inventories.FirstOrDefault(i => i.Id == inventoryId);

            if (oldInventory is null) throw new InvalidDomainDataException("همچین محصولی وجود ندارد");

            Inventories.Remove(oldInventory);
        }

        public void ChangeInventoryCount(long inventoryId, int count)
        {
            var inventory = Inventories.FirstOrDefault(i => i.Id == inventoryId);

            if (inventory is null) throw new InvalidDomainDataException("همچین محصولی وجود ندارد");

            inventory.ChangeCount(count);
        }

        public void ChangeInventoryPrice(long inventoryId, double price)
        {
            var inventory = Inventories.FirstOrDefault(i => i.Id == inventoryId);

            if (inventory is null) throw new InvalidDomainDataException("همچین محصولی وجود ندارد");

            inventory.ChangePrice(price);
        }

        #endregion

        public void Guard(string shopName, string nationalCode, ISellerDomainService sellerService)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));

            if (!IranianNationalIdChecker.IsValid(nationalCode)) throw new InvalidDomainDataException("کد ملی نامعتبر هست");

            if (NationalCode != nationalCode)
                if (sellerService.IsSellerExistWithThis(nationalCode))
                    throw new InvalidDomainDataException("این کد ملی ثبت شده است");
        }
    }
}