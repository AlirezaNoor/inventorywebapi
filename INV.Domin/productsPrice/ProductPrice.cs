using INV.Domin.Products;

namespace INV.Domin.productsPrice
{
    public class ProductPrice
    {
        public long ProductPriceid { get; set; }

        //قیمت خرید از تامین کننده
        public int Purchaseprice { get; set; }
        //قیمت فروش به عمده
        public int salesprice { get; set; }

        //قیمت روی  کاور
        public int coverprice { get; set; }

        public DateTime OpertaionDateTime { get; set; }

        public long productid { get; set; }
        public long Fisicalyearid { get; set; }
        public string userid { get; set; }
        public DateTime actiondate { get; set; }
        public virtual ApplicationUser user { get; set; }
        public virtual product Product { get; set; }
        public virtual FisicalYear.FisicalYear Fisical { get; set; }
    }
}
