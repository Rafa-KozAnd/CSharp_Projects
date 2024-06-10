using System;
using System.Collections.Generic;

class Filme
{
    public string Titulo { get; set; }
    public string Diretor { get; set; }
    public int Ano { get; set; }

    public Filme(string titulo, string diretor, int ano)
    {
        Titulo = titulo;
        Diretor = diretor;
        Ano = ano;
    }

    public override string ToString()
    {
        return $"{Titulo} (dirigido por {Diretor}, {Ano})";
    }
}

class Program
{
    static void Main()
    {
        List<Filme> catalogo = new List<Filme>();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("1. Adicionar Filme");
            Console.WriteLine("2. Listar Filmes");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o título do filme: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Digite o nome do diretor: ");
                    string diretor = Console.ReadLine();
                    Console.Write("Digite o ano de lançamento: ");
                    int ano = int.Parse(Console.ReadLine());
                    catalogo.Add(new Filme(titulo, diretor, ano));
                    Console.WriteLine("Filme adicionado com sucesso!\n");
                    break;
                case "2":
                    Console.WriteLine("\nCatálogo de Filmes:");
                    foreach (var filme in catalogo)
                    {
                        Console.WriteLine(filme);
                    }
                    Console.WriteLine();
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
}
