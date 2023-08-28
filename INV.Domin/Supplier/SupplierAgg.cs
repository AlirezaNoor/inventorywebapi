using System.Security.Principal;
using INV.Domin.Products;

namespace INV.Domin.Supplier
{
    public class SupplierAgg
    {
        public long Id { get; set; }
        public string  name { get; set; }
        public string telephone { get; set; }
        public string website{ get; set; }
        public List<product> Products { get; set; }

    }
}
