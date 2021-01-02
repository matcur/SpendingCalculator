using Autofac;
using SpendingCalculator.Core.Interfaces;
using SpendingCalculator.Core.Loaders;
using SpendingCalculator.Core.Savers;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustSomething.Di
{
    class DiBootstrapper
    {
        private ILifetimeScope lifeTimeScope;

        public DiBootstrapper()
        {
            var builder = new ContainerBuilder();
            RegisterTypes(builder);
            lifeTimeScope = builder.Build().BeginLifetimeScope();
        }

        public T Resolve<T>()
        {
            return lifeTimeScope.Resolve<T>();
        }

        private void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<XmlLoader>().As<ILoader>();
            builder.RegisterType<XmlSaver>().As<ISaver>();
        }
    }
}
