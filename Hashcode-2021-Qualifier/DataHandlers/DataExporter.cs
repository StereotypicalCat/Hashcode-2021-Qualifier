using System;
using System.Collections.Generic;
using System.IO;
using Hashcode_2021_Qualifier.DataObjects;

namespace Hashcode_2021_Qualifier
{
    public class DataExporter
    {
        public static void exportSolution(Schedule solution, string outputName)
        {
            List<String> answerLines = formatOutput(solution);
            
            var outputPath = Directory.GetCurrentDirectory() + "\\" + outputName + ".txt";
            
            Console.WriteLine("writing file to...:");
            Console.WriteLine(outputPath);
            
            File.WriteAllLines(outputPath, answerLines);
        }

        public static List<String> formatOutput(Schedule solution)
        {
            List<string> answerLines = new List<string>();

            answerLines.Add("" + solution.intersections.Count);

            foreach (var inter in solution.intersections)
            {
                answerLines.Add("" + inter.ID);


                List<int> IncludedIntersections = new List<int>();

                for (int i = 0; i < inter.schedule.Length; i++)
                {
                    if (inter.schedule[i] > 0)
                    {
                        IncludedIntersections.Add(i);
                    }
                }

                answerLines.Add("" + IncludedIntersections.Count);
                for (int i = 0; i < IncludedIntersections.Count; i++)
                {
                    int streetIndex = IncludedIntersections[i];
                    answerLines.Add("" + inter.Streets[streetIndex].streetName + " " + inter.schedule[streetIndex]);
                }
            }
            return answerLines;
        }
        
    }
}