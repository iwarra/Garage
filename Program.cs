using GarageProject.Garages;
using GarageProject.UI;
using GarageProject.Vehicles;

namespace GarageProject
{
    internal class Program
    {
        public static List<Garage<Vehicle>> allGarages = new List<Garage<Vehicle>>();

        static void Main()
        {
            bool isRunning = true;
            ConsoleUI ui = new ConsoleUI();
            GarageHandler handler = new GarageHandler(); 
            

            do 
            {
                MenuHelpers.ShowMainMenu();
                string input = ConsoleUI.GetInput().ToUpper();

                switch (input)
                {
                    case MenuHelpers.Add:
                       AddVehicle();
                        break;
                    case MenuHelpers.Remove:
                        // RemoveVehicle();
                        break;
                    case MenuHelpers.Print:
                        // PrintAllVehicles();
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
                //Let user pick a garage from a list?
                var (isMatched, selectedGarage) = GetGarage();
                if (isMatched && selectedGarage != null)
                {
                    handler.AddVehicle(VehicleToAdd, selectedGarage);
                }
                else Console.WriteLine("Sorry, we couldn't find the garage. Please try again.");
             }

            //Pseudo code
            //static void RemoveVehicle()
            //{
            //    //Let user pick a garage from a list?
            //    Garage<Vehicle> GarageToRemoveFrom = GetGarage();
            //    handler.RemoveVehicle(GarageToRemoveFrom);
            //}

            //static void PrintAllVehicles()
            //{
            //    Garage<Vehicle> SelectedGarage = GetGarage();
            //    handler.ListAllVehicles(SelectedGarage);
            //}

            static void AddGarage(List<Garage<Vehicle>> allGarages)
            {
                string garageName = Util.AskForString("Garage name");
                uint capacity = Util.AskForUInt("Garage capacity");

                Garage<Vehicle> garageToAdd = new Garage<Vehicle>(capacity, garageName);
                allGarages.Add(garageToAdd);
                Console.WriteLine(allGarages.Count);
            }

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
            Console.WriteLine(allGarages.Count);
            foreach (var garage in allGarages)
            {
                Console.WriteLine(garage.Name);
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
