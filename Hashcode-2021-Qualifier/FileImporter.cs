using System.IO;

namespace Hashcode_2021_Qualifier
{
    public class FileImporter : IDataSource
    {
        public int GetData()
        {
            var inputpath = Directory.GetCurrentDirectory() + "\\input.txt";
            
            string[] lines = System.IO.File.ReadAllLines(inputpath);

            var formatted = formatData(lines);

            return formatted;

        }

        private int formatData(string[] data)
        {
            return 1;
        }
    }
}