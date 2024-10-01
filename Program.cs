using GarageProject.Garages;
using GarageProject.UI;
using GarageProject.Vehicles;

namespace GarageProject
{
    internal class Program
    {
        //List of all garages as there can be multiple
        public static List<Garage<Vehicle>> allGarages = new List<Garage<Vehicle>>();

        static void Main()
        {
            bool isRunning = true;
            ConsoleUI ui = new ConsoleUI();
            GarageHandler handler = new GarageHandler(); 
            

            do 
            {
                MenuHelpers.ShowMainMenu();
                string input = ui.GetInput().ToUpper();

                switch (input)
                {
                    case MenuHelpers.Print:
                        PrintAllVehicles();
                        break;
                    //Add printing by type and quantity
                    case MenuHelpers.PrintByType:
                        PrintByType();
                        break;
                    case MenuHelpers.Add:
                       AddVehicle();
                        break;
                    case MenuHelpers.Remove:
                        RemoveVehicle();
                        break;
                    //Add search
                    case MenuHelpers.Search:
                        SearchVehicles();
                        break;
                    case MenuHelpers.AddGarage:
                        AddGarage(allGarages);
                        break;
                    case MenuHelpers.Quit:
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
            while (isRunning);

            
             void AddVehicle()
             {
                Vehicle VehicleToAdd = CreateVehicle();
                var (isMatched, selectedGarage) = GetGarage();
                if (isMatched && selectedGarage != null)
                {
                    handler.AddVehicle(VehicleToAdd, selectedGarage);
                }
                else Console.WriteLine("Sorry, we couldn't find the garage. Please try again.");
             }


            void RemoveVehicle()
            {
                var (isMatched, selectedGarage) = GetGarage();
                if(isMatched && selectedGarage != null) handler.RemoveVehicle(selectedGarage);  
            }

            void PrintAllVehicles()
            {
                var (isMatched, selectedGarage) = GetGarage();
                if(isMatched && selectedGarage != null) handler.ListAllVehicles(selectedGarage);
            }

            static void AddGarage(List<Garage<Vehicle>> allGarages)
            {
                string garageName = Util.AskForString("Garage name");
                uint capacity = Util.AskForUInt("Garage capacity");

                Garage<Vehicle> garageToAdd = new Garage<Vehicle>(capacity, garageName);
                allGarages.Add(garageToAdd);
                Console.WriteLine(allGarages.Count);
            }

        }

        private static void PrintByType()
        {
            string garageName = Util.AskForString("Garage name");
            //Loop through all vehicles and sort by type
            //Print total number of each type
        }

        private static void SearchVehicles()
        {
            string garageName = Util.AskForString("Garage name");
            string registration = Util.AskForString("Vehicle registration");
            string color = Util.AskForString("Vehicle color");
            uint nrOfWheels = Util.AskForUInt("Number of wheels");

            //Search for all vehicles in the given garage
            //If certain value is empty include all?
        }

        private static Vehicle CreateVehicle()
        {
            string registration = Util.AskForString("Vehicle registration");
            string color = Util.AskForString("Vehicle color");
            uint nrOfWheels = Util.AskForUInt("Number of wheels");

            return new Vehicle(registration, color, nrOfWheels);
        }

        private static (bool, Garage<Vehicle>?) GetGarage()
        {
            bool isMatched = false;
            string input = Util.AskForString("Garage name");

            foreach (var garage in allGarages)
            {
                if (garage.Name.ToLower() == input.ToLower()) 
                {
                    isMatched = true;
                    return (isMatched, garage);
                };
            }
            return (isMatched, null);   
        }

    }
}
