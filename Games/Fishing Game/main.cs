using System;

class Fish
{
    public string Name { get; set; }
    public int CatchProbability { get; set; }

    public Fish(string name, int catchProbability)
    {
        Name = name;
        CatchProbability = catchProbability;
    }
}

class FishingGame
{
    private const int LakeWidth = 50;
    private const int LakeHeight = 10;
    private const char LakeTile = '~';
    private const char FishTile = 'F';

    private Fish[] fishes = {
        new Fish("Truta", 80),
        new Fish("Salmão", 70),
        new Fish("Bagre", 60),
        new Fish("Dourado", 50),
        new Fish("Tilápia", 40)
    };

    private Random random = new Random();
    private int playerPosition = LakeWidth / 2;

    public void Start()
    {
        Console.WriteLine("Bem-vindo ao Jogo de Pesca!");
        Console.WriteLine("Pressione 'L' para lançar a linha de pesca.");

        while (true)
        {
            DisplayLake();
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.L)
            {
                Fish fish = TryCatchFish();
                if (fish != null)
                {
                    Console.WriteLine($"Você pegou um(a) {fish.Name}!");
                }
                else
                {
                    Console.WriteLine("Você não pegou nenhum peixe.");
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(true);
            }
        }
    }

    private void DisplayLake()
    {
        Console.Clear();
        for (int y = 0; y < LakeHeight; y++)
        {
            for (int x = 0; x < LakeWidth; x++)
            {
                if (x == playerPosition && y == LakeHeight - 1)
                {
                    Console.Write('O');
                }
                else if (random.Next(10) == 0)
                {
                    Console.Write(FishTile);
                }
                else
                {
                    Console.Write(LakeTile);
                }
            }
            Console.WriteLine();
        }
    }

    private Fish TryCatchFish()
    {
        int chance = random.Next(101);
        foreach (Fish fish in fishes)
        {
            if (chance <= fish.CatchProbability)
            {
                return fish;
            }
        }
        return null;
    }
}

class Program
{
    static void Main()
    {
        FishingGame game = new FishingGame();
        game.Start();
    }
}
