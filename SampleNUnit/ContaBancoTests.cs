using TestesDeSoftwareSample;

namespace SampleNUnit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            ContaBanco c = new ContaBanco("Cliente1", 1000);
            Assert.Pass();
        }
    }
}