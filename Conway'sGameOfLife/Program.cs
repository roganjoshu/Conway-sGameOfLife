using System;

namespace Conway_sGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 50;
            int width = size; int height = size;
            var Board = new Board(width, height);
            int iteration = 0;

            do
            {
                Console.Clear();
                Board.DrawBoard();

                for (int row = 0; row < Board.height; row++)
                {
                    for (int col = 0; col < Board.width; col++)
                    {
                        Board.game_board[row, col].getAliveNeighbours(Board, row, col);
                    }
                }

                for (int row = 0; row < Board.height; row++)
                {
                    for (int col = 0; col < Board.width; col++)
                    {
                        if (Board.game_board[row, col].state == true)
                        {
                            if (Board.game_board[row, col].liveNeighbours < 2 || Board.game_board[row, col].liveNeighbours > 3)
                            {
                                Board.game_board[row, col].state = false;
                            }
                        }
                        if (Board.game_board[row, col].state == false)
                        {
                            if (Board.game_board[row, col].liveNeighbours == 3)
                            {
                                Board.game_board[row, col].state = true;
                            }
                        }
                    }
                }

                iteration++;
                System.Threading.Thread.Sleep(1000);

            } while (iteration < 100);
        }
    }
}
