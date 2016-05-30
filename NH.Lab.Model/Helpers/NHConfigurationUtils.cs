using NH.Lab.Model.Domain;
using NHibernate;
using NHibernate.Cfg;

namespace NH.Lab.Market
{
    public class NHConfigurationUtils
    {
        public Configuration NHConfiguration { get; set; }
        public ISessionFactory SessionFactory { get; set; }

        public NHConfigurationUtils()
        {
            var configuration = new Configuration();
            configuration.Configure();
            configuration.AddAssembly(typeof(Product).Assembly);

            NHConfiguration = configuration;
            SessionFactory = configuration.BuildSessionFactory();
        }
    }
}
