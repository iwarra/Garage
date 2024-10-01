using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageProject.Vehicles
{
    internal class Truck : Vehicle
    {
        public Truck(string registrationNr, string color, uint nrOfWheels, bool isLoaded ) : base(registrationNr, color, nrOfWheels)
        {
        }
    }
}
