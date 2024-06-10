using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ferramenta de Análise de Texto");
        Console.Write("Digite o caminho do arquivo de texto: ");
        string caminhoArquivo = Console.ReadLine();

        try
        {
            string texto = File.ReadAllText(caminhoArquivo);

            // Contagem de caracteres, palavras e linhas
            int numCaracteres = texto.Length;
            int numPalavras = ContarPalavras(texto);
            int numLinhas = ContarLinhas(texto);

            Console.WriteLine($"Número de caracteres: {numCaracteres}");
            Console.WriteLine($"Número de palavras: {numPalavras}");
            Console.WriteLine($"Número de linhas: {numLinhas}");

            // Palavras mais frequentes
            var palavrasFrequentes = PalavrasMaisFrequentes(texto, 10);
            Console.WriteLine("\nPalavras mais frequentes:");
            foreach (var palavra in palavrasFrequentes)
            {
                Console.WriteLine($"{palavra.Key}: {palavra.Value} vezes");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
        }
    }

    static int ContarPalavras(string texto)
    {
        var delimitadores = new char[] { ' ', '\r', '\n', '\t', '.', ',', ';', ':', '!', '?', '-', '(', ')', '[', ']', '{', '}', '"' };
        var palavras = texto.Split(delimitadores, StringSplitOptions.RemoveEmptyEntries);
        return palavras.Length;
    }

    static int ContarLinhas(string texto)
    {
        return texto.Split('\n').Length;
    }

    static Dictionary<string, int> PalavrasMaisFrequentes(string texto, int top)
    {
        var delimitadores = new char[] { ' ', '\r', '\n', '\t', '.', ',', ';', ':', '!', '?', '-', '(', ')', '[', ']', '{', '}', '"' };
        var palavras = texto.Split(delimitadores, StringSplitOptions.RemoveEmptyEntries);

        var frequencia = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        foreach (var palavra in palavras)
        {
            if (frequencia.ContainsKey(palavra))
            {
                frequencia[palavra]++;
            }
            else
            {
                frequencia[palavra] = 1;
            }
        }

        return frequencia.OrderByDescending(p => p.Value).Take(top).ToDictionary(p => p.Key, p => p.Value);
    }
}
