using TestesDeSoftwareSample;

namespace SampleXUnit
{
    public class ContaBancoTests
    {
        [Fact]
        public void Test1()
        {
            ContaBanco c = new ContaBanco("Cliente1", 2000);
        }
    }
}