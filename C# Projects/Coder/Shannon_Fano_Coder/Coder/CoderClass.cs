using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coder
{
    class CoderClass
    {
        public void Statistica(int[] bufferRead, int[] count, int[] hartaBiti)
        {

            for (var i = 0; i < bufferRead.Length; i++)
            {
                if (bufferRead[i] != 0)
                {
                    count[bufferRead[i]]++;
                }

            }
            for (var i = 0; i < 256; i++)
            {
                if (count[i] != 0)
                {
                    hartaBiti[i] = 1;
                }
                else
                {
                    hartaBiti[i] = 0;
                }
            }
        }

        public void Statistica(byte[] bufferRead, int[] count, int[] hartaBiti)
        {

            for (var i = 0; i < bufferRead.Length; i++)
            {
                if (bufferRead[i] != 0)
                {
                    count[bufferRead[i]]++;
                }

            }
            for (var i = 0; i < 256; i++)
            {
                if (count[i] != 0)
                {
                    hartaBiti[i] = 1;
                }
                else
                {
                    hartaBiti[i] = 0;
                }
            }
        }
        public void ShannonFano(List<Node> symbol, int beg, int end)
        {
            if (beg == end)
                return;
            int y = beg;
            int z = end;
            int sum_left = 0;
            int sum_right = 0;
            while (y <= z)
            {
                if (sum_left <= sum_right)
                {
                    sum_left += symbol[y].frequency;
                    y++;
                }
                else
                {
                    sum_right += symbol[z].frequency;
                    z--;

                }
            }
            for (int h = beg; h < y; h++)
            {
                symbol[h].code = symbol[h].code << 1;
                symbol[h].code |= 0;
                symbol[h].nrBits++;
            }
            for (int h = y; h <= end; h++)
            {
                symbol[h].code = symbol[h].code << 1;
                symbol[h].code |= 1;
                symbol[h].nrBits++;
            }
            ShannonFano(symbol, beg, y - 1);
            ShannonFano(symbol, y, end);
        }



        public uint MaxNrBiti(List<Node> list)
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Lista este goala");
            }
            uint maxAge = uint.MinValue;
            foreach (Node type in list)
            {
                if (type.nrBits > maxAge)
                {
                    maxAge = type.nrBits;
                }
            }
            return maxAge;
        }
    }
}
