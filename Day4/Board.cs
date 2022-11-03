using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class Board
    {
        public int[,] BoardSpaces { get; set; } = new int[5, 5];
        public bool[,] BoardState { get; set; } = new bool[5, 5];
        public bool[] ColState { get; set; } = new bool[5];
        public bool[] RowState { get; set; } = new bool[5];
    }
}
