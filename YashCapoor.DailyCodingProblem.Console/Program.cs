
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Autofac;
using YashCapoor.DailyCodingProblem.Solutions;

namespace YashCapoor.DailyCodingProblem.ConsoleRunner
{
    using System;

    class Program
    {
        private static IContainer container;

        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.Load("YashCapoor.DailyCodingProblem.Solutions"))
                .Where(x => x.Name.EndsWith("Solution", StringComparison.OrdinalIgnoreCase))
                .AsImplementedInterfaces()
                .As<IProblemSolution>()
                .InstancePerLifetimeScope();

            container = builder.Build();

            while (true)
            {
                Console.WriteLine("Select a problem to solve, or x to quit.: ");
                var input = Console.ReadLine();
                if (input.Equals("x", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var validInput = int.TryParse(input, out int problem);
                if (!validInput)
                {
                    Console.WriteLine("Invalid Input!");
                    continue;
                }

                var interfaceName = $"IProblem{input}Solution";

                using (var scope = container.BeginLifetimeScope())
                {
                    Type requestedType = Assembly.Load("YashCapoor.DailyCodingProblem.Solutions")
                        .GetTypes().FirstOrDefault(x => x.Name.Equals(interfaceName, StringComparison.OrdinalIgnoreCase) && x.IsInterface);

                    if (requestedType != null && scope.IsRegistered(requestedType))
                    {
                        var solution = scope.Resolve(requestedType);
                        (solution as IProblemSolution).SolveProblem();
                    }
                    else
                    {
                        Console.WriteLine($"No implementation of solution for problem {input} found.");
                        continue;
                    }
                }
            }
        }
    }
}
