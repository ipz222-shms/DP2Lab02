﻿using AbstractFactoryLibrary.Factories;
using AbstractFactoryLibrary.Factories.Interfaces;
using AbstractFactoryLibrary.Products.Interfaces;
using ConsoleApp;
using FactoryLibrary.Interfaces;
using FactoryLibrary.Vendors;
using FactoryLibrary.Vendors.enums;
using PrototypeLibrary;
using SingletonLibrary;

while (true)
{
    var i = 0;
    Console.WriteLine("Select scenario:");
    foreach (var scenario in Enum.GetValues<Scenario>())
        Console.WriteLine($"\t{++i}: {scenario}");

    Console.Write("\nEnter number: ");
    var input = Console.ReadLine();
    int selectedScenario;
    if (int.TryParse(input, out var iValue))
        selectedScenario = --iValue;
    else
    {
        Console.Clear();
        Console.WriteLine("Invalid input!\n");
        continue;
    }

    Console.Clear();
    if (!Enum.IsDefined(typeof(Scenario), selectedScenario))
    {
        Console.WriteLine("Unknown scenario!\n");
        continue;
    }
    
    Console.WriteLine($"Run '{(Scenario)selectedScenario}' scenario:\n\n");

    switch ((Scenario)selectedScenario)
    {
        case Scenario.Factory:
            ISubscription sub;
            
            Console.WriteLine("WebSite:");
            WebSite webSite = new();
            
            try
            {
                Console.WriteLine("Pressing 'Buy Domestic Subscription' button:");
                sub = webSite.DomesticSubscriptionFormSubmit(10); // Will cause an exception, 10 < MinimalPeriod
                Console.WriteLine($"New Purchase:\n{sub}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType()}: {e.Message}");
            }

            try
            {
                Console.WriteLine("\nPressing 'Buy Premium Subscription' button:");
                sub = webSite.PremiumSubscriptionFormSubmit(99);
                Console.WriteLine($"New Purchase:\n{sub}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType()}: {e.Message}");
            }
            
            Console.WriteLine("\nMobileApp:");
            MobileApp mobileApp = new();
            
            try
            {
                Console.WriteLine("Selecting 'Premium Subscription'...");
                mobileApp.SelectSubscription(SubscriptionType.Premium);
                Console.WriteLine("Entering period...");
                mobileApp.AskForPeriod(42);
                Console.WriteLine("Confirming purchase...");
                sub = mobileApp.ConfirmSubscriptionPurchase();
                Console.WriteLine($"New Purchase:\n{sub}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType()}: {e.Message}");
            }
            
            Console.WriteLine("\nManagerCall:");
            ManagerCall managerCall = new();
            
            try
            {
                Console.WriteLine("Calling manager...");
                managerCall.AcceptCall();
                Console.WriteLine("Verification...\nSelecting subscription plan (Educational)...");
                managerCall.AskForSubscriptionType(SubscriptionType.Educational);
                Console.WriteLine("Selecting period...");
                managerCall.AskForPeriod(128);
                Console.WriteLine("Confirming purchase...");
                sub = managerCall.ConfirmPurchase();
                Console.WriteLine($"New Purchase:\n{sub}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType()}: {e.Message}");
            }
            
            break;
        case Scenario.AbstractFactory:
            List<ITechFactory> factories = new()
            {
                new BalaxyFactory(),
                new KiaomiFactory(),
                new PearFactory()
            };
            
            IEBook ebook;
            ILaptop laptop;
            INetbook netbook;
            ISmartphone smartphone;

            foreach (var factory in factories)
            {
                ebook = factory.ProduceEBook();
                laptop = factory.ProduceLaptop();
                netbook = factory.ProduceNetbook();
                smartphone = factory.ProduceSmartphone();
                
                Console.WriteLine($"{factory}:\n\t{ebook}\n\t{laptop}\n\t{netbook}\n\t{smartphone}\n");
            }
            
            break;
        case Scenario.Singleton:
            // Because we use a static class, we don't need to create an instance property inside of it
            // In .NET only one instance of static class can exist, and it initializes with the first use
            
            Console.WriteLine($"Is authorized: {Authenticator.IsAuth()}\nAuthorizing (admin, admin)...");
            Authenticator.Auth("admin", "admin");
            Console.WriteLine($"Is authorized: {Authenticator.IsAuth()}\nChanging password...");
            Authenticator.ChangePassword("admin", "Samurai");
            Console.WriteLine($"Is authorized: {Authenticator.IsAuth()}\nAuthorizing (admin, admin)...");
            try
            {
                Authenticator.Auth("admin", "admin");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Authorizing (admin, Samurai)...");
            Authenticator.Auth("admin", "Samurai");
            Console.WriteLine($"Is authorized: {Authenticator.IsAuth()}\nLogging out...");
            Authenticator.Logout();
            Console.WriteLine($"Is authorized: {Authenticator.IsAuth()}");
            break;
        case Scenario.Prototype:
            Virus gen1 = new("Covid-19", "SARS-CoV-2", 0.81, 5);
            Console.WriteLine($"Gen 1: {gen1}");
            
            var gen2 = gen1.Clone() as Virus;
            gen2.Name = "Covid-21";
            gen2.Weight += 0.03;
            gen2.Age -= 2;
            Console.WriteLine($"Gen 2: {gen2}");

            var gen3 = gen2.Clone() as Virus;
            gen3.Name = "Covid-22";
            gen3.Weight += 0.09;
            gen3.Age--;
            Console.WriteLine($"Gen 3: {gen3}");

            gen1.AddChild(gen2);
            gen2.AddChild(gen3);
            Console.WriteLine($"\nAdding children...\n\nGen 1: {gen1}");
            
            var gen1Clone = gen1.Clone() as Virus;
            Console.WriteLine($"\nCloning Gen 1...\n\nGen 1 Clone: {gen1Clone}");
            
            var gen2Clone = gen2.Clone() as Virus;
            Console.WriteLine($"\nCloning Gen 2...\n\nGen 2 Clone: {gen2Clone}");
            
            break;
        case Scenario.Builder:
            break;
        default:
            throw new NotImplementedException();
    }
    
    Console.Write("\n\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}
