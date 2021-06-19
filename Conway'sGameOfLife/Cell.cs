using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway_sGameOfLife
{
    class Cell
    {
        public bool state = false;
        public int value = 0;
        public int liveNeighbours = 0;
        public Cell()
        {
            SetCellState();
        }

        public void SetCellState()
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 11);

            if (value <= 3)
            {
                this.state = true;
                this.value = 1;
            }
        }

        //check all 8 neighbours around a cell and decide if they are alive or dead.
        public void getAliveNeighbours(Board board, int row, int col)
        {
            int liveCellCount = 0;
            //loop through the 
            for (int i_offset = -1; i_offset <= 1; i_offset++)
            {
                for (int j_offset = -1; j_offset <= 1; j_offset++)
                {
                    //if not origin cell
                    if (!(i_offset == 0 && j_offset == 0))
                    {
                        //if cell to check is in bounds, i.e. not outside of width/height of board
                        if (isInBounds(row + i_offset, col + j_offset, board.height, board.width))
                        {
                            //if the value is true
                            if (board.game_board[row + i_offset, col + j_offset].state == true)
                            {
                                liveCellCount += 1;
                            }
                        }
                    }
                }
            }
            liveNeighbours = liveCellCount;
        }

        public bool isInBounds(int targetRow, int targetCol, int boardWidth, int boardHeight)
        {
            //if target cell is within height and width boundary return true.
            if (targetRow >= 0 && targetRow < boardHeight)
            {
                if (targetCol >= 0 && targetCol < boardWidth)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
