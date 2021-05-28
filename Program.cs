using System;
using System.Collections.Generic;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops =
                           new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string inputInfo = Console.ReadLine();

                if (inputInfo == "Revision")
                {
                    foreach (var itemShop in shops)
                    {
                        string currShop = itemShop.Key; //key ->shopName
                        var currNestedDict = itemShop.Value;
                        Console.WriteLine($"{currShop}->");

                        foreach (var item in currNestedDict)
                        {
                            Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                        }
                    }

                    break;
                }

                string[] data = inputInfo.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = data[0];
                string product = data[1];
                double price = double.Parse(data[2]);

                if (shops.ContainsKey(shop))
                {
                    if (shops[shop].ContainsKey(product))
                    {
                        continue;
                    }
                    else //does not contain keyProduct and add it
                    {                        
                        shops[shop].Add(product, price); 
                    }
                }
                else // shops does not contain keyShop
                {
                    shops.Add(shop, new Dictionary<string, double>());
                    shops[shop].Add(product, price);
                }               
            }                
        }
    }
}
