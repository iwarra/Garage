using GarageProject.Garages;
using GarageProject.UI;
using GarageProject.Vehicles;

namespace GarageProject
{
    internal class Program
    {
        //List of all garages as there can be multiple
        public static List<Garage<Vehicle>> allGarages = new List<Garage<Vehicle>>();
        private static ConsoleUI ui = new ConsoleUI();
        private static GarageHandler handler = new GarageHandler();

        //ToDo: make a separate main class that will contain the logic to reduce the code used here
        //Error handling
        static void Main()
        {
            bool isRunning = true;
            SeedData();
            
            do 
            {
                MenuHelpers.ShowMainMenu();
                string input = ui.GetInput().ToUpper();

                switch (input)
                {
                    case MenuHelpers.Print:
                        PrintAllVehicles();
                        break;
                    case MenuHelpers.PrintByType:
                        PrintByType();
                        break;
                    case MenuHelpers.Add:
                       AddVehicle();
                        break;
                    case MenuHelpers.Remove:
                        RemoveVehicle();
                        break;
                    case MenuHelpers.Search:
                         //MenuHelpers.CloseMainMenu();
                         MenuHelpers.ShowSearchMenu();
                        break;
                    case MenuHelpers.SearchByRegistration:
                        SearchByRegistration();
                        break;
                    case MenuHelpers.SearchByProps:
                        SearchByProps();
                        break;
                    case MenuHelpers.Exit:
                        //MenuHelpers.CloseSearchMenu();
                        //MenuHelpers.ShowMainMenu();
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

        }


        //ToDo: Refactor the CreateVehicle
        private static Vehicle CreateVehicle()
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            bool isCorrect = false;
            //Print out types and ask for which one it should be
            //ToDo: Refactor the vehicle types logic
            List<string> vehicleTypes = new List<string>
            {
                "Car",
                "Bus",
                "Motorcycle",
                "RV",
                "Truck"
            };
            //Prints this part in different color 
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Here are all the vehicle types: ");
            vehicleTypes.ForEach(v => Console.WriteLine(v));
            Console.ForegroundColor = originalColor;

            while (!isCorrect)
            {
                string vehicleType = Util.AskForString("Vehicle type");
                string registration;
                string color;
                uint nrOfWheels;

                if (vehicleType.ToLower() == "car")
                {
                    registration = Util.AskForString("Vehicle registration");
                    color = Util.AskForString("Vehicle color");
                    nrOfWheels = Util.AskForUInt("Number of wheels");
                    string fuel = Util.AskForString("Fuel used");
                    isCorrect = true;
                    return new Car(registration, color, nrOfWheels, fuel);
                }
                else if (vehicleType.ToLower() == "bus")
                {
                    registration = Util.AskForString("Vehicle registration");
                    color = Util.AskForString("Vehicle color");
                    nrOfWheels = Util.AskForUInt("Number of wheels");
                    uint nrOfSeats = Util.AskForUInt("Number of seats");
                    isCorrect = true;
                    return new Bus(registration, color, nrOfWheels, nrOfSeats);
                }
                else if (vehicleType.ToLower() == "motorcycle")
                {
                    registration = Util.AskForString("Vehicle registration");
                    color = Util.AskForString("Vehicle color");
                    nrOfWheels = Util.AskForUInt("Number of wheels");
                    uint maxSpeed = Util.AskForUInt("Maximum speed");
                    isCorrect = true;
                    return new Motorcycle(registration, color, nrOfWheels, maxSpeed);
                }
                else if (vehicleType.ToLower() == "rv")
                {
                    registration = Util.AskForString("Vehicle registration");
                    color = Util.AskForString("Vehicle color");
                    nrOfWheels = Util.AskForUInt("Number of wheels");
                    uint length = Util.AskForUInt("Length");
                    isCorrect = true;
                    return new Rv(registration, color, nrOfWheels, length);
                }
                else if (vehicleType.ToLower() == "truck")
                {
                    registration = Util.AskForString("Vehicle registration");
                    color = Util.AskForString("Vehicle color");
                    nrOfWheels = Util.AskForUInt("Number of wheels");
                    uint capacity = Util.AskForUInt("Length");
                    isCorrect = true;
                    return new Truck(registration, color, nrOfWheels, capacity);
                }
                else
                {
                    Console.WriteLine("Please input a correct vehicle type.");
                }
            }
            return null;
        }

        private static void AddVehicle()
        {
            Vehicle VehicleToAdd = CreateVehicle();
            var (isMatched, selectedGarage) = GetGarage();
            if (isMatched && selectedGarage != null)
            {
                handler.AddVehicle(VehicleToAdd, selectedGarage);
            }
            else Console.WriteLine("Sorry, we couldn't find the garage. Please try again.");
        }

        private static void RemoveVehicle()
        {
            var (isMatched, selectedGarage) = GetGarage();
            if (isMatched && selectedGarage != null) handler.RemoveVehicle(selectedGarage);
        }

        private static void PrintAllVehicles()
        {
            var (isMatched, selectedGarage) = GetGarage();

            if (!isMatched || selectedGarage == null)
            {
                Console.WriteLine("Garage not found.");
                return;
            }

            if (selectedGarage.IsEmpty()) Console.WriteLine($"{selectedGarage.Name} garage is empty.");
            else handler.ListAllVehicles(selectedGarage);
        }
        private static void PrintByType()
        {
            var (isFound, selectedGarage) = GetGarage();
            if (isFound)
            {
                Dictionary<string, int> vehicleTypes = handler.GetVehicleCountByType(selectedGarage);
                foreach (var v in vehicleTypes)
                {
                    Console.WriteLine($"{v.Key} total is: {v.Value}");
                }
            }
            else Console.WriteLine("Please select an existing garage.");
        }

        private static void AddGarage(List<Garage<Vehicle>> allGarages)
        {
            string garageName = Util.AskForString("Garage name");
            uint capacity = Util.AskForUInt("Garage capacity");

            Garage<Vehicle> garageToAdd = new Garage<Vehicle>(capacity, garageName);
            allGarages.Add(garageToAdd);
            Console.WriteLine(allGarages.Count);
        }

        private static (bool, Garage<Vehicle>?) GetGarage()
        {
            bool isMatched = false;
            PrintAllGarages();
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

        private static void PrintAllGarages()
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Here is a list of all the garages: ");
            allGarages.ForEach(g => Console.WriteLine(g.Name));
            Console.ForegroundColor = originalColor;
        }
        private static void SearchByProps()
        {
            PrintAllGarages();
            string garageName = Util.AskForString("Garage name");
            
            string color = Util.AskForString("Vehicle color");
            uint nrOfWheels = Util.AskForUInt("Number of wheels");
        }

        private static void SearchByRegistration()
        {
            bool isMatched = false;
            string garageName;
            string registration = Util.AskForString("Plate number");
            allGarages.ForEach(g => 
            {
                (isMatched, garageName) = handler.SearchByRegistration(registration, g);
                if (isMatched && garageName != null)
                {
                    Console.WriteLine($"The vehicle with registration {registration} was found in {g.Name}.");
                    return;
                }
            });
            if (!isMatched) Console.WriteLine($"We couldn't find a vehicle with registration: {registration}");
        }

        private static void SeedData()
        {
            //Create and add a garage so we have something to work with
            Garage<Vehicle> garageToAddTo = new(10, "Centralen");
            allGarages.Add(garageToAddTo);

            //Create and add some wehicles
            Car car1 = new("110023", "silver", 4, "electric");
            Car car2 = new("AR0879", "black", 4, "gas");
            Truck truck1 = new("TR-22345", "red", 8, 250);
            List<Vehicle> vehicles =
            [
                car1,
                    car2,
                    truck1
            ];
            vehicles.ForEach(v => handler.AddVehicle(v, garageToAddTo, true));
        }
    }
}
