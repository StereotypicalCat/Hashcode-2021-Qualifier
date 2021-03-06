﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hashcode_2021_Qualifier
{
    public class FileImporter : IDataSource
    {

        private Dictionary<String, Street> streetNameLookup;
        
        public SimulationData GetData(String inputName)
        {
            var inputpath = Directory.GetCurrentDirectory() + "\\" + inputName + ".txt";
            
            string[] lines = System.IO.File.ReadAllLines(inputpath);

            var formatted = formatData(lines);

            return formatted;

        }

        private SimulationData formatData(string[] data)
        {
            streetNameLookup = new Dictionary<string, Street>();
            
            var simData = new SimulationData();
            
            var metadata = data[0].Split(' ');

            simData.simulationLength = Int32.Parse(metadata[0]);
            var noOfStreets = Int32.Parse(metadata[2]);
            var noOfCars = Int32.Parse(metadata[3]);
            var pointsOnTime = Int32.Parse(metadata[4]);

            simData.scoreOnTime =  pointsOnTime;

            simData.Intersections = new Intersection[Int32.Parse(metadata[1])];
            for (int i = 0; i < Int32.Parse(metadata[1]); i++)
            {
                simData.Intersections[i] = new Intersection();
                simData.Intersections[i].ID = i;
            }

            simData.Cars = new Car[noOfCars];

            Console.WriteLine("Importing Streets...");
            
            for (int i = 1; i < data.Length; i++)
            {
                if (i <= (noOfStreets))
                {
                    var street = new Street();

                    var streetData = data[i].Split(" ");

                    street.Start = simData.Intersections[Int32.Parse(streetData[0])];
                    
                    simData.Intersections[Int32.Parse(streetData[0])].Streets.Add(street);
                    
                    street.End = simData.Intersections[Int32.Parse(streetData[1])];
                    
                    simData.Intersections[Int32.Parse(streetData[1])].Streets.Add(street);

                    street.streetName = streetData[2];
                    street.Length = Int32.Parse(streetData[3]);

                    streetNameLookup.Add(street.streetName, street);
                    
                    if (i == noOfStreets)
                    {
                        Console.WriteLine("Cars...");
                    }
                    
                }
                else
                {
                    var car = new Car();

                    var carData = data[i].Split(" ");

                    var pathLength = Int32.Parse(carData[0]);

                    car.Path = new Street[pathLength];

                    for (int j = 0; j < pathLength; j++)
                    {
                        car.Path[j] = streetNameLookup[carData[j + 1]];
                    }

                    simData.Cars[i - 1 - noOfStreets] = car;

                }
            }

            foreach (var intersection in simData.Intersections)
            {
                intersection.initializeSchedule(intersection.Streets.Count);
            }
            
            return simData;
        }
    }
}