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
            SimulationData data = new SimulationData();

            List<Intersection> newIntersections = new List<Intersection>();

            newIntersections = (List<Intersection>)oldData.Intersections.Clone();

            foreach (Car oldDataCar in oldData.Cars)
            {
                CarExtendedMinTime tempCar = new CarExtendedMinTime(oldDataCar);

                if (tempCar.MinTime < oldData.simulationLength)
                {
                    foreach (var street in tempCar.Path)
                    {
                        var foundInter = newIntersections.FindAll(x => x.Streets.Contains(street));

                        foreach (var intersection in foundInter)
                        {
                            intersection.enabled = true;
                        }
                    }
                }
            }

            oldData.Intersections = newIntersections.ToArray();

            return oldData;
        }
    }
}
