using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using SellerBuyer.Models;
using SellerBuyer.Service;

namespace SellerBuyer.Controllers
{
    public class SellerController : ControllerBase
    {
        private DB db;

        private SellerService SellerService;
        public SellerController(IConfiguration config)
        {
            db = new DB(config.GetConnectionString("constr"));
            SellerService = new SellerService(db);
        }

        [HttpPost("Seller", Name = "PostSeller")]

        public void SellerData(SellerParams s)
        {
            SellerService.NewSeller(s);
        }

        [HttpPost("Project", Name = "PostProjects")]
        public void PostProject(ProjectParams proj)
        {
           SellerService.NewProject(proj);
        }


        [HttpGet("Sellers", Name ="GetSellers")]
        public IEnumerable<Seller> GetSellers() 
        {
           return SellerService.GetSellers();
        }



        [HttpGet("Projects", Name = "GetProjects")]
        public IEnumerable<Project> GetProjects()
        {
            return from c in db.Project
                   select c;
        }
    }
}
