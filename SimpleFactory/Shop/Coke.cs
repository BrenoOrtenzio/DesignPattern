namespace DesignPattern.SimpleFactory.Shop
{
    public class Coke : Product
    {
        public Coke()
        {
            Name = "Coke";
            Price = 5.50m;
            ExpirationDate = DateTime.Now.AddDays(365);
            Description = "A refreshing drink";
            Category = "Drink";
            Quantity = 0;
        }
    }
}
