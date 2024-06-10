using System;

class Tank
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public int DefensePower { get; set; }

    public Tank(string name, int health, int attackPower, int defensePower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
        DefensePower = defensePower;
    }

    public void Attack(Tank target)
    {
        int damage = AttackPower - target.DefensePower;
        if (damage < 0) damage = 0;
        target.Health -= damage;
        Console.WriteLine($"{Name} ataca {target.Name} causando {damage} de dano!");
    }

    public bool IsDestroyed()
    {
        return Health <= 0;
    }

    public void DisplayStatus()
    {
        Console.WriteLine($"{Name} - Saúde: {Health}");
    }
}

class Program
{
    static void Main()
    {
        Tank playerTank = new Tank("Jogador", 100, 20, 5);
        Tank enemyTank = new Tank("Inimigo", 100, 15, 10);

        while (true)
        {
            Console.Clear();
            playerTank.DisplayStatus();
            enemyTank.DisplayStatus();

            if (playerTank.IsDestroyed())
            {
                Console.WriteLine("Você foi destruído! Fim de jogo.");
                break;
            }
            if (enemyTank.IsDestroyed())
            {
                Console.WriteLine("Você venceu! O tanque inimigo foi destruído.");
                break;
            }

            Console.WriteLine("Escolha sua ação:");
            Console.WriteLine("1. Atacar");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    playerTank.Attack(enemyTank);
                    break;
                default:
                    Console.WriteLine("Escolha inválida, tente novamente.");
                    continue;
            }

            if (!enemyTank.IsDestroyed())
            {
                enemyTank.Attack(playerTank);
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
