using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDeSoftwareSample;

namespace SampleXUnit
{
    public class CalculadoraTests : IDisposable
    {
        public Calculadora calc { get; set; }
        public CalculadoraTests()
        {
            calc = new Calculadora();
        }

        public void Dispose()
        {
            Console.WriteLine("Testes finalizados");
        }

        [Theory(DisplayName = "Testa o método de soma")]
        [Trait("Calculo", "Soma")]
        [InlineData(1, 1, 2)]
        [InlineData(10, 5, 11)]
        [InlineData(1, 0, 1)]
        [InlineData(1.5, 1, 2.5)]
        public void SomaTest(double n1, double n2, double esperado)
        {
            var resultado = calc.Soma(n1, n2);
            Assert.Equal(esperado, resultado);
        }


        [Fact(DisplayName = "Testa o método de subtração")]
        [Trait("Calculo", "Subtração")]
        public void SubtracaoTest()
        {
            Assert.Equal(5, calc.Sub(10, 5));
        }


        [Fact(DisplayName = "Testa o método de Multiplicação")]
        [Trait("Calculo", "Multiplicacão")]
        public void MultiplicacaoTest()
        {
            Assert.Equal(50, calc.Mult(10, 5));
        }


        [Fact(DisplayName = "Testa o método de Divisão")]
        [Trait("Calculo", "Divisão")]
        public void DivisaoTest()
        {
            Assert.Equal(2, calc.Div(10, 5));
        }


    }
}
