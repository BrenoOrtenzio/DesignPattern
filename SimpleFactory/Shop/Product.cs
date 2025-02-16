namespace DesignPattern.SimpleFactory.Shop
{
    public abstract class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}, Expiration Date: {ExpirationDate}, Description: {Description}, Category: {Category}\n";
        }

        public string Resume() => $"Name: {Name}, Price: {Price}, Quantity: {Quantity}, Item Total: {CalculateTotalItemPrice()}\n";

        public string AddItem(int quantity)
        {
            Quantity += quantity;
            return $"Added {quantity} {this.Name}(s) to the cart";
        }        

        public string Remove(int quantity)
        {
            Quantity -= quantity;
            return $"Removed {quantity} {this.Name}(s) from the cart";
        }

        public decimal CalculateTotalItemPrice() => Quantity * Price;
    }
}
