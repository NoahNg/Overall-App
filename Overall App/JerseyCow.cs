using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overall_App
{
    class JerseyCow: Cows
    {
        //public double amtMilk { get; set; }
        public JerseyCow(double amtWater, double dailyCost, double weight, int age, string color, double amtMilk, bool isJersey) : base (amtWater, dailyCost, weight, age, color, amtMilk, isJersey)
        {
        }
        
        public override string getType()
        {
            return "Jersey Cow";
        }
    

    }
}
