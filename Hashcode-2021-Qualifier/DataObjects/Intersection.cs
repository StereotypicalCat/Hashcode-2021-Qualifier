using System.Collections.Generic;

namespace Hashcode_2021_Qualifier
{
    public class Intersection
    {
        public Street[] Streets { get; set; }

        public int[] schedul;


        public Intersection(Street[] streets)
        {
            Streets = streets;

            schedul = new int[streets.Length];
        }
    }
}