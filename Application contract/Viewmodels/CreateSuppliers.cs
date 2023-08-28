using System.ComponentModel.DataAnnotations;

namespace INV.Applicationcontract.Viewmodels
{
    public class CreateSuppliers
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام تامین کننده را وارد کنید")]
        public string name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "تلفن تامین کننده را وارد کنید")]

        public string telephone { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "وب سایت تامین کننده را وارد کنید")]

        public string website { get; set; }
    }
}

