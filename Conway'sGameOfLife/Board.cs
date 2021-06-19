using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway_sGameOfLife
{
    class Board
    {
        public int height;
        public int width;
        public Cell[,] game_board;

        public Board(int row, int col)
        {
            this.height = row;
            this.width = col;
            game_board = new Cell[row, col];
            GenerateBoard();
        }

        public void GenerateBoard()
        {
            for (int row = 0; row < this.height; row++)
            {
                for (int col = 0; col < this.width; col++)
                {
                    game_board[row, col] = new Cell();
                }
            }
        }

        public void DrawBoard()
        {
            Console.WriteLine("Printing board...\n");
            for (int row = 0; row < this.height; row++)
            {
                Console.WriteLine();
                for (int col = 0; col < this.width; col++)
                {
                    if (game_board[row, col].state == true)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }
                }
            }
        }
    }
}
