using System.ComponentModel.DataAnnotations;

namespace INV.Applicationcontract.Viewmodels.Fisicalyear
{
    public class CreateFisicalYear
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "بازه تاریخی اشتباه میباشد")]
        public DateTime StartDateTime { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "بازه تاریخی اشتباه میباشد")]

        public DateTime EndDateTime { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "توضیحات اشتباه میباشد")]

        public string description { get; set; }

        public string UserId { get; set; }
    }
}
