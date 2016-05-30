using NHibernate.Tool.hbm2ddl;
using System.Web.Http;

namespace NH.Lab.Market.Controllers
{
    public class ConfigurationController : ApiController
    {
        [HttpGet]
        public bool CheckSchema()
        {
            new SchemaValidator(NHibernateHelper.Configuration).Validate();

            return true;
        }

        [HttpGet]
        public bool CreateSchema()
        {
            new SchemaExport(NHibernateHelper.Configuration).Execute(false, true, false);

            return true;
        }
    }
}
