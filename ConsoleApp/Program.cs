using ConsoleApp;
using FactoryLibrary.Interfaces;
using FactoryLibrary.Vendors;
using FactoryLibrary.Vendors.enums;

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
