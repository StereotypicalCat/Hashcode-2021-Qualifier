using System.Collections.Generic;
using System.Linq;
using Hashcode_2021_Qualifier.DataObjects;

namespace Hashcode_2021_Qualifier
{
    public class noOfCars : IProblemSolver
    {
        
        
        
        public Schedule solve(SimulationData input)
        {
            var solution = new Schedule();

            var allStreets = input.Intersections.SelectMany(x => x.Streets);

            Dictionary<Street, WeightedStreet> streets = new Dictionary<Street, WeightedStreet>();
            Dictionary<WeightedStreet, Street> streetsTheOtherWay = new Dictionary<WeightedStreet, Street>();

            foreach (var street in allStreets)
            {
                var ws = (WeightedStreet) street;
                streets.Add(street, ws);
                streetsTheOtherWay.Add(ws, street);
            }

            foreach (var car in input.Cars)
            {
                foreach (var street in car.Path)
                {
                    streets[street].Weight++;
                }
            }

            solution.intersections = solution.intersections.ToList();

            foreach (var intersection in solution.intersections)
            {
                for (int i = 0; i < intersection.schedule.Length; i++)
                {
                    
                }
            }

            return null;
        }
    }
}