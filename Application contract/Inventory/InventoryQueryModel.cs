namespace INV.Applicationcontract.Inventory
{
    public  class InventoryQueryModel
    {
        public long productid { get; set; }
        public string productname { get; set; }
        public string productcode { get; set; }
        public long productmaincount { get; set; }
        public long productwesagecount { get; set; }
    }
}
