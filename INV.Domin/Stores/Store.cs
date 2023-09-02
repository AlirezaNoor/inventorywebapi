namespace INV.Domin.Stores
{
    public class Store
    {
        public long  Id { get; set; }
        public string storename { get; set; }
        public string address  { get; set; }
        public string Telephone { get; set; }
        public string userid { get; set; }
        public DateTime CreationDateTime { get; set; }
        public virtual ApplicationUser user { get; set; }


    }
}
