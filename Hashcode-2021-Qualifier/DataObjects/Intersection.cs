using System.Collections.Generic;

namespace Hashcode_2021_Qualifier
{
    public class Intersection
    {
        public int ID { get; set; }
        
        public List<Street> Streets { get; set; }

        public int[] schedule;


        public Intersection(List<Street> streets)
        {
            Streets = streets;

            //schedule = new int[streets.Length];
        }
    }
}