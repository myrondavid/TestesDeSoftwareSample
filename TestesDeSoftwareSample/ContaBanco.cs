using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDeSoftwareSample
{
    public class ContaBanco
    {
        public const string SaldoInsuficienteMessage = "Saldo insuficiente";
        public const string ValorNegativoMessage = "Valor negativo";

        public string NomeCliente { get; set; }
        public double Saldo { get; set; }
        public List<string> LogOperacoes {
            get;
            set;
        }

        

        public ContaBanco(string cliente, double saldo)
        {
            NomeCliente = cliente;
            Saldo = saldo;
            LogOperacoes = new List<string>();
        }

        public void Saque(double valor)
        {
            if (valor > Saldo)
            {
                throw new ArgumentOutOfRangeException("valor", valor, SaldoInsuficienteMessage);
            }
                
            if (valor < 0)
            {
                throw new ArgumentOutOfRangeException("valor", valor, ValorNegativoMessage);
            }

            Saldo -= valor;
            LogOperacoes.Add($"Saque no valor de {valor} efetuado em {DateTime.Now.ToString()}");
        }

        public void Deposito(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentOutOfRangeException("Valor negativo");
            }
            Saldo += valor;
            LogOperacoes.Add($"Depósito no valor de {valor} efetuado em {DateTime.Now.ToString()}");
        }


        

        public void PrintLog()
        {
            foreach(var log in LogOperacoes)
            {
                Console.WriteLine(log);
            }
        }
    }
}
