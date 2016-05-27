using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace NH.Lab.Market
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Register a script reference:
            Page.ClientScript.RegisterClientScriptInclude(GetType(), "headPageScriptdefault", "/Scripts/default.js");
            Page.ClientScript.RegisterClientScriptInclude(GetType(), "headPageScriptconfiguration", "/Scripts/configuration.js");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var searched = "%" + txtNameSearch.Text + "%";

            IList<Model.Domain.Market> markets;

            using (var session = NHibernateHelper.OpenSession())
            {
                markets = session.QueryOver<Model.Domain.Market>()
                    .Where(Restrictions.On<Model.Domain.Market>(x => x.Name).IsLike(searched))
                    .List<Model.Domain.Market>();
            }

            grdMarkets.DataSource = markets;
            grdMarkets.DataBind();
        }

        protected void btnProductSearch_Click(object sender, EventArgs e)
        {
            var searched = "%" + txtProductName.Text + "%";

            IList<Model.Domain.Product> products;

            using (var session = NHibernateHelper.OpenSession())
            {
                products = session.QueryOver<Model.Domain.Product>()
                    .Where(Restrictions.On<Model.Domain.Product>(x => x.Name).IsLike(searched))
                    .List<Model.Domain.Product>();

                grdProductResults.DataSource = products;

                grdProductResults.DataBind();
            }
        }

        protected void btnProductSearchNoSession_Click(object sender, EventArgs e)
        {
            var searched = "%" + txtProductName.Text + "%";

            IList<Model.Domain.Product> products;

            using (var session = NHibernateHelper.OpenSession())
            {
                products = session.QueryOver<Model.Domain.Product>()
                    .Where(Restrictions.On<Model.Domain.Product>(x => x.Name).IsLike(searched))
                    .List<Model.Domain.Product>();
            }

            if (products.Any())
            {
                products.First().Market.ToString();
            }


            grdProductResults.DataSource = products;

            grdProductResults.DataBind();
        }
    }
}