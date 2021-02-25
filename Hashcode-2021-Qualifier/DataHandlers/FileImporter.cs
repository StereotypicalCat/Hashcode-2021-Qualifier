using System;
using System.IO;
using System.Linq;

namespace Hashcode_2021_Qualifier
{
    public class FileImporter : IDataSource
    {
        public SimulationData GetData()
        {
            var inputpath = Directory.GetCurrentDirectory() + "\\input.txt";
            
            string[] lines = System.IO.File.ReadAllLines(inputpath);

            var formatted = formatData(lines);

            return formatted;

        }

        private SimulationData formatData(string[] data)
        {
            var simData = new SimulationData();
            
            var metadata = data[0].Split(' ');

            simData.simulationLength = Int32.Parse(metadata[1]);
            var noOfIntersections = Int32.Parse(metadata[2]);
            var noOfCars = Int32.Parse(metadata[3]);
            var pointsOnTime = Int32.Parse(metadata[4]);

            simData.scoreOnTime =  pointsOnTime;

            simData.Intersections = new Intersection[noOfIntersections];
            for (int i = 0; i < noOfIntersections; i++)
            {
                simData.Intersections[i] = new Intersection();
            }
            
            for (int i = 1; i < data.Length; i++)
            {
                if (i <= (noOfIntersections + 1))
                {
                    var street = new Street();

                    var streetData = data[i].Split(" ");

                    street.Start = simData.Intersections[Int32.Parse(streetData[0])];
                    
                    simData.Intersections[Int32.Parse(streetData[0])].Streets.Add(street);
                    
                    street.End = simData.Intersections[Int32.Parse(streetData[1])];
                    
                    simData.Intersections[Int32.Parse(streetData[1])].Streets.Add(street);

                    street.streetName = streetData[2];
                    street.Length = Int32.Parse(streetData[3]);

                }
                else
                {
                    var car = new Car();

                    var carData = data[i].Split(" ");

                    var pathLength = Int32.Parse(carData[0]);

                    car.Path = new Street[pathLength];

                    bool hasFoundPath = false;
                    
                    for (int j = 1; j <= pathLength; j++)
                    {
                        foreach (var intersection in simData.Intersections)
                        {
                            foreach (var street in intersection.Streets)
                            {
                                if (street.streetName == carData[j - 1])
                                {
                                    car.Path[j - 1] = street;
                                    hasFoundPath = true;
                                    break;
                                }
                            }

                            if (hasFoundPath == true)
                            {
                                break;
                            }
                        }

                    }
                }
            }

            return simData;
        }
    }
}