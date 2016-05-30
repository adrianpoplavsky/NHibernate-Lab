using NHibernate;
using NHibernate.Cfg;
using System;
using System.Threading;

namespace NH.Lab.Market
{
    public class NHibernateHelper
    {
        private static Lazy<NHConfigurationUtils> NHConfiguration = new Lazy<NHConfigurationUtils>(LazyThreadSafetyMode.ExecutionAndPublication);

        public static ISession OpenSession() { return NHConfiguration.Value.SessionFactory.OpenSession(); }

        public static Configuration Configuration
        {
            get { return NHConfiguration.Value.NHConfiguration; }
        }
    }
}
