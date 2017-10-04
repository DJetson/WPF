using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueCoaching
{
    class Program
    {
        private static readonly int Range = 100000;
        private static readonly float percentErrorMargin = 0.0005f;
        static void Main(string[] args)
        {
            Random rng = new Random();

            Console.Write("Enter a target value or press enter to generate a random value: ");
            string input = Console.ReadLine();

            int target;

            if (!int.TryParse(input, out target))
            {
                target = rng.Next(Range);
            }

            int current = 0;
            int tolerance = (int)(Range * percentErrorMargin);

            int steps = 0;
            while(Math.Abs(current - target) > tolerance)
            {
                Console.WriteLine($"Beginning step {steps}...");
                int next = rng.Next(Range * 2);
                Console.WriteLine($"Randomly generated {next}.");

                if(Math.Abs(current - target) < Math.Abs(next - target))
                {
                    Console.WriteLine($"CURRENT value is closer to target. NO CHANGE.");
                }
                else
                {
                    current = next;
                    Console.WriteLine($"NEXT value is closer to target. CHANGED TO {current}.");
                }

                Console.WriteLine($"STEP COMPLETE: Step {steps++}: [Current={current},\tDistance To Target={Math.Abs(current - target)}]");
            }

            Console.WriteLine($"Final Value: {current}, Total Steps: {steps}, Deviation: {current - target}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
