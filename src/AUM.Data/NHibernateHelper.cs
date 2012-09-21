using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace AUM.Data
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        /// <summary>
        /// Gets the session factory.
        /// </summary>
        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var config = new Configuration();
                    config.Configure();
                    _sessionFactory = config.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        /// <summary>
        /// Opens the session.
        /// </summary>
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
