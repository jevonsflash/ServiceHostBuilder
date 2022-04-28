using Castle.MicroKernel.Registration;
using ServiceHostBuilder;
using ServiceHostBuilder.Sample;
using ServiceHostBuilder.Sample.MyServices.Suggar;

namespace ServiceHost.MyServices
{
    public static partial class HostBuilderExtension
    {
        public static ICoffieeServiceHostBuilder UseSuggar(this ICoffieeServiceHostBuilder serviceHostBuilder)
        {
            serviceHostBuilder.RegisterService(containerBuilder =>
            {
                //登记簿containerBuilder。< HttpServer >美国< IServer >()()。WithParameter(“ip”,ip)。WithParameter(“港”,港)。WithParameter(“builderAction builderAction)。SingleInstance ();
                containerBuilder.Register(Component.For<Suggar>().LifestyleSingleton());

            });
            serviceHostBuilder.AddInitializer(container =>
            {
                var suggar = container.Resolve<Suggar>();
                suggar?.Prepare();
            });
            serviceHostBuilder.AddRunner(container =>
            {
                var suggar = container.Resolve<Suggar>();
                suggar?.Add();
            });

            return serviceHostBuilder;
        }

    }
}
