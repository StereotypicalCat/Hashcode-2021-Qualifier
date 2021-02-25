using System;
using System.Collections.Generic;
using System.IO;

namespace Hashcode_2021_Qualifier
{
    public class DataExporter
    {
        public static void exportSolution(int solution)
        {
            List<String> answerLines = formatOutput(solution);
            
            var outputPath = Directory.GetCurrentDirectory() + "\\answer.txt";
            
            Console.WriteLine("writing file to...:");
            Console.WriteLine(outputPath);
            
            File.WriteAllLines(outputPath, answerLines);
        }

        public static List<String> formatOutput(int solution)
        {
            // magic

            return new List<string>();
        }
        
    }
}