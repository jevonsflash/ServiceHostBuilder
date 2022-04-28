using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ServiceHostBuilder.Services.Logger;
using ServiceHostBuilder.Services.Serializer;
using System;
using System.Collections.Generic;

namespace ServiceHostBuilder
{
    ///<summary>
    ///客户端和服务器的基本Builder
    ///</summary>
    public abstract class ServiceHostBuilderBase : IServiceHostBuilder
    {
        ///<summary>
        ///Action将在初始化中执行:在容器构建之后
        ///</summary>
        private readonly List<Action<IWindsorContainer>> _initializers;

        ///<summary>
        ///Action将在服务器运行时执行
        ///</summary>
        private readonly List<Action<IWindsorContainer>> _runners;

        ///<summary>
        ///在容器构建之前执行注册
        ///</summary>
        private readonly List<Action<IWindsorContainer>> _serviceRegisters;

        private readonly IWindsorContainer _containerBuilder;

        protected ServiceHostBuilderBase(IWindsorContainer containerBuilder)
        {
            _containerBuilder = containerBuilder;
            _serviceRegisters = new List<Action<IWindsorContainer>>();
            _initializers = new List<Action<IWindsorContainer>>();
            _runners = new List<Action<IWindsorContainer>>();
        }

        public IServiceHost Build()
        {
            IWindsorContainer container = null;
            var host = new ServiceHost(_runners);

            _containerBuilder.Register(Component.For<IServiceHost>()
                .UsingFactoryMethod(() => host)
                .LifestyleSingleton());

            _containerBuilder.Register(Component.For<ILogger>().ImplementedBy<Logger>());
            _containerBuilder.Register(Component.For<ISerializer>().ImplementedBy<Serializer>());

            _serviceRegisters.ForEach(x => { x(_containerBuilder); });

            container = _containerBuilder;
            _initializers.ForEach(x => { x(container); });

            host.Container = container;

            return host;
        }

        public IServiceHostBuilder AddInitializer(Action<IWindsorContainer> initializer)
        {
            _initializers.Add(initializer);
            return this;
        }

        public IServiceHostBuilder AddRunner(Action<IWindsorContainer> runner)
        {
            _runners.Add(runner);
            return this;
        }

        public IServiceHostBuilder RegisterService(Action<IWindsorContainer> serviceRegister)
        {
            _serviceRegisters.Add(serviceRegister);
            return this;
        }
    }
}