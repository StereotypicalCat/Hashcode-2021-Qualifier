using System;
using Hashcode_2021_Qualifier.DataObjects;
using Hashcode_2021_Qualifier.HelperClasses;

namespace Hashcode_2021_Qualifier
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataSource dataGetter = new FileImporter();

            IProblemSolver problemSolver = new randomScheduler();

            var data = dataGetter.GetData();

            data = TrafficLightRemover.removeLight(data);
            
            Schedule answer = problemSolver.solve(data);
            
            DataExporter.exportSolution(answer);

        }
    }
}