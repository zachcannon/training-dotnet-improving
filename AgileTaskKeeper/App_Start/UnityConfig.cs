using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using AgileTaskKeeper.Resolvers;
using AgileTaskKeeper.Models;
using System.Web.Http;
using AgileTaskKeeper.Data;
using System.Data.Entity;

namespace AgileTaskKeeper
{
    public static class UnityConfig
    {

        public static void RegisterUnity(HttpConfiguration config)
        {
            var container = new UnityContainer();
          
            container.RegisterType<IAgileTaskRepository, AgileTaskRepository>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);
        }
        
    }
}