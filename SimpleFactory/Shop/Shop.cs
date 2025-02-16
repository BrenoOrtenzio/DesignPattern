using DesignPattern.Properties;
using System.Reflection;

namespace DesignPattern.SimpleFactory.Shop
{
    public class Shop
    {
        public static void BuyProduct()
        {
            bool finished = true;
            ProductSimpleFactory factory = new ProductSimpleFactory();
            List<Product> productList = new List<Product>();
            string productListString = GetProductList();
            string errorMessage = string.Empty;

            while (finished)
            {
                try
                {
                    Console.WriteLine(string.Format(Resources.ProductEnterMessage, productListString));
                    string productName = Console.ReadLine();

                    if (!ValidateProductName(productName, out errorMessage))
                    {
                        Console.WriteLine(errorMessage);
                        continue;
                    }

                    if (!ChooseProduct(productName, ref factory, out Product product, out errorMessage))
                    {
                        Console.WriteLine(errorMessage);
                        continue;
                    }

                    productList.Add(product);

                    Console.WriteLine(Resources.FinishedPurchase);
                    finished = Console.ReadLine().Equals("N");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(Resources.RemoveAnItem);
            bool removeFinished = Console.ReadLine().Equals("Y");

            while (removeFinished)
            {
                Console.WriteLine(Resources.RemoveProduct);
                string productName = Console.ReadLine();

                if (!RemoveProduct(productName, ref productList, out errorMessage))
                {
                    Console.WriteLine(errorMessage);
                    continue;
                }

                Console.WriteLine(Resources.RemoveAnotherItem);
                removeFinished = Console.ReadLine().Equals("Y");
            }

            GetFinalListAndFinalPrice(productList, out string finalList);
            Console.WriteLine(finalList);
        }


        private static bool RemoveProduct(string productName, ref List<Product> productList, out string errorMessage)
        {
            if (productList.Any(x => x.Name.Equals(productName)))
            {
                Product removedProduct = productList.FirstOrDefault(x => x.Name.Equals(productName));

                Console.WriteLine(string.Format(Resources.RemoveQuantityItems, productName));

                if (!ValidateProductQuantity(Console.ReadLine(), out errorMessage, out int removedQuantity))
                    return false;

                if (removedQuantity > removedProduct.Quantity)
                    Console.WriteLine(string.Format(Resources.AmountExceedsAddedItems, removedProduct.Quantity));

                removedProduct.Remove(removedQuantity);

                if (removedProduct.Quantity <= 0)
                    productList.Remove(removedProduct);
            }
            else
            {
                errorMessage = Resources.ProductNotFound;
                return false;
            }

            return true;
        }

        private static bool ChooseProduct(string productName, ref ProductSimpleFactory factory, out Product product, out string errorMessage)
        {
            product = factory.CreateProduct(productName);

            Console.WriteLine($"Enter the quantity of {productName}: ");
            string quantityString = Console.ReadLine();

            if (!ValidateProductQuantity(quantityString, out errorMessage, out int quantity))
                return false;

            product.AddItem(quantity);

            return true;
        }

        private static void GetFinalListAndFinalPrice(List<Product> productList, out string finalListWithPrice)
        {
            finalListWithPrice = string.Empty;
            decimal finalPrice = 0;

            foreach (var product in productList)
            {
                finalListWithPrice = string.Concat(finalListWithPrice, product.Resume());
                finalPrice += product.CalculateTotalItemPrice();
            }

            finalListWithPrice = string.Concat(finalListWithPrice, string.Format(Resources.TotalPrice, finalPrice));
        }

        private static bool ValidateProductQuantity(string productQuantityString, out string errorMessage, out int quantity)
        {
            errorMessage = string.Empty;
            quantity = 0;

            if (!int.TryParse(productQuantityString, out quantity))
            {
                errorMessage = Resources.InvalidProductQuantity;
                return false;
            }

            return true;    
        }

        private static bool ValidateProductName(string productName, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(productName))
            {
                errorMessage = Resources.InvalidProductName;
                return false;
            }

            return true;
        }

        private static string GetProductList()
        {
            var subClasses = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Product)))
                .ToList();

            return subClasses.Aggregate(string.Empty, (current, product) => current + $"{product.Name}\n");
        }
    }
}
