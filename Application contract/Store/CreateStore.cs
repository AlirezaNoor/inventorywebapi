using System.ComponentModel.DataAnnotations;

namespace INV.Applicationcontract.Store
{
    public class CreateStore
    {
        [Required(AllowEmptyStrings = false,ErrorMessage = "{0} Most not empty")]
        public string storename { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Most not empty")]

        public string address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Most not empty")]

        public string Telephone { get; set; }
        public string userid { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Most not empty")]

        public DateTime CreationDateTime { get; set; }
    }
}
