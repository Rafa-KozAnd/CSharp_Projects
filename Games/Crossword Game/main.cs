using System;
using System.Collections.Generic;

class Program
{
    static char[,] board;
    static List<Word> words;

    static void Main()
    {
        InitializeBoard();
        PlaceWords();
        PlayGame();
    }

    static void InitializeBoard()
    {
        // Define o tamanho do tabuleiro
        board = new char[10, 10];

        // Preenche o tabuleiro com espaços em branco
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                board[i, j] = ' ';
            }
        }

        // Inicializa a lista de palavras
        words = new List<Word>
        {
            new Word("CSharp", "Linguagem de programação usada no .NET", 0, 0, true),
            new Word("Java", "Linguagem de programação popular", 2, 0, false),
            new Word("Python", "Linguagem de programação conhecida pela simplicidade", 4, 0, true),
            new Word("HTML", "Linguagem de marcação usada para criar páginas web", 6, 0, false),
            new Word("CSS", "Linguagem usada para estilizar páginas web", 8, 0, true)
        };
    }

    static void PlaceWords()
    {
        foreach (var word in words)
        {
            for (int i = 0; i < word.Text.Length; i++)
            {
                if (word.IsHorizontal)
                {
                    board[word.Row, word.Column + i] = word.Text[i];
                }
                else
                {
                    board[word.Row + i, word.Column] = word.Text[i];
                }
            }
        }
    }

    static void PlayGame()
    {
        bool gameFinished = false;
        while (!gameFinished)
        {
            Console.Clear();
            DisplayBoard();
            DisplayClues();

            Console.WriteLine("Digite a palavra completa e suas coordenadas (ex: CSharp 0 0 horizontal):");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');

            if (parts.Length != 4)
            {
                Console.WriteLine("Entrada inválida. Tente novamente.");
                continue;
            }

            string guessedWord = parts[0];
            int row = int.Parse(parts[1]);
            int col = int.Parse(parts[2]);
            bool isHorizontal = parts[3].ToLower() == "horizontal";

            if (CheckWord(guessedWord, row, col, isHorizontal))
            {
                Console.WriteLine("Correto!");
                for (int i = 0; i < guessedWord.Length; i++)
                {
                    if (isHorizontal)
                    {
                        board[row, col + i] = guessedWord[i];
                    }
                    else
                    {
                        board[row + i, col] = guessedWord[i];
                    }
                }
            }
            else
            {
                Console.WriteLine("Palavra incorreta. Tente novamente.");
            }

            gameFinished = CheckIfGameFinished();
        }

        Console.WriteLine("Parabéns! Você completou o jogo de palavras cruzadas!");
    }

    static void DisplayBoard()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void DisplayClues()
    {
        foreach (var word in words)
        {
            Console.WriteLine($"{word.Text}: {word.Clue} ({word.Row}, {word.Column}) {(word.IsHorizontal ? "horizontal" : "vertical")}");
        }
    }

    static bool CheckWord(string word, int row, int col, bool isHorizontal)
    {
        foreach (var w in words)
        {
            if (w.Text == word && w.Row == row && w.Column == col && w.IsHorizontal == isHorizontal)
            {
                return true;
            }
        }
        return false;
    }

    static bool CheckIfGameFinished()
    {
        foreach (var word in words)
        {
            for (int i = 0; i < word.Text.Length; i++)
            {
                if (word.IsHorizontal)
                {
                    if (board[word.Row, word.Column + i] != word.Text[i])
                    {
                        return false;
                    }
                }
                else
                {
                    if (board[word.Row + i, word.Column] != word.Text[i])
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
}

class Word
{
    public string Text { get; }
    public string Clue { get; }
    public int Row { get; }
    public int Column { get; }
    public bool IsHorizontal { get; }

    public Word(string text, string clue, int row, int column, bool isHorizontal)
    {
        Text = text;
        Clue = clue;
        Row = row;
        Column = column;
        IsHorizontal = isHorizontal;
    }
}
