using Microsoft.AspNetCore.Mvc;
using SellerBuyer.Models;

namespace SellerBuyer.Service
{
    public class SellerService
    {
        private DB dbo;

        public SellerService(DB dbo) 
        {
            this.dbo = dbo;
        }

        public void NewSeller(SellerParams s) 
        {
            dbo.Seller.Add(new Seller() { Name = s.SellerName });
            dbo.SaveChanges();
        }

        public void NewProject(ProjectParams proj)
        {
            dbo.Project.Add(new Project() { ProjectName = proj.ProjectName, LastDate = proj.LastDate, Requirement = proj.Requirement, SellerId = proj.SellerId });
            var id = (from s in dbo.Seller
                      where s.SellerId == proj.SellerId
                      select s.SellerId).First();
            if (id == null)
                throw new Exception("Seller isnt existing");
            dbo.SaveChanges();
        }


        public IEnumerable<Seller> GetSellers()
        {
            return from c in dbo.Seller
                   select c;
        }
    }
}
