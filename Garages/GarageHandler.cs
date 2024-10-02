﻿using GarageProject.Vehicles;

namespace GarageProject.Garages
{
    public class GarageHandler
    {
        //Added a parameter to hide the messages for seed data
        public void AddVehicle(Vehicle vehicle, Garage<Vehicle> garage, bool isSeedData = false)  
        {
            bool isAdded = garage.AddVehicle(vehicle);
            if (isAdded && !isSeedData) Console.WriteLine($"The vehicle was succesfully added.");
            else if (!isAdded && !isSeedData) Console.WriteLine($"Sorry, the garage is full."); 
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
