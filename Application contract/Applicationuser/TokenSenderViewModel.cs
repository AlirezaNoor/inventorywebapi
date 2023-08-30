namespace INV.Applicationcontract.Applicationuser
{
    public class TokenSenderViewModel
    {
        public string  username { get; set; }
        public string Token  { get; set; }
        public IList<string>? Roles { get; set; }
    }
}
