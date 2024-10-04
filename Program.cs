using Microsoft.Extensions.Configuration;


namespace GarageProject
{
    internal class Program
    {

        static void Main()
        {
            Main main = new Main();
            try
            {
                //Employee emp = new Employee(null, 25);
                main.Run();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            finally
            {
                main.Run();
            }
        }

    }
}
