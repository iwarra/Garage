using GarageProject.Vehicles;
using System.Collections;


namespace GarageProject.Garages
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicles;
        //counter for the vehicles in the garage
        private uint count = 0;

        public string Name { get; private set; }
        public uint Capacity { get; private set; }

        public Garage(uint capacity, string name)
        {
            Name = name;
            Capacity = capacity;
            vehicles = new T[capacity];
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        internal bool AddVehicle(T vehicle)
        {
            //If there is room add vehicle to the last spot in the array and increase the counter
            if (count < Capacity)
            {
                vehicles[count] = vehicle;
                count++;
                
                return true;  
            }
            return false;  
        }

        internal bool RemoveVehicle(string registrationNr)
        {
            for (int i = 0; i < count; i++)
            {
                if (vehicles[i].RegistrationNr == registrationNr)
                {
                    // Shift elements to remove the vehicle
                    for (int j = i; j < count - 1; j++)
                    {
                        vehicles[j] = vehicles[j + 1];
                    }
                    // Clear the last slot if needed (in case the garage was full)
                    if (vehicles[count - 1] != null) 
                    {
                        vehicles[count - 1] = null;
                    };
                    count--;
                    
                    return true; 
                }
            }
            return false;
        }

        internal Dictionary<string, int> CountVehiclesByType()
        {
            return vehicles
                .Where(v => v != null)
                .GroupBy(v => v.GetType().Name)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        internal (bool isFound, string garageName) SearchByRegistration(string plateNumber)
        {
            bool isFound;
            IEnumerable<Vehicle> vehicle = vehicles
                .Where(v => v!= null)
                .Where(v => v.RegistrationNr == plateNumber);
            if (vehicle.Count() == 0) 
            {
                isFound = false;
                return (isFound, null);
            }
            else
            {
                isFound = true;
                return (isFound, Name);
            }
        }

        internal (bool wasFound, List<Vehicle> vehiclesFound) SearchByProps(string color, uint nrOfWheels, string vehicleType)
        {
            //Check all params and search accordingly
            IEnumerable<Vehicle> vehicle;
            bool wasFound;
            //If all arguments were specified
            vehicle = vehicles
                .Where(v => v != null)
                .Where(v => v.Color.ToLower() == color.ToLower())
                .Where(v => v.NrOfWheels == nrOfWheels)
                .Where(v => v.GetType().Name.ToLower() == vehicleType.ToLower());

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return vehicles[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
