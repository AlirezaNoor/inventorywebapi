using INV.Domin.Products;

namespace INV.Domin.Counteries
{
    public class Country
    {
        public long Id { get; set; }
        public string name { get; set; }
        public List<product>? Products { get; set; }
    }
}
