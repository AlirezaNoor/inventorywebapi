namespace INV.Domin.FisicalYear
{
    public class FisicalYear
    {
        public long Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool FisicalFlag { get; set; }
        public DateTime Createfiscalyear { get; set; }
        public string UserId { get; set; }
        public string description { get; set; }

        public ApplicationUser user { get; set; }
    }
}
