using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NH.Lab.Market.Controllers
{
    public class MarketsController : ApiController
    {
        public IEnumerable<Model.Domain.Market> GetAllMarkets()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var markets = session.CreateQuery("from Market").List<Model.Domain.Market>().ToList();
                return markets;
            }
        }

        [HttpPost]
        public void Add([FromBody]Model.Domain.Market newMarket)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                session.Save(newMarket);

                tx.Commit();
            }
        }
    }
}
