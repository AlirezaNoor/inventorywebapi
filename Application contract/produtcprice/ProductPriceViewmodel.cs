namespace INV.Applicationcontract.produtcprice
{
    public class ProductPriceViewmodel
    {
        public long productid { get; set; }
        public string productname { get; set; }
        public string productcode { get; set; }
        public string userid { get; set; }
        public long fisicalyear { get; set; }
        public long ProductPriceid { get; set; }
        public int Purchaseprice { get; set; }
        public int salesprice { get; set; }
        public int coverprice { get; set; }
        public DateTime actiondate { get; set; }

    }
}