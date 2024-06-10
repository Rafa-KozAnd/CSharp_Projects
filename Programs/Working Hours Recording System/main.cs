using System;
using System.Collections.Generic;

class RegistroHoras
{
    public DateTime Data { get; set; }
    public int HorasTrabalhadas { get; set; }

    public RegistroHoras(DateTime data, int horasTrabalhadas)
    {
        Data = data;
        HorasTrabalhadas = horasTrabalhadas;
    }

    public override string ToString()
    {
        return $"{Data.ToShortDateString()}: {HorasTrabalhadas} horas";
    }
}

class Program
{
    static void Main()
    {
        List<RegistroHoras> registros = new List<RegistroHoras>();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("1. Registrar Horas");
            Console.WriteLine("2. Listar Registros");
            Console.WriteLine("3. Total de Horas Trabalhadas");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite a data (dd/mm/aaaa): ");
                    DateTime data = DateTime.Parse(Console.ReadLine());
                    Console.Write("Digite o número de horas trabalhadas: ");
                    int horas = int.Parse(Console.ReadLine());
                    registros.Add(new RegistroHoras(data, horas));
                    Console.WriteLine("Horas registradas com sucesso!\n");
                    break;
                case "2":
                    Console.WriteLine("\nRegistros de Horas:");
                    foreach (var registro in registros)
                    {
                        Console.WriteLine(registro);
                    }
                    Console.WriteLine();
                    break;
                case "3":
                    int totalHoras = 0;
                    foreach (var registro in registros)
                    {
                        totalHoras += registro.HorasTrabalhadas;
                    }
                    Console.WriteLine($"\nTotal de horas trabalhadas: {totalHoras} horas\n");
                    break;
                case "4":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida!\n");
                    break;
            }
        }
    }
}
