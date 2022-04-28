using Castle.Windsor;
using ServiceHostBuilder;

namespace ServiceHostBuilder.Sample
{
    public interface ICoffieeServiceHostBuilder : IServiceHostBuilder
    {
        new ICoffieeServiceHostBuilder RegisterService(Action<IWindsorContainer> serviceRegister);
        new ICoffieeServiceHostBuilder AddInitializer(Action<IWindsorContainer> initializer);
        new ICoffieeServiceHostBuilder AddRunner(Action<IWindsorContainer> runner);
    }
}