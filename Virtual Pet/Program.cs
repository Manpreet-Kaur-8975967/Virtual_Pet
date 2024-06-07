using System;

namespace VirtualPetSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose a type of Pet:");
            Console.WriteLine("1. Cat");
            Console.WriteLine("2. Dog");
            Console.WriteLine("3. Rabbit");
            Console.WriteLine("User Input:");


            int petChoice = int.Parse(Console.ReadLine());
            string petType = "";

            switch (petChoice)
            {
                case 1:
                    petType = "Cat";
                    break;
                case 2:
                    petType = "Dog";
                    break;
                case 3:
                    petType = "Rabbit";
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please restart the application.");
                    return;
            }

            Console.WriteLine($"You have chosen a {petType}. What would you like to name your pet?");
            string petName = Console.ReadLine();
            Pet myPet = new Pet(petName);

            Console.WriteLine($"Welcome, {myPet.Name}! Let's take good care of him.");

            bool exit = false;
            
            while (!exit)
            {
                Console.WriteLine("\nMain Menu");
                Console.WriteLine($"1. Feed {myPet.Name}");
                Console.WriteLine($"2. Play with {myPet.Name}");
                Console.WriteLine($"3. Let {myPet.Name} Rest");
                Console.WriteLine($"4. Check {myPet.Name}’s Status");
                Console.WriteLine("5. Exit");
                Console.WriteLine("User Input:");

                int menuChoice = int.Parse(Console.ReadLine());

                switch (menuChoice)
                {
                    case 1:
                        myPet.Feed();
                        Console.WriteLine($"You fed {myPet.Name}. His hunger decreases, and health improves slightly.");
                        break;
                    case 2:
                        myPet.Play();
                        Console.WriteLine($"You played with {myPet.Name}. His happiness increases, but slightly increases hunger.");
                        break;
                    case 3:
                        myPet.Rest();
                        Console.WriteLine($"{myPet.Name} is resting. His health and happiness improve.");
                        break;
                    case 4:
                        myPet.CheckStatus();
                        break;
                    case 5:
                        exit = true;
                        Console.WriteLine($"Thank you for playing with {myPet.Name} Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option from the menu.");
                        break;
                }

                myPet.TimePasses();
                myPet.CheckCriticalStatus();
                Thread.Sleep(1000); // Simulate passage of time

            }
        }
    }

    class Pet
    {
        public string Name { get; private set; }
        public int Hunger { get; private set; }
        public int Happiness { get; private set; }
        public int Health { get; private set; }

        public Pet(string name)
        {
            Name = name;
            Hunger = 5;
            Happiness = 5;
            Health = 8;
        }

        public void Feed()
        {
            
           // Hunger = Math.Max(Hunger - 2, 1);
            //Health = Math.Min(Health + 1, 10);
            Hunger = Math.Max(0, Hunger - 2);
            Health = Math.Min(10, Health + 1);
        }

        public void Play()
        {
            
            Happiness = Math.Min(Happiness + 2, 10);
            Hunger = Math.Min(Hunger + 1, 10);


        }

        public void Rest()
        {
            
            Health = Math.Min(Health + 2, 10);
            Happiness = Math.Max(Happiness - 1, 1);

        }

        public void CheckStatus()
        {
            Console.WriteLine($"\n{Name}'s Status");
            Console.WriteLine($"-Hunger: {Happiness}");
            Console.WriteLine($"-Happiness: {Hunger}");
            Console.WriteLine($"-Health: {Health}");
        }

        public void TimePasses()
        {
            Hunger = Math.Min(Hunger + 1, 10);
            Happiness = Math.Max(Happiness - 1, 1);
        }

        public void CheckCriticalStatus()
        {
            if (Hunger <= 2)
            {
                Console.WriteLine($"{Name} is very hungry! Please feed him immediately.");
                Health = Math.Max(Health - 1, 1);
            }

            if (Happiness <= 2)
            {
                Console.WriteLine($"{Name} is very unhappy! Please play with him.");
            }

            if (Health <= 2)
            {
                Console.WriteLine($"{Name} is very unhealthy! Take better care of him.");
            }
        }
    }
}