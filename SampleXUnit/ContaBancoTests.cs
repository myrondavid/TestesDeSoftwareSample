using TestesDeSoftwareSample;

namespace SampleXUnit
{
    public class ContaBancoTests
    {
        [Fact(DisplayName = "Testa a instaciação de uma conta")]
        public void TestInit()
        {
            ContaBanco c = new ContaBanco("Cliente1", 1000);
            Assert.NotNull(c);
            Assert.Equal(1000, c.Saldo);
            Assert.Equal("Cliente1", c.NomeCliente);
        }

        [Fact(DisplayName = "Testa o comportamento do método Saque()")]
        public void TestSaque()
        {
            double valorInicial = 5000;
            double valorSaque = 2000;
            double valorEsperado = valorInicial - valorSaque;

            ContaBanco c = new ContaBanco("Pessoa", valorInicial);

            c.Saque(valorSaque);
            double valor_atual = c.Saldo;
            Assert.Equal(valorEsperado, c.Saldo);

            Assert.Throws<System.ArgumentOutOfRangeException>(() => c.Saque(6000));
            Assert.Throws<System.ArgumentOutOfRangeException>(() => c.Saque(-2));

        }

        [Fact(DisplayName = "Testa o comportamento do método Deposito ()")]
        public void TestDeposito()
        {
            ContaBanco c = new ContaBanco("Pessoa", 1000);
            c.Deposito(1000);
            Assert.Equal(2000, c.Saldo);
            Assert.Throws<System.ArgumentOutOfRangeException>(() => c.Deposito(-2));

        }

        [Fact(DisplayName = "Testa o comportamento da propriedade LogOperaoes")]
        public void TestLog()
        {
            ContaBanco c = new ContaBanco("Pessoa", 1200);
            c.Deposito(100);
            c.Deposito(200);
            c.Saque(50);
            c.Saque(150);
            c.Deposito(100);

            var qntOperacoes = c.LogOperacoes.Count;
            Assert.Equal(5, qntOperacoes);
        }
    }
}