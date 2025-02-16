using DesignPattern.SimpleFactory.Shop;

Console.WriteLine("Enter the exercise Id:");
int exerciseId = int.Parse(Console.ReadLine());

switch (exerciseId)
{
    case 1:
        // Simple Factory

        Shop.BuyProduct();
        break;
    case 2:
        // Factory Method
        break;
    case 3:
        // Abstract Factory
        break;
    case 4:
        // Builder
        break;
    case 5:
        // Prototype
        break;
    case 6:
        // Singleton
        break;
    case 7:
        // Adapter
        break;
    case 8:
        // Bridge
        break;
    case 9:
        // Composite
        break;
    case 10:
        // Decorator
        break;
    case 11:
        // Facade
        break;
    case 12:
        // Flyweight
        break;
    case 13:
        // Proxy
        break;
    case 14:
        // Chain of Responsibility
        break;
    case 15:
        // Command
        break;
    case 16:
        // Interpreter
        break;
    case 17:
        // Iterator
        break;
    case 18:
        // Mediator
        break;
    case 19:
        // Memento
        break;
    case 20:
        // Observer
        break;
    case 21:
        // State
        break;
    case 22:
        // Strategy
        break;
    case 23:
        // Template Method
        break;
    case 24:
        // Visitor
        break;
    default:
        Console.WriteLine("Invalid exercise Id");
        break;
}