using Castle.MicroKernel.Registration;
using ServiceHostBuilder;
using ServiceHostBuilder.Sample;
using ServiceHostBuilder.Sample.MyServices.Milk;

namespace ServiceHost.MyServices
{
    public static partial class HostBuilderExtension
    {
        public static ICoffieeServiceHostBuilder UseMilk(this ICoffieeServiceHostBuilder serviceHostBuilder, int quantity)
        {
            serviceHostBuilder.RegisterService(containerBuilder =>
            {
                //登记簿containerBuilder。< HttpServer >美国< IServer >()()。WithParameter(“ip”,ip)。WithParameter(“港”,港)。WithParameter(“builderAction builderAction)。SingleInstance ();
                containerBuilder.Register(Component.For<Milk>()
                    .DependsOn(
                        Dependency.OnValue("quantity", quantity)
                  )
                    .LifestyleSingleton());

            });
            serviceHostBuilder.AddInitializer(container =>
            {
                var milk = container.Resolve<Milk>();
                milk?.Prepare();
            });
            serviceHostBuilder.AddRunner(container =>
            {
                var milk = container.Resolve<Milk>();
                milk?.Add();
            });

            return serviceHostBuilder;
        }

    }
}
