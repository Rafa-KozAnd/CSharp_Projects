using System;

class Sudoku
{
    private int[,] board;

    public Sudoku()
    {
        board = new int[9, 9];
        Initialize();
    }

    private void Initialize()
    {
        // Tabuleiro de exemplo para início do jogo
        int[,] exampleBoard = {
            {5, 3, 0, 0, 7, 0, 0, 0, 0},
            {6, 0, 0, 1, 9, 5, 0, 0, 0},
            {0, 9, 8, 0, 0, 0, 0, 6, 0},
            {8, 0, 0, 0, 6, 0, 0, 0, 3},
            {4, 0, 0, 8, 0, 3, 0, 0, 1},
            {7, 0, 0, 0, 2, 0, 0, 0, 6},
            {0, 6, 0, 0, 0, 0, 2, 8, 0},
            {0, 0, 0, 4, 1, 9, 0, 0, 5},
            {0, 0, 0, 0, 8, 0, 0, 7, 9}
        };

        // Copiar o tabuleiro de exemplo para o tabuleiro do jogo
        Array.Copy(exampleBoard, board, exampleBoard.Length);
    }

    public void PrintBoard()
    {
        Console.WriteLine("+-------+-------+-------+");
        for (int i = 0; i < 9; i++)
        {
            if (i != 0 && i % 3 == 0)
                Console.WriteLine("|-------+-------+-------|");

            for (int j = 0; j < 9; j++)
            {
                if (j != 0 && j % 3 == 0)
                    Console.Write("| ");
                Console.Write(board[i, j] == 0 ? "  " : $"{board[i, j]} ");
            }
            Console.WriteLine("|");
        }
        Console.WriteLine("+-------+-------+-------+");
    }
}

class Program
{
    static void Main()
    {
        Sudoku sudoku = new Sudoku();
        sudoku.PrintBoard();
    }
}
