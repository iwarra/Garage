using GarageProject.Vehicles;

namespace GarageProject.Garages
{
    public class GarageHandler
    {
        public void AddVehicle(Vehicle vehicle, Garage<Vehicle> garage)  
        {
            bool isAdded = garage.AddVehicle(vehicle);
            if (isAdded) Console.WriteLine($"The vehicle was succesfully added.");
            else Console.WriteLine($"Sorry, the garage is full."); 
        }

        public void RemoveVehicle(Garage<Vehicle> garage)
        {
            Console.WriteLine("Please provide the registration number of the vehicle you want to remove: ");
            string registrationNr = Console.ReadLine();
            //Add checks for null etc
            bool isRemoved = garage.RemoveVehicle(registrationNr);
            if (isRemoved) Console.WriteLine($"The vehicle with plates: {registrationNr} was succesfully removed.");
            else Console.WriteLine($"Sorry, the vehicle was not found.");
        }

        public void ListAllVehicles(Garage<Vehicle> garage)
        {
            Console.WriteLine("\n");
            foreach (var vehicle in garage)
            {
                Console.WriteLine($"{vehicle.GetType().Name} with the registration: {vehicle.RegistrationNr} in color: {vehicle.Color}"); 
            }
        }

        public Dictionary<string, int> GetVehicleCountByType(Garage<Vehicle> garage)
        {
            return garage.CountVehiclesByType();
        }
    }
}
