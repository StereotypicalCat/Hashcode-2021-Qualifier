using System;

namespace Hashcode_2021_Qualifier
{
    public class Street
    {
        public Intersection Start { get; set; }
        public Intersection End { get; set; }
        
        public int Length;

        public String streetName;
    }
}