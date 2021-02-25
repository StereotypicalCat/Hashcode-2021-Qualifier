using System.ComponentModel.DataAnnotations;

namespace Hashcode_2021_Qualifier
{
    public class Car
    {
        public Street[] Path;
    }

    public class CarExtendedMinTime : Car
    {
        public int MinTime;
        public int Carscore;

        public CarExtendedMinTime(Car StartCar)
        {
            Path = StartCar.Path;
            MinTime = CalculateMinTime();
        }

        public int CalculateMinTime()
        {
            int tempTime = 0;

            foreach (var street in Path)
            {
                tempTime += street.Length;
            }

            return tempTime;
        }

        public int CalculateScore(int timeLeft)
        {
            int FastestTime = CalculateMinTime();

            return timeLeft - FastestTime;
        }
    }
}