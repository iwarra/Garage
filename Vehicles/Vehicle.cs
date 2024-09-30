namespace GarageProject.Vehicles
{
    public class Vehicle : IVehicle
    {
        public string RegistrationNr { get; set; }
        public string Color { get; set; }
        public int NrOfWheels { get; set; }
        public Vehicle(string registrationNr, string color, int nrOfWheels)
        {
            RegistrationNr = registrationNr;
            Color = color;
            NrOfWheels = nrOfWheels;
        }
    }
}
