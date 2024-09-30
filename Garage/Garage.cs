using Garage.Vehicles;
using System.Collections;


namespace Garage.Garage
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicles;
        //counter for the vihacles in the garage
        private int count = 0;

        public int Capacity { get; private set; }

        public Garage(int capacity)
        {
            Capacity = capacity;
            vehicles = new T[capacity];
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
