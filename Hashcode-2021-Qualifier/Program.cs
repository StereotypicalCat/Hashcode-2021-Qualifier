using System;
using Hashcode_2021_Qualifier.DataObjects;

namespace Hashcode_2021_Qualifier
{
    class Program
    {

        private static string[] files = new[]
        {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f"
        };

        static void Main(string[] args)
        {
            IDataSource dataGetter = new FileImporter();

            IProblemSolver problemSolver = new randomScheduler();

            foreach (var file in files)
            {
                Console.WriteLine("Importing Data...");
                var data = dataGetter.GetData(file);
                Console.WriteLine("Running Algorithm...");
                Schedule answer = problemSolver.solve(data);
                Console.WriteLine("Writing Output...");
                DataExporter.exportSolution(answer, file + "-answer");
            }
        }
    }
}