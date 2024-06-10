using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bem-vindo ao Simulador de Empréstimo!");

        // Solicitar dados do usuário
        Console.Write("Digite o valor do empréstimo: ");
        double valorEmprestimo = Convert.ToDouble(Console.ReadLine());

        Console.Write("Digite a taxa de juros anual (em %): ");
        double taxaJurosAnual = Convert.ToDouble(Console.ReadLine());

        Console.Write("Digite o número de anos para o empréstimo: ");
        int numeroAnos = Convert.ToInt32(Console.ReadLine());

        // Converter taxa de juros anual para mensal
        double taxaJurosMensal = taxaJurosAnual / 12 / 100;
        int numeroMeses = numeroAnos * 12;

        // Calcular pagamento mensal usando a fórmula de anuidade
        double pagamentoMensal = (valorEmprestimo * taxaJurosMensal) / (1 - Math.Pow(1 + taxaJurosMensal, -numeroMeses));
        double totalPago = pagamentoMensal * numeroMeses;

        // Exibir resultados
        Console.WriteLine($"\nDetalhes do Empréstimo:");
        Console.WriteLine($"Valor do Empréstimo: R$ {valorEmprestimo:F2}");
        Console.WriteLine($"Taxa de Juros Anual: {taxaJurosAnual}%");
        Console.WriteLine($"Número de Anos: {numeroAnos}");
        Console.WriteLine($"Pagamento Mensal: R$ {pagamentoMensal:F2}");
        Console.WriteLine($"Total Pago ao Final: R$ {totalPago:F2}");
    }
}
