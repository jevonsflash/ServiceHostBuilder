using Castle.Windsor;
using ServiceHost.MyServices;

namespace ServiceHostBuilder.Sample
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("开始咖啡制作!");
            Initialize();
        }


        static void Initialize()
        {
            var containerBuilder = new WindsorContainer();
            var hostBuilder = new CoffieeServiceHostBuilder(containerBuilder)
                  .UseMilk(50)
                  .UseSuggar()
                  ;
            using (var host = hostBuilder.Build())
            {
                host.Run();
            }
        }
    }
}