namespace Hashcode_2021_Qualifier
{
    public class MockData : IDataSource
    {
        public SimulationData GetData()
        {

            return new SimulationData();
        }
    }
}