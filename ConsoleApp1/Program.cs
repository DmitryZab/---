using System;

class Program
{
    static void Main(string[] args)
    {
        char[,] board = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        bool isPlayer1 = true;
        int row, col;

        while (true)
        {
            PrintBoard(board);
            Console.WriteLine("Введите строку и столбец (например, 1 2) для " + (isPlayer1 ? "X" : "O"));
            string[] input = Console.ReadLine().Split();
            if (input.Length != 2)
            {
                Console.WriteLine("Не корректно введены строка или столбец. Попробуйте еще раз.");
                continue;
            }
            row = int.Parse(input[0]) - 1;
            col = int.Parse(input[1]) - 1;



            if (row < 0 || row > 2 || col < 0 || col > 2)
            {
                Console.WriteLine("Недопустимая строка или столбец. Попробуйте еще раз.");
            }
            else if (board[row, col] != ' ')
            {
                Console.WriteLine("Эта ячейка уже занята. Попробуйте еще раз.");
            }
            else
            {
                board[row, col] = isPlayer1 ? 'X' : 'O';
                if (CheckWin(board))
                {
                    Console.WriteLine((isPlayer1 ? "X" : "O") + " выиграл!");
                    break;
                }
                else if (CheckTie(board))
                {
                    Console.WriteLine("Это ничья!");
                    break;
                }
                else
                {
                    isPlayer1 = !isPlayer1;
                }
            }
        }
    }

    static bool CheckWin(char[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2])
            {
                return true;
            }
            if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[0, i] == board[2, i])
            {
                return true;
            }
        }
        if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2])
        {
            return true;
        }
        if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0])
        {
            return true;
        }
        return false;
    }

    static bool CheckTie(char[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == ' ')
                {
                    return false;
                }
            }
        }
        return true;
    }

    static void PrintBoard(char[,] board)
    {
        Console.WriteLine("  1 2 3");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + 1 + " ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
