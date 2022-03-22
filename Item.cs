using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    internal class Item
    {
        private string _name;
        private float _price;

        public static List<Item> ItemList = new List<Item>();
        public string Name { get { return _name; } set { _name = value; } }
        public float Price { get { return _price; } set { _price = value; } }
        public Item(string name, float price)
        {
            _name = name;
            _price = price;
        }
        public static List<Item> GetItemData()
        {
            string CurrentDirectory = Environment.CurrentDirectory;
            string path = @"/Data/ItemData.json";
            string fullPath = CurrentDirectory + path;
            StreamReader r = new StreamReader(fullPath);
            string jsonString = r.ReadToEnd();
            List<Item> ItemList = JsonConvert.DeserializeObject<List<Item>>(jsonString);
            return ItemList;
        }
    }
}
