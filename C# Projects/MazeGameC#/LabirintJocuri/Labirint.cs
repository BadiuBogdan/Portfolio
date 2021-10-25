using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintJocuri
{
    class Labirint
    {
        int rows;
        int cols;
        int[,] matrix = new int[12, 12];

        public int Rows { get => rows; set => rows = value; }
        public int Cols { get => cols; set => cols = value; }
        public int[,] Matrix { get => matrix; set => matrix = value; }
    }
}
