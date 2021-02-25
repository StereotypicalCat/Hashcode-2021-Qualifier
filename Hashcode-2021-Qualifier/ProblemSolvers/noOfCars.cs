using System;
using System.Collections.Generic;
using System.Linq;
using Hashcode_2021_Qualifier.DataObjects;
using Hashcode_2021_Qualifier.HelperClasses;

namespace Hashcode_2021_Qualifier
{
    public class noOfCars : IProblemSolver
    {
        public Schedule solve(SimulationData unfixedInput)
        {
            var input = TrafficLightRemover.removeLight(unfixedInput);
            
            var scalar = 3f;

            var solution = new Schedule();

            Dictionary<Street, int> streets = new Dictionary<Street, int>();

            foreach (var car in input.Cars)
            {
                foreach (var street in car.Path)
                {
                    if (streets.ContainsKey(street))
                    {
                        streets[street]++;
                    }
                    else
                    {
                        streets.Add(street, 1);   
                    }
                }
            }

            solution.intersections = input.Intersections.ToList();

            foreach (var intersection in solution.intersections)
            {
                var sum = 0f;

                for (int i = 0; i < intersection.Streets.Count; i++)
                {
                    var street = intersection.Streets[i];
                    if (street.End == intersection)
                    {
                        var val = 0;
                        streets.TryGetValue(street, out val);
                        sum += val;
                    }
                }

                for (int i = 0; i < intersection.schedule.Length; i++) {
                    var street = intersection.Streets[i];

                    if (!street.enabled)
                    {
                        continue;
                    }
                    
                    if (street.End == intersection)
                    {
                        var val = 0;
                        streets.TryGetValue(street, out val);

                        int time = (int) Math.Ceiling(((((float) val) / sum) * scalar));
                        intersection.schedule[i] = time;
                    }
                }
                
            }

            return solution;
        }
    }
}