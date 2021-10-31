using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overall_App
{
    class Sheep: Livestock
    {
        public double amtWool { get; set; }
        public Sheep (double amtWater, double dailyCost, double weight, int age, string color, double amtWool) : base(amtWater, dailyCost, weight, age, color)
        {
            this.amtWool = amtWool;
        }
        public override string basicInfo()
        {
            return base.basicInfo() +
                "Amount of Wool:" + "\t" + amtWool + "\r\n" +
                "Type:" + "\t" + getType();
        }
        public override string getType()
        {
            return "Sheep";
        }
        public override double getProduce()
        {
            return amtWool;
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
