using TestesDeSoftwareSample;

var conta = new ContaBanco("Myron", 10000);
conta.Saque(1000);
conta.PrintLog();
Console.WriteLine($"Cliente: {conta.NomeCliente} | Saldo: {conta.Saldo}");
