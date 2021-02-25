using System.Collections.Generic;

namespace Hashcode_2021_Qualifier
{
    public class Intersection
    {
        public int ID { get; set; }

        public List<Street> Streets { get; set; } = new List<Street>();

        public int[] schedule;

        public void initializeSchedule(int length)
        {
            schedule = new int[length];
        }
    }
}