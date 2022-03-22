namespace ShoppingCart
{

    public class Controller
    {
        public static bool shopInProgress = false;
        
        static void Main(string[] args)
        {
            Item.ItemList = Item.GetItemData();
            while (!shopInProgress)
            {
                Cart.cartTotal = Cart.CartTotal();
                Console.Clear();
                Menu.ShowMenu();
                Menu.ShopMenuChoice();
            }
        }
    }
}