using ConsoleApp;
using FactoryLibrary.Interfaces;
using FactoryLibrary.Vendors;

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
            WebSite webSite = new();
            ISubscription sub;
            
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
                Console.WriteLine("\nPressing 'Buy Educational Subscription' button:");
                sub = webSite.EducationalSubscriptionFormSubmit(320);
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
            
            break;
        case Scenario.AbstractFactory:
            break;
        case Scenario.Singleton:
            break;
        case Scenario.Prototype:
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
