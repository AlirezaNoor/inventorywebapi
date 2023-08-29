using System.ComponentModel.DataAnnotations;

namespace INV.Applicationcontract.Applicationuser
{
    public class Createuser
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام وارد نشده  است ")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام خانوادگی وارد نشده  است ")]

        public string Lastname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام کاربری وارد نشده  است ")]

        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ایمیل وارد نشده  است ")]

        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "کد ملی وارد نشده  است ")]

        public string melicode { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "کد شخصی وارد نشده  است ")]

        public string personalcode { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "تاریخ تولد وارد نشده  است ")]

        public DateTime Birthday { get; set; }

        public bool Gender { get; set; }
        //1=admin
        //2=user
        public byte UserType { get; set; }
    }
}
