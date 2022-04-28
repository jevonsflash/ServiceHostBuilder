using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ServiceHostBuilder;
using ServiceHostBuilder.Sample.MyServices.Coffee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHostBuilder.Sample
{

    public class CoffieeServiceHostBuilder : ServiceHostBuilderBase, ICoffieeServiceHostBuilder
    {
        public CoffieeServiceHostBuilder(IWindsorContainer containerBuilder) : base(containerBuilder)
        {
            RegisterService(cb =>
            {
                cb.Register(Component.For<Coffee>());

            });
            AddInitializer(cb =>
            {
                var clientServiceDiscovery = cb.Resolve<Coffee>();
                clientServiceDiscovery?.Init();
            });
            AddRunner(container =>
            {
                var clientServiceDiscovery = container.Resolve<Coffee>();
                clientServiceDiscovery?.Start();

            });
        }


        public new ICoffieeServiceHostBuilder RegisterService(Action<IWindsorContainer> serviceRegister)
        {

            return base.RegisterService(serviceRegister) as ICoffieeServiceHostBuilder;
        }

        public new ICoffieeServiceHostBuilder AddInitializer(Action<IWindsorContainer> initializer)
        {
            return base.AddInitializer(initializer) as ICoffieeServiceHostBuilder;
        }

        public new ICoffieeServiceHostBuilder AddRunner(Action<IWindsorContainer> runner)
        {
            return base.AddRunner(runner) as ICoffieeServiceHostBuilder;
        }
    }

}
