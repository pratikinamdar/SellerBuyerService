using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using SellerBuyer.Models;

namespace SellerBuyer.Controllers
{
    public class BuyerController : ControllerBase
    {
        private DB db;
        public BuyerController(IConfiguration config)
        {
            db = new DB(config.GetConnectionString("constr"));
        }

        [HttpPost("Buyer", Name = "PostBuyer")]

        public void BuyerData(BuyerParams b)
        {
            db.Buyer.Add(new Buyer() { BuyerName = b.BuyerName, Price=b.Price, ProjectId =b.ProjectId });
            var projId = from p in db.Project
                         where p.ProjectId == b.ProjectId
                         select p.ProjectId;
            if (projId == null)
                throw new Exception("Could not find project. Please enter a valid project");
            db.SaveChanges();
        }

        [HttpGet("Buyer", Name = "GetBuyer")]

        public IEnumerable<Buyer> GetBuyer()
        {
            return from b in db.Buyer
                   select b;
        }

        [HttpGet("Winner", Name = "GetWinner")]

        public IEnumerable<BuyerProject> GetWinner()
        {
            /*BuyerProject bp = from p in db.Project
                              join b in db.Buyer 
                              on p.ProjectId equals b.ProjectId
                              group b by p into grouped
                              select new
                              {
                                  ProjectName = grouped.Key.ProjectName,
                                  BuyerName = grouped.Where(bb=>bb.Price == grouped.Min(x=>x.Price))
                              }
                              return bp.ToList();*/
            var bp = from p in db.Project
                     join b in db.Buyer
                     on p.ProjectId equals b.ProjectId
                     group b by p into grouped
                     select new BuyerProject
                     {
                         ProjectName = grouped.Key.ProjectName,
                         BuyerName = grouped.Where(bb => bb.Price == grouped.Min(x => x.Price)).Select(b => b.BuyerName).FirstOrDefault()
                     };
            return bp.ToList();
        }
    }

}