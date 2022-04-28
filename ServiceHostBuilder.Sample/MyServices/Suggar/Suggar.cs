using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHostBuilder.Sample.MyServices.Suggar
{
    public class Suggar
    {
        public void Prepare()
        {
            Console.WriteLine("准备一些糖");
        }
        public void Add()
        {
            Console.WriteLine("咖啡里加入了一些糖");
        }
    }
}
