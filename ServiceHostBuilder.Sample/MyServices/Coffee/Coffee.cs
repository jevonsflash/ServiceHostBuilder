using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHostBuilder.Sample.MyServices.Coffee
{
    public class Coffee
    {
        public Coffee()
        {

        }

        public void Init()
        {
            Console.WriteLine("准备一些咖啡豆");
        }



        public void Start()
        {
            Console.WriteLine("磨好的咖啡粉装入手柄压平，装入咖啡机");
            Console.WriteLine("萃取浓缩咖啡液");
        }
    }
}
