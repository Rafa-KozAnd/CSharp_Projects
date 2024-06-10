using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ferramenta de Backup de Arquivos");
        
        while (true)
        {
            Console.WriteLine("1. Fazer backup imediato");
            Console.WriteLine("2. Agendar backup");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    FazerBackupImediato();
                    break;
                case "2":
                    AgendarBackup();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opção inválida!\n");
                    break;
            }
        }
    }

    static void FazerBackupImediato()
    {
        Console.Write("Digite o caminho do diretório ou arquivo a ser copiado: ");
        string origem = Console.ReadLine();

        Console.Write("Digite o caminho do diretório de backup: ");
        string destino = Console.ReadLine();

        try
        {
            if (Directory.Exists(origem))
            {
                CopyDirectory(origem, destino);
            }
            else if (File.Exists(origem))
            {
                CopyFile(origem, destino);
            }
            else
            {
                Console.WriteLine("Caminho de origem não encontrado.\n");
                return;
            }
            Console.WriteLine("Backup concluído com sucesso!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao fazer backup: {ex.Message}\n");
        }
    }

    static void AgendarBackup()
    {
        Console.Write("Digite o caminho do diretório ou arquivo a ser copiado: ");
        string origem = Console.ReadLine();

        Console.Write("Digite o caminho do diretório de backup: ");
        string destino = Console.ReadLine();

        Console.Write("Digite o intervalo de tempo para o backup em minutos: ");
        if (int.TryParse(Console.ReadLine(), out int intervalo))
        {
            Timer timer = new Timer(_ => BackupTimerCallback(origem, destino), null, 0, intervalo * 60000);
            Console.WriteLine($"Backup agendado a cada {intervalo} minutos. Pressione qualquer tecla para parar...\n");
            Console.ReadKey();
            timer.Dispose();
        }
        else
        {
            Console.WriteLine("Intervalo de tempo inválido.\n");
        }
    }

    static void BackupTimerCallback(string origem, string destino)
    {
        try
        {
            if (Directory.Exists(origem))
            {
                CopyDirectory(origem, destino);
            }
            else if (File.Exists(origem))
            {
                CopyFile(origem, destino);
            }
            Console.WriteLine($"Backup realizado em: {DateTime.Now}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao fazer backup: {ex.Message}\n");
        }
    }

    static void CopyDirectory(string sourceDir, string destDir)
    {
        if (!Directory.Exists(destDir))
        {
            Directory.CreateDirectory(destDir);
        }

        foreach (string file in Directory.GetFiles(sourceDir))
        {
            string destFile = Path.Combine(destDir, Path.GetFileName(file));
            File.Copy(file, destFile, true);
        }

        foreach (string subdir in Directory.GetDirectories(sourceDir))
        {
            string destSubdir = Path.Combine(destDir, Path.GetFileName(subdir));
            CopyDirectory(subdir, destSubdir);
        }
    }

    static void CopyFile(string sourceFile, string destDir)
    {
        if (!Directory.Exists(destDir))
        {
            Directory.CreateDirectory(destDir);
        }
        string destFile = Path.Combine(destDir, Path.GetFileName(sourceFile));
        File.Copy(sourceFile, destFile, true);
    }
}
