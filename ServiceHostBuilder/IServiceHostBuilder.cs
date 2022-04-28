using System;
using Castle.Windsor;


namespace ServiceHostBuilder
{
    public interface IServiceHostBuilder
    {
        ///<summary>
        ///注册服务
        ///</summary>
        ///<param name="serviceRegister">autofac IWindsorContainer</param>
        ///<returns></returns>
        IServiceHostBuilder RegisterService(Action<IWindsorContainer> serviceRegister);

        ///<summary>
        ///委托将在初始化主机时退出
        ///</summary>
        ///<param name="initializer">autofac IWindsorContainer</param>
        ///<returns></returns>
        IServiceHostBuilder AddInitializer(Action<IWindsorContainer> initializer);

        IServiceHostBuilder AddRunner(Action<IWindsorContainer> runner);

        ///<summary>
        ///建立serviceHost
        ///</summary>
        ///<returns></returns>
        IServiceHost Build();
    }
}