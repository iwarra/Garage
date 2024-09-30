namespace Garage.Vehicles
{
    internal interface IVehicle
    {
        string Color { get; set; }
        int NrOfWheels { get; set; }
        string RegistrationNr { get; set; }
    }
}