using System;
using System.Collections.Generic;

class Game
{
    private const int BaseHealth = 100;
    private const int TowerCost = 10;

    private int baseHealth;
    private List<Tower> towers;
    private List<Enemy> enemies;

    public Game()
    {
        baseHealth = BaseHealth;
        towers = new List<Tower>();
        enemies = new List<Enemy>();
    }

    public void Start()
    {
        Console.WriteLine("Bem-vindo ao Jogo de Defesa de Torre!");
        Console.WriteLine("Sua base tem 100 de vida. Proteja-a das ondas de inimigos!");

        while (baseHealth > 0)
        {
            SpawnEnemies();
            UpdateGame();
            if (baseHealth <= 0)
            {
                Console.WriteLine("Sua base foi destruída. Fim de jogo.");
                break;
            }
            if (enemies.Count == 0)
            {
                Console.WriteLine("Você venceu! Todas as ondas de inimigos foram derrotadas.");
                break;
            }
            Console.WriteLine("Pressione qualquer tecla para avançar para a próxima onda...");
            Console.ReadKey();
        }
    }

    private void SpawnEnemies()
    {
        Random random = new Random();
        int numEnemies = random.Next(3, 6);
        for (int i = 0; i < numEnemies; i++)
        {
            enemies.Add(new Enemy(random.Next(5, 10)));
        }
        Console.WriteLine($"Uma nova onda de {numEnemies} inimigos se aproxima da sua base!");
    }

    private void UpdateGame()
    {
        MoveEnemies();
        AttackWithTowers();
        CheckBaseHealth();
    }

    private void MoveEnemies()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.Move();
        }
    }

    private void AttackWithTowers()
    {
        foreach (Tower tower in towers)
        {
            foreach (Enemy enemy in enemies)
            {
                if (Math.Abs(tower.Position - enemy.Position) <= tower.Range)
                {
                    tower.Attack(enemy);
                    if (enemy.IsDestroyed())
                    {
                        enemies.Remove(enemy);
                        break;
                    }
                }
            }
        }
    }

    private void CheckBaseHealth()
    {
        foreach (Enemy enemy in enemies)
        {
            if (enemy.Position == 0)
            {
                baseHealth -= enemy.Damage;
                Console.WriteLine($"Um inimigo atacou sua base! -{enemy.Damage} de vida");
            }
        }
    }

    public void BuildTower(int position)
    {
        if (baseHealth > 0 && position > 0)
        {
            if (baseHealth >= TowerCost)
            {
                towers.Add(new Tower(position));
                baseHealth -= TowerCost;
                Console.WriteLine($"Torre construída na posição {position}. -{TowerCost} de vida");
            }
            else
            {
                Console.WriteLine("Você não tem vida suficiente para construir uma torre.");
            }
        }
        else
        {
            Console.WriteLine("Não é possível construir uma torre nesta posição.");
        }
    }
}

class Tower
{
    public int Position { get; }
    public int Range { get; }
    public int Damage { get; }

    public Tower(int position)
    {
        Position = position;
        Range = 2; // Alcance da torre
        Damage = 10; // Dano da torre
    }

    public void Attack(Enemy enemy)
    {
        enemy.TakeDamage(Damage);
        Console.WriteLine($"Torre na posição {Position} ataca inimigo causando {Damage} de dano!");
    }
}

class Enemy
{
    public int Position { get; private set; }
    public int Damage { get; }
    
    public Enemy(int damage)
    {
        Position = 10; // Posição inicial do inimigo
        Damage = damage;
    }

    public void Move()
    {
        Position--;
    }

    public void TakeDamage(int damage)
    {
        Position--;
    }

    public bool IsDestroyed()
    {
        return Position <= 0;
    }
}

class Program
{
    static void Main()
    {
        Game game = new Game();
        game.Start();
    }
}
