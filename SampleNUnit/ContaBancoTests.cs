using System.Security.Principal;
using TestesDeSoftwareSample;

namespace SampleNUnit
{   
    [TestFixture]
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
       
        }
        [TearDown]
        public void TearDown()
        {

        }

        [Test, Order(1)]
        public void TestCliente()
        {
            ContaBanco c = new ContaBanco("Pessoa", 1000);
            Assert.IsNotNull(c);
            Assert.That(c.Saldo, Is.EqualTo(1000));
        }

        [Test, Order(2)]
        public void TestSaque()
        {
            double valorInicial = 5000;
            double valorSaque = 2000;
            double valorEsperado = valorInicial - valorSaque;

            ContaBanco c = new ContaBanco("Pessoa", valorInicial);

            c.Saque(valorSaque);
            double valor_atual = c.Saldo;
            Assert.That(valor_atual, Is.EqualTo(valorEsperado));

            Assert.Multiple(() =>
            {
                Assert.Throws<System.ArgumentOutOfRangeException>(() => c.Saque(6000));
                Assert.Throws<System.ArgumentOutOfRangeException>(() => c.Saque(-2));
            });
            

        }

        [Test, Order(3)]
        public void TestDeposito()
        {
            ContaBanco c = new ContaBanco("Pessoa", 1000);
            c.Deposito(1000);
            Assert.That(c.Saldo, Is.EqualTo(2000));
            Assert.Throws<System.ArgumentOutOfRangeException>(() => c.Deposito(-2));

        }

        [Test, Order(4)]
        public void TestLog()
        {
            ContaBanco c = new ContaBanco("Pessoa", 1200);
            c.Deposito(100);
            c.Deposito(200);
            c.Saque(50);
            c.Saque(150);
            c.Deposito(100);

            var qntOperacoes = c.LogOperacoes.Count;
            Assert.That(qntOperacoes, Is.EqualTo(5));
            
        }
    }
}