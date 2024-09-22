namespace SellerBuyer.Models
{
    public class Buyer
    {
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public int Price { get; set; }
        public int ProjectId { get; set; }

    }

    public class BuyerParams
    {
        public string BuyerName { get; set; }
        public int Price { get; set;}
        public int ProjectId { get; set; }
    }


    public class BuyerProject
    {
        public string BuyerName { get; set; }
        public string ProjectName { get; set; }
    }
}
