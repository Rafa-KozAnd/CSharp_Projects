using System;
using System.Collections.Generic;
using System.Linq;

class Evento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime Data { get; set; }
    public List<Bilhete> Bilhetes { get; set; } = new List<Bilhete>();

    public Evento(int id, string nome, DateTime data)
    {
        Id = id;
        Nome = nome;
        Data = data;
    }

    public override string ToString()
    {
        return $"{Id} - {Nome} ({Data.ToShortDateString()})";
    }
}

class Bilhete
{
    public int Id { get; set; }
    public int EventoId { get; set; }
    public string NomeParticipante { get; set; }
    public DateTime DataEmissao { get; set; }

    public Bilhete(int id, int eventoId, string nomeParticipante)
    {
        Id = id;
        EventoId = eventoId;
        NomeParticipante = nomeParticipante;
        DataEmissao = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Bilhete ID: {Id}, Evento ID: {EventoId}, Participante: {NomeParticipante}, Emitido em: {DataEmissao}";
    }
}

class SistemaEmissaoBilhetes
{
    private List<Evento> eventos = new List<Evento>();
    private List<Bilhete> bilhetes = new List<Bilhete>();
    private int proximoIdEvento = 1;
    private int proximoIdBilhete = 1;

    public void CriarEvento(string nome, DateTime data)
    {
        var evento = new Evento(proximoIdEvento++, nome, data);
        eventos.Add(evento);
        Console.WriteLine("Evento criado com sucesso!\n");
    }

    public void EmitirBilhete(int eventoId, string nomeParticipante)
    {
        var evento = eventos.FirstOrDefault(e => e.Id == eventoId);
        if (evento != null)
        {
            var bilhete = new Bilhete(proximoIdBilhete++, eventoId, nomeParticipante);
            evento.Bilhetes.Add(bilhete);
            bilhetes.Add(bilhete);
            Console.WriteLine("Bilhete emitido com sucesso!\n");
        }
        else
        {
            Console.WriteLine("Evento não encontrado.\n");
        }
    }

    public void VisualizarBilhetes()
    {
        Console.WriteLine("Bilhetes Emitidos:");
        foreach (var bilhete in bilhetes)
        {
            Console.WriteLine(bilhete);
        }
        Console.WriteLine();
    }

    public void BuscarBilhetePorId(int id)
    {
        var bilhete = bilhetes.FirstOrDefault(b => b.Id == id);
        if (bilhete != null)
        {
            Console.WriteLine("Bilhete Encontrado:");
            Console.WriteLine(bilhete);
        }
        else
        {
            Console.WriteLine("Bilhete não encontrado.\n");
        }
    }

    public void ListarEventos()
    {
        Console.WriteLine("Eventos Disponíveis:");
        foreach (var evento in eventos)
        {
            Console.WriteLine(evento);
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        SistemaEmissaoBilhetes sistema = new SistemaEmissaoBilhetes();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Sistema de Emissão de Bilhetes para Eventos");
            Console.WriteLine("1. Criar Evento");
            Console.WriteLine("2. Emitir Bilhete");
            Console.WriteLine("3. Visualizar Bilhetes Emitidos");
            Console.WriteLine("4. Buscar Bilhete por ID");
            Console.WriteLine("5. Listar Eventos");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o nome do evento: ");
                    string nomeEvento = Console.ReadLine();
                    Console.Write("Digite a data do evento (dd/mm/aaaa): ");
                    DateTime dataEvento = DateTime.Parse(Console.ReadLine());
                    sistema.CriarEvento(nomeEvento, dataEvento);
                    break;
                case "2":
                    Console.Write("Digite o ID do evento: ");
                    int eventoId = int.Parse(Console.ReadLine());
                    Console.Write("Digite o nome do participante: ");
                    string nomeParticipante = Console.ReadLine();
                    sistema.EmitirBilhete(eventoId, nomeParticipante);
                    break;
                case "3":
                    sistema.VisualizarBilhetes();
                    break;
                case "4":
                    Console.Write("Digite o ID do bilhete: ");
                    int bilheteId = int.Parse(Console.ReadLine());
                    sistema.BuscarBilhetePorId(bilheteId);
                    break;
                case "5":
                    sistema.ListarEventos();
                    break;
                case "6":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida!\n");
                    break;
            }
        }
    }
}
