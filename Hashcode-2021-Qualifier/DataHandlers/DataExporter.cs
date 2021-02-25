using System;
using System.Collections.Generic;
using System.IO;
using Hashcode_2021_Qualifier.DataObjects;

namespace Hashcode_2021_Qualifier
{
    public class DataExporter
    {
        public static void exportSolution(Schedule solution)
        {
            List<String> answerLines = formatOutput(solution);
            
            var outputPath = Directory.GetCurrentDirectory() + "\\answer.txt";
            
            Console.WriteLine("writing file to...:");
            Console.WriteLine(outputPath);
            
            File.WriteAllLines(outputPath, answerLines);
        }

        public static List<String> formatOutput(Schedule solution)
        {
            List<string> answerLines = new List<string>();

            answerLines.Add("" + solution.intersections.Count);

            answerLines.Add("" + solution.intersections.Count);




            return answerLines;
        }
        
    }
}