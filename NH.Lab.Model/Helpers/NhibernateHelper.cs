using NH.Lab.Model.Domain;
using NHibernate;
using NHibernate.Cfg;
using System;

namespace NH.Lab.Market
{
    public class NHibernateHelper
    {
        private static Lazy<Configuration> NHConfiguration = new Lazy<Configuration>(() =>
        {
            var configuration = new Configuration();
            configuration.Configure();
            configuration.AddAssembly(typeof(Product).Assembly);

            return configuration;
        });

        private static Lazy<ISessionFactory> SessionFactory = new Lazy<ISessionFactory>(() =>
        {
            var configuration = new Configuration();
            configuration.Configure();
            configuration.AddAssembly(typeof(Product).Assembly);
            var _sessionFactory = configuration.BuildSessionFactory();

            return _sessionFactory;
        });


        public static ISession OpenSession()
        {
            return SessionFactory.Value.OpenSession();
        }

        public static Configuration Configuration
        {

            get { return NHConfiguration.Value; }
        }
    }
}
