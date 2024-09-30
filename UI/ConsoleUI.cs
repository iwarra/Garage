namespace Garage.UI
{
    internal class ConsoleUI : IUI
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
