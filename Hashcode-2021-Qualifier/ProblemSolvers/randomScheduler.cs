using System.Linq;
using System.Net.Security;
using Hashcode_2021_Qualifier.DataObjects;
using Hashcode_2021_Qualifier.HelperClasses;

namespace Hashcode_2021_Qualifier
{
    public class randomScheduler : IProblemSolver
    {
        public Schedule solve(SimulationData input)
        {
           input = TrafficLightRemover.removeLight(input);

            Schedule returnSchedule = new Schedule();

            returnSchedule.intersections = input.Intersections.ToList();

            foreach (var intersection in returnSchedule.intersections)
            {
                for (int i = 0; i < intersection.schedule.Length; i++)
                {
                    if (intersection.Streets[i].End == intersection && intersection.enabled)
                    {
                        intersection.schedule[i] = 2;
                    }
                }
            }

            return returnSchedule;
        }
    }
}