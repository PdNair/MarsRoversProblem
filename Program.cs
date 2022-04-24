using MarsRoverProblem;
using System;

namespace MarsRoversProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserInput();
        }

        private static void UserInput()
        {
            Console.WriteLine("Enter the grid size in specific format (eg- 3*5 4*5 5*5)");
            string gridSize = Console.ReadLine().Replace(" ", "");

            Console.WriteLine("Enter the navigation command (eg - L R F)");
            string commandSet = Console.ReadLine().ToUpper().Replace(" ", "");

            Start(gridSize, commandSet);
        }

        private static void Start(string gridSize, string commandSet)
        {
            try
            {
                Calculate calc = new Calculate
                {
                    xLimit = Convert.ToInt32(gridSize.Substring(0, gridSize.IndexOf("*"))),
                    yLimit = Convert.ToInt32(gridSize.Substring(gridSize.LastIndexOf('*') + 1))
                };
                calc.Navigate(commandSet);
                Console.WriteLine($"Final Position - {calc.X}, {calc.Y}, {calc.Direction} \n");

                Console.WriteLine("Press 1 to continue. Press 'Enter' to exit");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key != ConsoleKey.Enter)
                {
                    Console.WriteLine("\n");
                    UserInput();
                }   
            }
            catch (Exception ex)
            {
                Console.WriteLine("Halted with an Error - ", ex.Message);
            }
        }
    }
}
