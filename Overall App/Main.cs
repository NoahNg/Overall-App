using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Overall_App
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Database.GoForIt();
            read();
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        Dictionary<int, Livestock> Animal = Database.Animal;
        Dictionary<string, double> Prices = Database.Prices;
        public double goatMP = 0;
        public double cowMP = 0;
        public double sheepWP = 0;
        public double waterPrice = 0;
        public double tax = 0;
        public double jsCowTax = 0;
        private void read()//read all the prices
        {
            try
            {
                foreach (KeyValuePair<string, double> i in Prices)
                {
                    if (i.Key == "Goat milk price")
                    {
                        goatMP = i.Value;
                    }
                    if (i.Key == "Cow milk price")
                    {
                        cowMP = i.Value;
                    }
                    if (i.Key == "Sheep wool price")
                    {
                        sheepWP = i.Value;
                    }
                    if (i.Key == "Water price")
                    {
                        waterPrice = i.Value;
                    }
                    if (i.Key == "Tax")
                    {
                        tax = i.Value;
                    }
                    if (i.Key == "Jersey cow tax")
                    {
                        jsCowTax = i.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private double getAllProfit()//2. Display the total profit of the farm per day
        {
            double allProfit = 0;
            try
            {
                foreach (KeyValuePair<int, Livestock> i in Animal)
                {
                    double typePrice = cowMP;
                    if (i.Value.getType() == "Goat")
                    {
                        typePrice = goatMP;
                    }
                    if (i.Value.getType() == "Sheep")
                    {
                        typePrice = sheepWP;
                    }
                    //total profit = produce - daily cost - water (then minus all tax per day later because it has been calculated in r3)
                    allProfit += i.Value.getProduce() * typePrice - i.Value.getDailyCost() - i.Value.getWater() * waterPrice;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return allProfit - getAllTax() / 30;
        }
        private double getAllTax()//3. Display the total tax paid to the government per month
        {
            double allTax = 0;
            try
            {
                foreach (KeyValuePair<int, Livestock> i in Animal)
                {
                    if (i.Value.getType() == "Jersey Cow")//Calculate the tax for jersey cows
                    {
                        //tax = weight * tax * 30
                        allTax += i.Value.getWeight() * jsCowTax * 30;
                    }
                    else
                    {
                        allTax += i.Value.getWeight() * tax * 30;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return allTax;
        }
        private double getAllMilk()//4. Display the total amount of milk per day for goats and cows
        {
            double allMilk = 0;
            try
            {
                foreach (KeyValuePair<int, Livestock> i in Animal)
                {
                    if (i.Value.getType() != "Sheep")//Dog has no produce so don't have to exclude
                    {
                        allMilk += i.Value.getProduce();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return allMilk;
        }
        private double getAvgAge()//5. Display the average age of all animal farms (Dogs excluded)
        {
            double allAge = 0;
            int count = 0;
            try
            {
                foreach (KeyValuePair<int, Livestock> i in Animal)
                {
                    if (i.Value.getType() != "Dog")//Exclude dogs
                    {
                        allAge += i.Value.getAge();
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (count == 0)//error handling
            {
                MessageBox.Show("Error! Divided by zero");
                Application.Restart();
            }
            return allAge / count;
        }
        private double avgProfit()//6. Display the average profit of "Goats and Cows" vs Sheeps
        {
            double goatAndCow = 0;
            int countGnC = 0;
            double sheep = 0;
            int countSheep = 0;
            foreach (KeyValuePair<int, Livestock> i in Animal)
            {
                //avg profit for Goats and Cows = Cow Milk + Goat Milk (already calculated in r4) - Daily Cost - Tax - Water
                if (i.Value.getType() == "Jersey Cow" || i.Value.getType() == "Cow" || i.Value.getType() == "Goat")
                {
                    //calculate profit for Goats and Cows
                    double taxType = tax;
                    if (i.Value.getType() == "Jersey Cow")
                    {
                        taxType = jsCowTax;
                    }
                    goatAndCow += -i.Value.getDailyCost() - i.Value.getWeight() * taxType - i.Value.getWater() * waterPrice;
                    countGnC++;
                } 
                if (i.Value.getType() == "Sheep")//calculate profit for sheeps
                {
                    //avg profit for Sheep = Sheep Wool - Daily Cost - Tax - Water
                    sheep += i.Value.getProduce() * sheepWP - i.Value.getDailyCost() - i.Value.getWeight() * tax -
                        i.Value.getWater() * waterPrice;
                    countSheep++;
                }
            }
            goatAndCow += getAllMilk();
            if (countGnC == 0 || countSheep == 0)//error handling
            {
                MessageBox.Show("Error! Divided by zero");
                Application.Restart();
            }
            //Avg profit = (Goat and Cow profit avg + Sheep profit avg)/(number of goats, cows and sheeps)
            return (goatAndCow / countGnC + sheep / countSheep) / (countGnC + countSheep);
        }
        private string dogCostRatio()//7. Display the ratio of Dogs' cost compared to total cost
        {
            double dogCost = 0;
            double totalCost = 0;
            try
            {
                foreach (KeyValuePair<int, Livestock> i in Animal)
                {
                    if (i.Value.getType() == "Dog")
                    {
                        //dog cost = Water + Daily Cost
                        dogCost += i.Value.getWater() * waterPrice + i.Value.getDailyCost();
                    }
                    totalCost += i.Value.getWater() * waterPrice + i.Value.getDailyCost();//total cost for the whole farm
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            var gcd = GCD(Convert.ToInt32(dogCost), Convert.ToInt32(totalCost));//find the greates common denominator
            if (gcd == 0)//error handling
            {
                MessageBox.Show("Error! Divided by zero");
                Application.Restart();
            }
            return string.Format("{0}:{1}", Convert.ToInt32(dogCost) / gcd, Convert.ToInt32(totalCost) / gcd);
        }
        Dictionary<int, double> animalProfit = new Dictionary<int, double>();
        private void sortProfit()//8. Generate a file with ID and sort by profit
        {
            profitPerAnimal();
            string fileName = @"E:\Classes\COMP609 - App Dev\Overall App\q8.txt";
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                // Create a new file     
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine("ID\t" + "Profitability");
                    while (animalProfit.Count != 0)
                    {
                        double max = double.MinValue;
                        int key = 0;
                        foreach (KeyValuePair<int, double> i in animalProfit)
                        {
                            if (i.Value > max)
                            {
                                max = i.Value;
                                key = i.Key;
                            }
                        }
                        sw.WriteLine(key + "\t$" + max.ToString("0.##"));
                        animalProfit.Remove(key);
                    }
                }
                MessageBox.Show("File created! \n" + fileName);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
        private void profitPerAnimal()//calculate the profit for each animal in the farm
        {
            try
            {
                foreach (KeyValuePair<int, Livestock> i in Animal)
                {
                    if (i.Value.getType() != "Dog")
                    {
                        double price = cowMP;
                        double taxType = tax;
                        if (i.Value.getType() == "Jersey Cow")//Jersey Cow
                        {
                            taxType = jsCowTax;
                        }
                        if (i.Value.getType() == "Goat")//Goat
                        {
                            price = goatMP;
                        }
                        if (i.Value.getType() == "Sheep")//Sheep
                        {
                            price = sheepWP;
                        }
                        //profit = produce (milk and wool) - daily cost - water - tax (weight * tax type)
                        double profit = i.Value.getProduce() * price - i.Value.getDailyCost() - i.Value.getWater() * waterPrice -
                                i.Value.getWeight() * taxType;
                        animalProfit.Add(i.Key, profit);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int GCD(int a, int b)////Greatest common denominator
        {
            try
            {
                while (a != 0 && b != 0)
                {
                    if (a > b)
                        a %= b;
                    else
                        b %= a;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (a == 0)
                return b;
            else
                return a;
        }
        private string colorRatio()//9. Display the ratio of livestock with the color red
        {
            int count = 0;
            int red = 0;
            try
            {
                foreach (KeyValuePair<int, Livestock> i in Animal)
                {
                    count++;
                    if (i.Value.getColor().ToLower() == "red")//Count livestocks with red color
                    {
                        red++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            var gcd = GCD(red, count);
            if (gcd == 0)//error handling
            {
                MessageBox.Show("Error! Divided by zero");
                Application.Restart();
            }
            return string.Format("{0}:{1}", red / gcd, count / gcd);
        }
        private double jerseyTax()//10. Display the total tax paid for Jersey Cows
        {
            double tax = 0;
            try
            {
                foreach (KeyValuePair<int, Livestock> i in Animal)
                {
                    if (i.Value.getType() == "Jersey Cow")
                    {
                        //tax = weight * jersey cow tax * 30
                        tax += i.Value.getWeight() * jsCowTax * 30;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tax;
        }
        private void thresholdAge()//11. Display the ratio of livestock with age above a threshold
        {
            int count = 0;
            int age = 0;
            int maxAge = int.MinValue;
            if (!string.IsNullOrEmpty(ageBox.Text))
            {
                if (!int.TryParse(ageBox.Text, out _))
                {
                    MessageBox.Show("Age must be a number");
                    return;
                }
                foreach (KeyValuePair<int, Livestock> i in Animal)
                {
                    if (i.Value.getAge() > maxAge)//find the maximum age for error handling
                    {
                        maxAge = i.Value.getAge();
                    }
                    count++;
                    if (i.Value.getAge() > int.Parse(ageBox.Text))//Count livestocks with age above threshold
                    {
                        age++;
                    }
                }
                if (int.Parse(ageBox.Text) > maxAge)//error handling
                {
                    MessageBox.Show("There are no animals whose age is above this threshold.");
                    return;
                }
                var gcd = GCD(age, count);
                if (gcd == 0)//error handling
                {
                    MessageBox.Show("Error! Divided by zero");
                    return;
                }
                reportBox.Text += string.Format("{0}:{1}", age / gcd, count / gcd);
            } else
            {
                MessageBox.Show("Please enter an age threshold.");
                return;  
            }     
        }
        private double jerseyProfit()//12. Display the total profit of all Jersey Cows
        {
            double profit = 0;
            try
            {
                foreach (KeyValuePair<int, Livestock> i in Animal)
                {
                    //Profit = Milk - Water - Daily Cost (then minus tax later because it has been calculated in r10)
                    if (i.Value.getType() == "Jersey Cow")
                    {
                        profit += i.Value.getProduce() * cowMP - i.Value.getWater() * waterPrice - i.Value.getDailyCost();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return profit - jerseyTax()/30;
        }
        private void displayInfo_Click(object sender, EventArgs e)//1. Display the info associated with an animal farm
        {
            try
            {
                if (string.IsNullOrEmpty(IDBox.Text))//error handling if there's no ID
                {
                    MessageBox.Show("Please enter an ID.");
                    return;
                }
                else
                {
                    infoBox.Clear();
                    if (!int.TryParse(IDBox.Text, out _))//error handling if ID is string
                    {
                        MessageBox.Show("ID must be a number.");
                        return;
                    }
                    int key = Int32.Parse(IDBox.Text);
                    if (Animal.ContainsKey(key))//If there exists that ID in the hash table, then display the info
                    {
                        String record = Animal[key].basicInfo();
                        infoBox.Text += record;
                    }
                    else { MessageBox.Show("ID doesn't exist. Please enter it again."); }//Error handling for an ID that doesn't exist
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message); 
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            reportBox.Clear();
            if (!String.IsNullOrEmpty(reportNo.Text))
            {
                if (!int.TryParse(reportNo.Text, out _))
                {
                    MessageBox.Show("Report number must be an integer.");
                    return;
                }
                if (int.Parse(reportNo.Text) == 2)
                {
                    reportBox.Text += "$" + getAllProfit().ToString("#.##");
                }
                if (int.Parse(reportNo.Text) == 3)
                {
                    reportBox.Text += "$" + getAllTax().ToString("#.##");
                }
                if (int.Parse(reportNo.Text) == 4)
                {
                    reportBox.Text += getAllMilk().ToString("#.##") + " " + "litre";
                }
                if (int.Parse(reportNo.Text) == 5)
                {
                    reportBox.Text += getAvgAge().ToString("#") + " " + "years old";
                }
                if (int.Parse(reportNo.Text) == 6)
                {
                    reportBox.Text += "$" + avgProfit().ToString("#.##");
                }
                if (int.Parse(reportNo.Text) == 7)
                {
                    reportBox.Text += dogCostRatio();
                }
                if (int.Parse(reportNo.Text) == 8)
                {
                    sortProfit();
                }
                if (int.Parse(reportNo.Text) == 9)
                {
                    reportBox.Text += colorRatio();
                }
                if (int.Parse(reportNo.Text) == 10)
                {
                    reportBox.Text += "$" + jerseyTax().ToString("#.##");
                }
                if (int.Parse(reportNo.Text) == 11)
                {
                    thresholdAge();
                }
                if (int.Parse(reportNo.Text) == 12)
                {
                    reportBox.Text += "$" + jerseyProfit().ToString("#.##");
                }
                if (int.Parse(reportNo.Text) > 12 || int.Parse(reportNo.Text) < 2)
                {
                    MessageBox.Show("Report number is from 2-12");
                } 
            } else 
            { 
                MessageBox.Show("Please enter a report number.");
                return;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
