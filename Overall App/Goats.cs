using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overall_App
{
    class Goats: Livestock
    {
        public double amtMilk { get; set; }
        public Goats(double amtWater, double dailyCost, double weight, int age, string color, double amtMilk) : base(amtWater, dailyCost, weight, age, color)
        {
            this.amtMilk = amtMilk;
        }
        public override string basicInfo()
        {
            return base.basicInfo() +
                "Amount of Milk:" + "\t" + amtMilk + "\r\n" +
                "Type:" + "\t" + getType();
        }
        public override string getType()
        {
            return "Goat";
        }
        public override double getProduce()
        {
            return amtMilk;
        }
        public override double getDailyCost()
        {
            return dailyCost;
        }
        public override double getWeight()
        {
            return weight;
        }
        public override double getWater()
        {
            return amtWater;
        }
        public override int getAge()
        {
            return age;
        }
        public override string getColor()
        {
            return color;
        }
    }
}
