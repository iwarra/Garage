using GarageProject.Vehicles;
using System.Collections;


namespace GarageProject.Garages
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicles;
        //counter for the vihacles in the garage
        private uint count = 0;

        public string Name { get; private set; }
        public uint Capacity { get; private set; }

        public Garage(uint capacity, string name)
        {
            Name = name;
            Capacity = capacity;
            vehicles = new T[capacity];
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
                    if (vehicles[count - 1] != null) 
                    {
                        vehicles[count - 1] = null;
                    }; // Clear the last slot
                    count--;
                    
                    return true; 
                }
            }
            return false;
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
