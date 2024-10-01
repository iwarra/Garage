
namespace GarageProject.UI
{
    internal class ConsoleUI : IUI
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine($"Message: {message}.");
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
