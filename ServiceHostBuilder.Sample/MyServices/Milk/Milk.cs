using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHostBuilder.Sample.MyServices.Milk
{
    public class Milk
    {
        private readonly int quantity;

        public Milk(int quantity)
        {
            this.quantity = quantity;
        }
        public void Prepare()
        {
            Console.WriteLine($"准备{quantity}ml牛奶");
        }

        public void Add()
        {
            Console.WriteLine("咖啡里加入了一些牛奶");
        }
    }
}
