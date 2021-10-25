using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coder_LZ77
{
    class Token
    {
        private int poz;
        private int len;
        private byte sym;

        public Token(int poz, int len, byte sym)
        {
            this.poz = poz;
            this.len = len;
            this.sym = sym;
        }

        public int Poz { get => poz; set => poz = value; }
        public int Len { get => len; set => len = value; }
        public byte Sym { get => sym; set => sym = value; }
    }
}
