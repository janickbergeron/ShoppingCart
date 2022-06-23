using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Menu
    {
        public static void ShowMenu()
        {
            string menu = "╔═════════════════════════════════╗\n" +
                          "║          Shop Content           ║\n";
            int index = 1;
            foreach (Item item in Item.ItemList)
            {
                menu += String.Format("║ {0,-2} - {1,-12} {2,10} $  ║\n", index, item.Name, item.Price);
                index++;
            }
            menu += "║                                 ║\n" +
                    "╚═════════════════════════════════╝\n";
            Console.WriteLine(menu);
            //Console.WriteLine("Choose an item to add to cart.");
            //Cart.AddToCart(Item.ItemList[ShopUserInput()]);
        }
        public static void ShopMenuChoice()
        {
            int input = 0;
            int selectedItem;
            bool isFormatOK = false;
            Console.WriteLine("1: Add items to cart. 2: View cart content. 3: Proceed to payment.");
            while (!isFormatOK)
            {
                try
                {
                    do input = int.Parse(Console.ReadLine());
                    while (input > 4 && input < 0);
                    isFormatOK = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Incorrect Entry.");
                }
            }
            switch (input)
            {
                case 1:
                    Console.Clear();
                    ShowMenu();
                    Console.WriteLine("Enter the item number.");
                    selectedItem = ShopUserInput();
                    Cart.AddToCart(Item.ItemList[selectedItem-1]);
                    Console.WriteLine($"{Item.ItemList[selectedItem-1].Name} has been added to your cart.");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Cart.ShowCart();
                    Cart.CartMenu();
                    break;
                case 3:
                    Console.Clear();
                    Cart.CartPayment();
                    Console.ReadKey();
                    break;
            }
        }
    
        public static int ShopUserInput()
        {
            int input = 0;
            bool isFormatOK = false;
            while (!isFormatOK)
            {

                try
                {
                do input = int.Parse(Console.ReadLine());
                while (input > Item.ItemList.Count && input < 0);
                isFormatOK = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Entré incorrecte."); 
                }
            }
            return input;
        }
    }
}
