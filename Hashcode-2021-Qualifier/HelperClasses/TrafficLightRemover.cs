using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hashcode_2021_Qualifier.HelperClasses
{
    public static class TrafficLightRemover
    {
        public static SimulationData removeLight(SimulationData oldData)
        {
            List<Street> newStreets = oldData.Intersections.SelectMany(x => x.Streets).ToList();


            List<Intersection> newIntersections = new List<Intersection>();

            newIntersections = oldData.Intersections.ToList();

            List<Street> AllFound = new List<Street>();


            foreach (Car oldDataCar in oldData.Cars)
            {
                CarExtendedMinTime tempCar = new CarExtendedMinTime(oldDataCar);

                if (tempCar.MinTime < oldData.simulationLength)
                {
                    foreach (var street in tempCar.Path)
                    {
                        var foundInter = newStreets.FindAll(x => x == street);

                        foreach (var str in foundInter)
                        {
                            newStreets.Remove(str);
                        }

                        AllFound.AddRange(foundInter);
                    }
                }
            }

            var foundLight = AllFound.Distinct().ToList();

            foreach (var street in foundLight)
            {
                street.End.enabled = true;
                street.enabled = true;
            }

//            oldData.Intersections = newIntersections.ToArray();

            return oldData;
        }
    }
}
