using TestesDeSoftwareSample;

namespace SampleMSTest
{
    [TestClass]
    public class ContaBancoTests
    {
        [TestMethod]
        public void TestSaldo()
        {
            double valor_inicial = 5000;
            double valor_saque = 2000;
            double valor_esperado = 3000;

            ContaBanco c = new ContaBanco("Cliente1", valor_inicial);
            c.Saque(valor_saque);
            double valor_atual = c.Saldo;
            Assert.AreEqual(valor_esperado, valor_atual);
        }
    }
}