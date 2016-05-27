using NH.Lab.Model.Domain;
using NHibernate.Criterion;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NH.Lab.Market.API
{
    public class ProductsController : ApiController
    {
        public IEnumerable<ProductDTO> GetAllProducts()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var products = session
                    .CreateQuery("from Product")
                    .List<Product>()
                    .OrderBy(x => x.Name)
                    .Select(x => { return new ProductDTO { Name = x.Name }; })
                    .ToList();

                return products;
            }
        }

        [HttpPost]
        public void Add([FromBody]Product newProduct)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                session.Save(newProduct);

                tx.Commit();
            }
        }

        public IList<ProductDTO> GetByProductName(string txtProductName)
        {
            var searched = "%" + txtProductName + "%";

            using (var session = NHibernateHelper.OpenSession())
            {
                var products = session.QueryOver<Product>()
                    .Where(Restrictions.On<Product>(x => x.Name).IsLike(searched))
                    .List<Product>()
                    .Select(x => { return new ProductDTO { Id = x.Id, Name = x.Name }; })
                    .ToList();

                return products;
            }
        }
    }
}
