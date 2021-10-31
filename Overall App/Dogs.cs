using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overall_App
{
    class Dogs: Livestock
    {
        public Dogs(double amtWater, double dailyCost, double weight, int age, string color) : base(amtWater, dailyCost, weight, age, color)
        {
        }
        public override string basicInfo()
        {
            return base.basicInfo() +
                "Type:" + "\t" + getType();
        }
        public override string getType()
        {
            return "Dog";
        }
        public override double getDailyCost()
        {
            return dailyCost;
        }
        public override double getWater()
        {
            return amtWater;
        }
        public override string getColor()
        {
            return color;
        }
        public override int getAge()
        {
            return age;
        }
    }
}
