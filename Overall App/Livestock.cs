using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overall_App
{
    public class Livestock
    {
        public double amtWater { get; set; }
        public double dailyCost { get; set; }
        public double weight { get; set; }
        public int age { get; set; }
        public string color { get; set; }
        public Livestock(double amtWater, double dailyCost, double weight, int age, string color)
        {
            this.amtWater = amtWater;
            this.dailyCost = dailyCost;
            this.weight = weight;
            this.age = age;
            this.color = color;
        }
        public virtual string basicInfo()
        {
            return ("Amount of Water:" + "\t" + amtWater + "\r\n" + 
                "Daily Cost:" + "\t" + dailyCost + "\r\n" + 
                "Weight:" + "\t" + weight + "\r\n" + 
                "Age:" + "\t" + age + "\r\n" + 
                "Color:" + "\t" + color + "\r\n");
        }
        public virtual string getType()
        {
            return null;
        }
        public virtual double getProduce()
        {
            return 0;
        }
        public virtual double getDailyCost()
        {
            return 0;
        }
        public virtual double getWeight()
        {
            return 0;
        }
        public virtual double getWater()
        {
            return 0;
        }
        public virtual int getAge()
        {
            return 0;
        }
        public virtual string getColor()
        {
            return null;
        }
    }
}
