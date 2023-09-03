using System.ComponentModel.DataAnnotations;

namespace INV.Applicationcontract.produtcprice
{
    public class createproductprice
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "این وری نباید خالی باشد")]
        public int Purchaseprice { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "این وری نباید خالی باشد")]
        public int salesprice { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "این وری نباید خالی باشد")]
        public int coverprice { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "این وری نباید خالی باشد")]
        public DateTime OpertaionDateTime { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "این وری نباید خالی باشد")]
        public long productid { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "این وری نباید خالی باشد")]
        public long Fisicalyearid { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "این وری نباید خالی باشد")]
        public string userid { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "این وری نباید خالی باشد")]
        public DateTime actiondate { get; set; }
    }
}
