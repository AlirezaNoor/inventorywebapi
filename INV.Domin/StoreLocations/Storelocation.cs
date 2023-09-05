using INV.Domin.Products;
using INV.Domin.Stores;

namespace INV.Domin.StoreLocations
{
    public class Storelocation
    {
        public long Id { get; set; }
        public long StorId { get; set; }
        public long ProductId { get; set; }
        public string Location { get; set; }
        public string UserId { get; set; }
        public DateTime createiontime { get; set; }


        public virtual Store Store { get; set; }
        public virtual product Product { get; set; }
        public virtual ApplicationUser  User{ get; set; }
}
}
