using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    internal class Cart
    {
        public static float cartTotal;
        public static List<Item> cartContent = new List<Item>();
        
        public static void ShowCart()
        {
            string menu = "╔═════════════════════════════════╗\n" +
                          "║          Cart Content           ║\n";
            int index = 1;
            foreach (Item item in cartContent)
            {
                menu += String.Format("║ {0,-2} - {1,-12} {2,10} $  ║\n", index, item.Name, item.Price);
                index++;
            }
            menu += "║                                 ║\n";
            menu += String.Format("║    Total        {0,12} $  ║\n", cartTotal.ToString("0.00"));
            menu += "║                                 ║\n" +
                    "╚═════════════════════════════════╝\n";
            Console.WriteLine(menu);
        }
        public static void CartMenu()
        {
            int userSelection;
            bool isFormatOK = false;
            int input = 0;
            Console.WriteLine("1: Proceed to payment. 2: Remove content from cart. 3: Back to Shop");
         while (!isFormatOK)
         {
             try 
             { 
                 do input = int.Parse(Console.ReadLine());
                 while (input > 4 && input < 0);
                 isFormatOK = true;
             }
             catch (Exception ex)
             {
                    Console.WriteLine("Entré incorrecte.");
             }
         }       
                switch (input)
                {
                    case 1:
                    Console.Clear();
                    CartPayment();
                    Console.ReadKey();
                        break;
                    case 2:
                    Console.WriteLine("Choose an item to remove from the cart.");
                    userSelection = CartUserInput();
                    Console.WriteLine($"{cartContent[userSelection].Name} has been removed from your cart.");
                    RemoveFromCart(userSelection);
                    Console.ReadKey();
                        
                        break;
                    case 3:
                        Console.Clear();
                        Menu.ShowMenu();
                        Menu.ShopMenuChoice();
                    break;
                }
        }
        public static float CartTotal()
        {
            float total = 0;
            foreach (Item item in cartContent)
            {
                total += item.Price;
            }
            return total;
        }
        public static float CartTaxes()
        {
            float cartTaxes = CartTotal() / 100 * 15;
            return cartTaxes;
        }
        public static void CartPayment()
        {
                string menu = "╔═════════════════════════════════╗\n" +
                              "║             Payment             ║\n";
                int index = 1;
                foreach (Item item in cartContent)
                {
                    menu += String.Format("║ {0,-2} - {1,-12} {2,10} $  ║\n", index, item.Name, item.Price);
                    index++;
                }
                menu += "║                                 ║\n";
                menu += String.Format("║    Sub total        {0,8} $  ║\n", cartTotal.ToString("0.00"));
                menu += String.Format("║    Taxes        {0,12} $  ║\n", CartTaxes().ToString("0.00"));
                menu += String.Format("║    Total       {0,13} $  ║\n", cartTotal.ToString("0.00")+CartTaxes().ToString("0.00"));
                menu += "║                                 ║\n" +
                        "╚═════════════════════════════════╝\n";
                Console.WriteLine(menu);
        }
        public static int CartUserInput()
        {   int input;
            do input = int.Parse(Console.ReadLine());
            while (input > cartContent.Count && input < 0);
            return input-1;
        }
        public static void AddToCart(Item item)
        {
            cartContent.Add(item);
        }
        public static void RemoveFromCart(int position)
        {
            cartContent.RemoveAt(position);
        }
    }
}
