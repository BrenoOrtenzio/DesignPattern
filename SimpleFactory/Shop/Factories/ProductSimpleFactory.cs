using DesignPattern.Properties;
using DesignPattern.SimpleFactory.Shop.Models;

namespace DesignPattern.SimpleFactory.Shop.Factories
{
    public class ProductSimpleFactory
    {
        public Product CreateProduct(string productName)
        {
            switch (productName)
            {
                case "Coke":
                    return new Coke();
                case "Cookie":
                    return new Cookie();
                default:
                    throw new Exception(Resources.ProductNotFoundException);
            }
        }
    }
}
