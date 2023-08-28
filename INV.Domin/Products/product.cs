
using INV.Domin.Contract.Unit;
using INV.Domin.Counteries;
using INV.Domin.Supplier;

namespace INV.Domin.Products
{
    public class product
    {
        public long id { get; set; }
        public  string name { get; set; }
        public Units Unit { get; set; }
        public  long inbox { get; set; }
        public long wight { get; set; }
        public long supplierid { get; set; }
        public long countryid { get; set; }
        public byte Isrefregertor { get; set; }

        #region MyRegion

        public virtual Country Country { get; set; }
        public virtual SupplierAgg Supplier { get; set; }
        #endregion
    }
}
