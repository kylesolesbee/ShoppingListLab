//Kyle Solesbee 10/11/23
//Shopping List Lab

namespace ShoppingListLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> menu = new Dictionary<string, decimal>
            {
                { "apple", 0.99m },
                { "banana", 0.59m },
                { "cauliflower", 1.59m },
                { "dragonfruit", 2.19m },
                { "elderberry", 1.79m },
                { "figs", 2.09m },
                { "grapefruit", 1.99m },
                { "honeydew", 3.49m }
            };

            List<string> shoppingList = new List<string>();

            decimal totalPrice = 0;
            decimal mostExpensivePrice = decimal.MinValue;
            decimal leastExpensivePrice = decimal.MaxValue;

            string input;
            string continueShopping;
            string mostExpensiveItem = "";
            string leastExpensiveItem = "";

            Console.WriteLine("Welcome to Chirpus Market!\n");
            Console.WriteLine(string.Format("{0,-15} {1,-10}", "Item", "Price"));
            Console.WriteLine(new string('=', 30));

            foreach(var item in menu)
            {
                Console.WriteLine(string.Format("{0,-15} ${1:F2}", item.Key, item.Value));
            }

            Console.WriteLine();

            do
            {
                input = GetUserInput("What item would you like to order? ").ToLower();

                if(menu.ContainsKey(input))
                {
                    shoppingList.Add(input);
                    totalPrice += menu[input];

                    if(menu[input] > mostExpensivePrice)
                    {
                       mostExpensivePrice = menu[input];
                       mostExpensiveItem = input;
                    }
                    if (menu[input] < leastExpensivePrice)
                    {
                        leastExpensivePrice = menu[input];
                        leastExpensiveItem = input;
                    }
                    Console.WriteLine($"Adding {input} to cart at ${menu[input]:F2}\n");
                }
                else
                {
                    Console.WriteLine("Sorry, we don't have those. Please try again.\n");
                }

                do
                {
                    continueShopping = GetUserInput("Would you like to order anything else (y/n)? ").ToLower();

                }while (continueShopping != "y" && continueShopping != "n");

            }while (continueShopping == "y");

            Console.WriteLine("\nThanks for your order!");
            Console.WriteLine("Here's what you got:");

            shoppingList.Sort((item1, item2) => menu[item1].CompareTo(menu[item2]));

            foreach(var item in shoppingList)
            {
                Console.WriteLine(string.Format("{0,-15} ${1:F2}", item, menu[item]));
            }

                Console.WriteLine($"Total price for your order was ${totalPrice:F2}");
                Console.WriteLine($"Most expensive item ordered: {mostExpensiveItem} at ${mostExpensivePrice:F2}");
                Console.WriteLine($"Least expensive item ordered: {leastExpensiveItem} at ${leastExpensivePrice:F2}");
        }

        //This was a validation method I was trying to get to work.
        //I was having some issues with this and maybe I'll come back to it

        //public static string GetValidInput(string message, IEnumerable<string> validOptions)
        //{
        //    string input;
        //    bool isValid = false;

        //    do
        //    {
        //        input = GetUserInput(message).ToLower();

        //        if (validOptions.Contains(input))
        //        {
        //            isValid = true;
        //        }
        //        else
        //        {
        //            Console.WriteLine("ERROR! Not valid input, try again.");
        //        }
        //    } while(!isValid);

        //    return input;
        //}

        public static string GetUserInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
