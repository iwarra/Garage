using GarageProject.Garages;
using GarageProject.UI;
using GarageProject.Vehicles;

namespace GarageProject
{
    internal class Program
    {
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
                       // AddVehicle();
                        break;
                    case MenuHelpers.Remove:
                        // RemoveVehicle();
                        break;
                    case MenuHelpers.Print:
                        // PrintAllVehicles();
                        break;
                    case MenuHelpers.AddGarage:
                        // AddGarage();
                        break;
                    case MenuHelpers.Quit:
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
            while (isRunning);

            //Pseudo code
            //static void AddVehicle()
            //{
            //   Vehicle VehicleToAdd = CreateVehicle();
            //   //Let user pick a garage from a list?
            //   Garage<Vehicle> GarageToAddInto = GetGarage();

            //   handler.AddVehicle(VehicleToAdd, GarageToAddInto); 
            //}

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

            //static void AddGarage()
            //{
            //    string garageName = Util.AskForString("Please input the garage name: ");
            //    uint capacity = Util.AskForUInt("Please input the garage capacity: ");

            //    Garage<Vehicle> garageToAdd = new Garage<Vehicle>(capacity, garageName);
            //    allGarages.Add(garageToAdd);
            //}

        }
    }
}
