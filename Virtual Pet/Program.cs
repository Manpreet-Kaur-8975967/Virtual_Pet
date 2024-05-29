using System;
using System.Threading;

class VirtualPet
{
    private string name;
    private string type;
    private int hunger;
    private int happiness;
    private int health;

    public VirtualPet(string name, string type)
    {
        this.name = name;
        this.type = type;
        hunger = 5;
        happiness = 5;
        health = 5;
    }

    public void Feed()
    {
        hunger = Math.Max(hunger - 2, 1);
        health = Math.Min(health + 1, 10);
        Console.WriteLine($"{name} has been fed. Hunger: {hunger}, Health: {health}");
    }

    public void Play()
    {
        if (hunger > 7)
        {
            Console.WriteLine($"{name} is too hungry to play.");
        }
        else
        {
            happiness = Math.Min(happiness + 2, 10);
            hunger = Math.Min(hunger + 1, 10);
            Console.WriteLine($"{name} played and is happier now. Happiness: {happiness}, Hunger: {hunger}");
        }
    }

    public void Rest()
    {
        health = Math.Min(health + 2, 10);
        happiness = Math.Max(happiness - 1, 1);
        Console.WriteLine($"{name} is resting. Health: {health}, Happiness: {happiness}");
    }

    public void DisplayStats()
    {
        Console.WriteLine($"Pet Stats - Name: {name}, Type: {type}, Hunger: {hunger}, Happiness: {happiness}, Health: {health}");
    }

    public void TimePasses()
    {
        hunger = Math.Min(hunger + 1, 10);
        happiness = Math.Max(happiness - 1, 1);
        if (hunger > 8)
        {
            health = Math.Max(health - 1, 1);
            Console.WriteLine($"{name} is very hungry and losing health.");
        }
        if (happiness < 3)
        {
            health = Math.Max(health - 1, 1);
            Console.WriteLine($"{name} is unhappy and losing health.");
        }
    }

    public bool IsAlive()
    {
        return health > 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Virtual Pet Simulator!");
        Console.Write("Choose a pet type (e.g., cat, dog, rabbit): ");
        string petType = Console.ReadLine();
        Console.Write("Name your pet: ");
        string petName = Console.ReadLine();

        VirtualPet myPet = new VirtualPet(petName, petType);

        Console.WriteLine($"Welcome {myPet} the {petType}! Take good care of your new pet.");

        while (myPet.IsAlive())
        {
            Console.WriteLine("\nChoose an action: feed, play, rest, status, or quit");
            string action = Console.ReadLine().ToLower();

            switch (action)
            {
                case "feed":
                    myPet.Feed();
                    break;
                case "play":
                    myPet.Play();
                    break;
                case "rest":
                    myPet.Rest();
                    break;
                case "status":
                    myPet.DisplayStats();
                    break;
                case "quit":
                    return;
                default:
                    Console.WriteLine("Invalid action. Please choose feed, play, rest, status, or quit.");
                    break;
            }

            myPet.TimePasses();
            if (!myPet.IsAlive())
            {
                Console.WriteLine($"{myPet} has passed away. Game over.");
                break;
            }

            Thread.Sleep(1000); // Simulate time passing
        }
    }
}