using System;
using System.Collections.Generic;

class Contato
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }

    public Contato(string nome, string telefone, string email)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Telefone: {Telefone}, Email: {Email}";
    }
}

class Program
{
    static void Main()
    {
        List<Contato> agenda = new List<Contato>();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("1. Adicionar Contato");
            Console.WriteLine("2. Listar Contatos");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Digite o telefone: ");
                    string telefone = Console.ReadLine();
                    Console.Write("Digite o e-mail: ");
                    string email = Console.ReadLine();
                    agenda.Add(new Contato(nome, telefone, email));
                    Console.WriteLine("Contato adicionado com sucesso!\n");
                    break;
                case "2":
                    Console.WriteLine("\nAgenda de Contatos:");
                    foreach (var contato in agenda)
                    {
                        Console.WriteLine(contato);
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
