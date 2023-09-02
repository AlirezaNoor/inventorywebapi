using INV.Domin.Products;
using INV.Domin.Stores;

namespace INV.Domin.Inventories
{
    public class Inventory
    {
        public long InventoryId { get; set; }
        public long productId { get; set; }
        public long storeId { get; set; }
        public string UserId { get; set; }
        public long FisicalyearId { get; set; }
        public long prductcountmain { get; set; }
        public long productcountwestage { get; set; }
        public DateTime Tyoprationdatepe { get; set; }
        //1-ورود به انبار اصلی +
        //2- کسر از انبار اصلی -
        //3-ورورد به انبار ضایعات +
        //4-کسر از انبار ضایعات -
        //5 فروش -
        //6- مرجوعی از فروش +
        public byte oprationtype { get; set; }
        public DateTime Expirtiondate { get; set; }
        public string description { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual product product { get; set; }
        public virtual Store store { get; set; }
        public virtual FisicalYear.FisicalYear FisicalYear { get; set; }
    }
}
