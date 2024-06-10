using System;
using System.Collections.Generic;

class EntradaDiario
{
    public DateTime Data { get; set; }
    public string Conteudo { get; set; }

    public EntradaDiario(DateTime data, string conteudo)
    {
        Data = data;
        Conteudo = conteudo;
    }

    public override string ToString()
    {
        return $"{Data.ToShortDateString()}: {Conteudo}";
    }
}

class DiarioPessoal
{
    private List<EntradaDiario> entradas;

    public DiarioPessoal()
    {
        entradas = new List<EntradaDiario>();
    }

    public void AdicionarEntrada(DateTime data, string conteudo)
    {
        entradas.Add(new EntradaDiario(data, conteudo));
        Console.WriteLine("Entrada adicionada com sucesso!\n");
    }

    public void VisualizarEntradas()
    {
        Console.WriteLine("Entradas no Diário:");
        foreach (var entrada in entradas)
        {
            Console.WriteLine(entrada);
        }
        Console.WriteLine();
    }

    public void EditarEntrada(DateTime data, string novoConteudo)
    {
        var entrada = entradas.Find(e => e.Data.Date == data.Date);
        if (entrada != null)
        {
            entrada.Conteudo = novoConteudo;
            Console.WriteLine("Entrada editada com sucesso!\n");
        }
        else
        {
            Console.WriteLine("Entrada não encontrada.\n");
        }
    }

    public void ExcluirEntrada(DateTime data)
    {
        var entrada = entradas.Find(e => e.Data.Date == data.Date);
        if (entrada != null)
        {
            entradas.Remove(entrada);
            Console.WriteLine("Entrada excluída com sucesso!\n");
        }
        else
        {
            Console.WriteLine("Entrada não encontrada.\n");
        }
    }
}

class Program
{
    static void Main()
    {
        DiarioPessoal diario = new DiarioPessoal();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("1. Adicionar Entrada");
            Console.WriteLine("2. Visualizar Entradas");
            Console.WriteLine("3. Editar Entrada");
            Console.WriteLine("4. Excluir Entrada");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite a data (dd/mm/aaaa): ");
                    DateTime dataAdicionar = DateTime.Parse(Console.ReadLine());
                    Console.Write("Digite o conteúdo da entrada: ");
                    string conteudo = Console.ReadLine();
                    diario.AdicionarEntrada(dataAdicionar, conteudo);
                    break;
                case "2":
                    diario.VisualizarEntradas();
                    break;
                case "3":
                    Console.Write("Digite a data da entrada a editar (dd/mm/aaaa): ");
                    DateTime dataEditar = DateTime.Parse(Console.ReadLine());
                    Console.Write("Digite o novo conteúdo da entrada: ");
                    string novoConteudo = Console.ReadLine();
                    diario.EditarEntrada(dataEditar, novoConteudo);
                    break;
                case "4":
                    Console.Write("Digite a data da entrada a excluir (dd/mm/aaaa): ");
                    DateTime dataExcluir = DateTime.Parse(Console.ReadLine());
                    diario.ExcluirEntrada(dataExcluir);
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida!\n");
                    break;
            }
        }
    }
}
