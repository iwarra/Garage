namespace GarageProject
{
    internal class MenuHelpers
    {
        public const string Print = "1";
        public const string PrintByType = "2";
        public const string Add = "3";
        public const string Remove = "4";
        public const string AddGarage = "5";
        public const string Search = "6";
        public const string Quit = "Q";
        public static void ShowMainMenu()
        {
            Console.WriteLine(
                   $"\n{Print}: Show all vehicles" +
                   $"\n{PrintByType}: Show number of vehicles by type" +
                   $"\n{Add}: Add a vehicle" +
                   $"\n{Remove}: Remove a vehicle" +
                   $"\n{AddGarage}: Add a new garage and its capacity" +
                   $"\n{Search}: Open the search bar" +
                   $"\n{Quit}: Quit");
        }

        public const char SearchByPlates = 'A';
        public const char SearchByProps = 'B';
        public const char Exit = 'C';
        public static void ShowSearchMenu()
        {

            Console.WriteLine(
                   $"\n{SearchByPlates}: Search by plates" +
                   $"\n{SearchByProps}: Search by other properties" +
                   $"\n{Exit}: Return to main menu");
        }
    }
}
