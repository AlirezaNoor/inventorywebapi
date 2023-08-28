using System.ComponentModel.DataAnnotations;
using INV.Domin.Contract.Unit;

namespace INV.Applicationcontract.Viewmodels.Productsmodels
{
    public  class Createproducts
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام کالا وارد نشده است ")]
        public string name { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = "نوع بسته بندی انتیخاب نشده است  ")]
        public Units Unit { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "تعداد کالا کالا وارد نشده است ")]

        public long inbox { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "وزن کالا وارد نشده است ")]

        public long wight { get; set; }
        [Range(1,long.MaxValue,ErrorMessage = "تامین کننده انتخاب نشده است ")]
        public long supplierid { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = "کشور سازنده  انتخاب نشده است ")]

        public long countryid { get; set; }
        public byte Isrefregertor { get; set; }
    }
}
