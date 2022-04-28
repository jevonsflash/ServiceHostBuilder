using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Windsor;


namespace ServiceHostBuilder
{
    public class ServiceHost : IServiceHost
    {
        private readonly List<Action<IWindsorContainer>> _disposeActions;
        private readonly List<Action<IWindsorContainer>> _runActions;

        public ServiceHost(List<Action<IWindsorContainer>> runActions = null, List<Action<IWindsorContainer>> disposeActions = null)
        {
            _disposeActions = disposeActions ?? new List<Action<IWindsorContainer>>();
            _runActions = runActions ?? new List<Action<IWindsorContainer>>();
        }

        public IWindsorContainer Container { get; set; }

        public void Dispose()
        {
            if (_disposeActions.Any())
                _disposeActions.ForEach(x => { x(Container); });
            Container.Dispose();
        }

        public void DisposeAction(Action<IWindsorContainer> action)
        {
            _disposeActions.Add(action);
        }

        public void RunAction(Action<IWindsorContainer> action)
        {
            _runActions.Add(action);
        }

        public void Run()
        {
            if (_runActions.Any())
                _runActions.ForEach(x => { x(Container); });
        }
    }
}