using System;
using Castle.Windsor;


namespace ServiceHostBuilder
{
    public interface IServiceHost : IDisposable
    {
        ///<summary>
        ///Ioc容器
        ///</summary>
        IWindsorContainer Container { get; }

        ///<summary>
        ///委托将在主机处理过程中退出
        ///</summary>
        ///<param name="action"></param>
        void DisposeAction(Action<IWindsorContainer> action);

        void RunAction(Action<IWindsorContainer> action);

        void Run();
    }
}