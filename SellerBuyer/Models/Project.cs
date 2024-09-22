using System.Data;

namespace SellerBuyer.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Requirement { get; set; }
        public DateTime LastDate { get; set; }
        public int SellerId { get; set; }
    }


    public class ProjectParams
    {
        public string ProjectName { get; set; }
        public string Requirement { get; set; }
        public DateTime LastDate { get; set; }

        public int SellerId { get;set; }
    }
}
