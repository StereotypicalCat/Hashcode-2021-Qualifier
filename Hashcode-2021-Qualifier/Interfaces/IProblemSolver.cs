using Hashcode_2021_Qualifier.DataObjects;

namespace Hashcode_2021_Qualifier
{
    public interface IProblemSolver
    {
        public Schedule solve(SimulationData input);
    }
}