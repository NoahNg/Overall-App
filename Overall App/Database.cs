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
    class Database
    {
        public static Dictionary<int, Livestock> Animal = new Dictionary<int, Livestock>();
        public static Dictionary<string, double> Prices = new Dictionary<string, double>(); 
        public Database()
        {
        }
        public static void GoForIt()
        {
            try
            {
                String connStr = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = E:\Classes\COMP609 - App Dev\FarmInfomation.accdb; Persist Security Info = False";
                String[] Animals = { "Cows", "Dogs", "Sheep", "Goats", "Rates and prices" };//create an array read the database
                for (int i = 0; i < Animals.Length; i++)//go through every table
                {
                    String strSQL = "SELECT * FROM [" + Animals[i] + "];";
                    using (OleDbConnection connection = new OleDbConnection(connStr))
                    {
                        OleDbCommand command = new OleDbCommand(strSQL, connection);
                        connection.Open();
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //create the variables to insert into the hash table
                                int id = 0;
                                double amtWater = 0;
                                double dailyCost = 0;
                                double weight = 0;
                                int age = 0;
                                string color = null;
                                double amtMilk = 0;
                                double amtWool = 0;
                                bool isJersey = false;
                                //read every column
                                for (int e = 0; e < reader.FieldCount; e++)
                                {
                                    if (reader.GetName(e) == "ID")//Read ID
                                    {
                                        id = Int32.Parse(reader.GetValue(e).ToString());
                                    }
                                    if (reader.GetName(e) == "Amount of water")//Read amount of water
                                    {
                                        amtWater = double.Parse(reader.GetValue(e).ToString());
                                    }
                                    if (reader.GetName(e) == "Daily cost")//Read daily cost
                                    {
                                        dailyCost = double.Parse(reader.GetValue(e).ToString());
                                    }
                                    if (reader.GetName(e) == "Weight")//Read weight
                                    {
                                        weight = double.Parse(reader.GetValue(e).ToString());
                                    }
                                    if (reader.GetName(e) == "Age")//Read age
                                    {
                                        age = Int32.Parse(reader.GetValue(e).ToString());
                                    }
                                    if (reader.GetName(e) == "Color")//Read color
                                    {
                                        color = reader.GetValue(e).ToString();
                                    }
                                    if (reader.GetName(e) == "Amount of milk")//read amount of milk
                                    {
                                        amtMilk = double.Parse(reader.GetValue(e).ToString());
                                    }
                                    if (reader.GetName(e) == "Amount of wool")//read amount of wool
                                    {
                                        amtWool = double.Parse(reader.GetValue(e).ToString());
                                    }
                                    if (reader.GetName(e) == "Is jersey")//read if the cow is jersey
                                    {
                                        isJersey = bool.Parse(reader.GetValue(e).ToString());
                                    }
                                    //Read prices
                                    if (reader.GetName(e).Contains("price") || reader.GetName(e).ToLower().Contains("tax"))
                                    {
                                        Prices.Add(reader.GetName(e), double.Parse(reader.GetValue(e).ToString()));
                                    }
                                }//reading ends

                                //insert the objects into the hash table
                                if (Animals[i] == "Cows")//if the type is cow then see if it's jersey
                                {
                                    if (isJersey)
                                    {
                                        Animal.Add(id, new JerseyCow(amtWater, dailyCost, weight, age, color, amtMilk, isJersey));
                                    }
                                    else
                                    {
                                        Animal.Add(id, new Cows(amtWater, dailyCost, weight, age, color, amtMilk, isJersey));
                                    }
                                }
                                if (Animals[i] == "Dogs")//type dog
                                {
                                    Animal.Add(id, new Dogs(amtWater, dailyCost, weight, age, color));
                                }
                                if (Animals[i] == "Sheep")//type sheep
                                {
                                    Animal.Add(id, new Sheep(amtWater, dailyCost, weight, age, color, amtWool));
                                }
                                if (Animals[i] == "Goats")//type goat
                                {
                                    Animal.Add(id, new Goats(amtWater, dailyCost, weight, age, color, amtMilk));
                                }//insertion ends
                            }
                            connection.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
