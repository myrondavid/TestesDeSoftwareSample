using System.Security.Principal;
using TestesDeSoftwareSample;
namespace SampleMSTest
{
    [TestClass]
    public class ContaBancoTests
    {
        [TestMethod]
        public void TestInit()
        {
            ContaBanco c = new ContaBanco("Cliente1", 1000);
            Assert.IsNotNull(c);
            Assert.AreEqual(1000, c.Saldo);
            Assert.AreEqual("Cliente1", c.NomeCliente);

        }

        [TestMethod]
        public void TestSaque()
        {
            double valorInicial = 5000;
            double valorSaque = 2000;
            double valorEsperado = valorInicial-valorSaque;

            ContaBanco c = new ContaBanco("Cliente1", valorInicial);

            c.Saque(valorSaque);
            double valor_atual = c.Saldo;
            Assert.AreEqual(valorEsperado, valor_atual);

            //Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => c.Saque(6000));
            //Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => c.Saque(-2));

            try
            {
                c.Saque(6000);
            }
            catch(System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, ContaBanco.SaldoInsuficienteMessage);
            }
            
            try
            {
                c.Saque(-2);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, ContaBanco.ValorNegativoMessage);
            }

        }

        [TestMethod]
        public void TestDeposito()
        {
            ContaBanco c = new ContaBanco("Fulano", 1000);
            c.Deposito(1000);
            Assert.AreEqual(2000, c.Saldo);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => c.Deposito(-2));

        }

        [TestMethod]
        public void TestLog()
        {
            ContaBanco c = new ContaBanco("Audrey", 1200);
            c.Deposito(100);
            c.Deposito(200);
            c.Saque(50);
            c.Saque(150);
            c.Deposito(100);

            var qntOperacoes = c.LogOperacoes.Count;
            Assert.AreEqual(5, qntOperacoes);
        }
    }
}