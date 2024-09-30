namespace GarageProject.Vehicles
{
    internal interface IVehicle
    {
        string Color { get; set; }
        uint NrOfWheels { get; set; }
        string RegistrationNr { get; set; }
    }
}