using System.Collections.Generic;

namespace Hashcode_2021_Qualifier
{
    public class Intersection
    {
        public bool enabled = false;

        public int ID { get; set; }

        public List<Street> Streets { get; set; } = new List<Street>();

        public int[] schedule;

        public void initializeSchedule(int length)
        {
            schedule = new int[length];
        }
    }

    public class IntersectionExtended
    {

        public Intersection intersection;


        public IntersectionExtended(Intersection intersection)
        {
            this.intersection = intersection;
        }
    }
}