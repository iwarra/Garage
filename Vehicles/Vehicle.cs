namespace GarageProject.Vehicles
{
    public class Vehicle : IVehicle
    {
        public string RegistrationNr { get; set; }
        public string Color { get; set; }
        public uint NrOfWheels { get; set; }
        public Vehicle(string registrationNr, string color, uint nrOfWheels)
        {
            RegistrationNr = registrationNr;
            Color = color;
            NrOfWheels = nrOfWheels; 
        }
    }
}
