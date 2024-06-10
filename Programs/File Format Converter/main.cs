using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Conversor de Formato de Arquivo");
            Console.WriteLine("1. Converter .txt para .csv");
            Console.WriteLine("2. Converter .csv para .txt");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ConverterTxtParaCsv();
                    break;
                case "2":
                    ConverterCsvParaTxt();
                    break;
                case "3":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida!\n");
                    break;
            }
        }
    }

    static void ConverterTxtParaCsv()
    {
        Console.Write("Digite o caminho do arquivo .txt: ");
        string caminhoTxt = Console.ReadLine();
        Console.Write("Digite o caminho para salvar o arquivo .csv: ");
        string caminhoCsv = Console.ReadLine();

        try
        {
            var linhas = File.ReadAllLines(caminhoTxt);
            var csvLinhas = linhas.Select(l => string.Join(",", l.Split(' ')));

            File.WriteAllLines(caminhoCsv, csvLinhas);
            Console.WriteLine("Conversão de .txt para .csv concluída com sucesso!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}\n");
        }
    }

    static void ConverterCsvParaTxt()
    {
        Console.Write("Digite o caminho do arquivo .csv: ");
        string caminhoCsv = Console.ReadLine();
        Console.Write("Digite o caminho para salvar o arquivo .txt: ");
        string caminhoTxt = Console.ReadLine();

        try
        {
            var linhas = File.ReadAllLines(caminhoCsv);
            var txtLinhas = linhas.Select(l => string.Join(" ", l.Split(',')));

            File.WriteAllLines(caminhoTxt, txtLinhas);
            Console.WriteLine("Conversão de .csv para .txt concluída com sucesso!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}\n");
        }
    }
}
