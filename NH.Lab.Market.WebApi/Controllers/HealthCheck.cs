using NHibernate.Tool.hbm2ddl;
using System.Web.Http;

namespace NH.Lab.Market.Controllers
{
    public class HealthCheckController : ApiController
    {
        [HttpGet]
        public string Execute()
        {
            return "Up and Running";
        }
    }
}
