using System;
using Hashcode_2021_Qualifier.DataObjects;

namespace Hashcode_2021_Qualifier
{
    class Program
    {
        static void Main(string[] args)
        {

            IDataSource dataGetter = new MockData();

            IProblemSolver problemSolver = new BruteForce();

            var data = dataGetter.GetData();
            
            
            Schedule answer = problemSolver.solve(data);
            
            DataExporter.exportSolution(answer);

        }
    }
}