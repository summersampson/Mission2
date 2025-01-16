using System;

internal class Program
{
    private static void Main(string[] args)
    {

        // welcoming the user
        Console.WriteLine("Welcome to the dice throwing simulator!");
        Console.WriteLine("How many dice would you like to roll?");

        // calling the diceRollStimulator
        if (int.TryParse(Console.ReadLine(), out int countOfRolls) && countOfRolls > 0)
        {
            DiceRollSimulator simulator = new DiceRollSimulator();
            int[] results = simulator.SimulateRolls(countOfRolls);

            // explaining how the results work
            Console.WriteLine("DICE ROLLING SIMULATION RESULTS:");
            Console.WriteLine("Each '*' represents 1% of the total number of rolls.");
            Console.WriteLine($"Total number of rolls = {countOfRolls}.");

            // doing the part that shows the stars
            for (int i = 2; i <= 12; i++)
            {
                int percent = (int)Math.Round((double)results[i] / countOfRolls * 100);
                string stars = new string('*', percent);
                Console.WriteLine($"{i}: {stars}");
            }

            Console.WriteLine("Thank you for using the dice throwing simulator. Goodbye!");
        }
        // if their number was invalid
        else {
            Console.WriteLine("Invalid input.");
        }
    }
}

class DiceRollSimulator
{
    // stimulate rolls
    private Random random = new Random();
    public int[] SimulateRolls(int countOfRolls)
        {
            int[] Rollresults = new int[13];

        for (int i=0; i < countOfRolls; i++)
        {
            int die1 = random.Next(1, 7);
            int die2 = random.Next(1, 7);
            int total = die1 + die2;
            Rollresults[total]++;
        }

        return Rollresults;
        }
    }