using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coder
{
    public class Node
    {
        public byte symbol { get; set; }
        public int frequency { get; set; }
        public int code { get; set; }
        public uint nrBits { get; set; }

        public Node(byte symbol, int Frequency)
        {
            this.symbol = symbol;
            this.frequency = Frequency;
            code =0;
            nrBits = 0;
        }


    }
}
