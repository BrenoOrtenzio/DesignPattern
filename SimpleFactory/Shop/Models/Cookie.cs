using System.Xml.Linq;

namespace DesignPattern.SimpleFactory.Shop.Models
{
    class Cookie : Product
    {
        public Cookie() 
        {
            Name = "Cookie";
            Price = 12.50m;
            ExpirationDate = DateTime.Now.AddDays(60);
            Description = "A delicious, baked snack made from flour, sugar, butter, and other ingredients such as chocolate chips, nuts, or dried fruits. " +
                "Cookies come in various flavors and textures, from soft and chewy to crispy and crunchy. Perfect for a quick treat, dessert, or pairing with milk or coffee.";
            Category = "Snacks";
            Quantity = 0;
        }
    }
}
