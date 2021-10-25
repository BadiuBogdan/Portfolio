using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LZW
{
    class BitReader
    {
        private readonly BinaryReader inputFile;
        

        private int BufferReader;
        private int auxBufferReader;
        private int NumberOfReadBits;
        private long length;

        public long Length { get => length; set => length = value; }

        public BitReader(string filePath)
        {
            BufferReader = 0;
            NumberOfReadBits = 0;
            auxBufferReader = 0;
            inputFile = new BinaryReader(File.Open(filePath, FileMode.Open), Encoding.UTF8);
            length = inputFile.BaseStream.Length;
        }

        private int ReadBit()
        {
            if (NumberOfReadBits == 0)
            {
                
                BufferReader = inputFile.ReadByte();
                NumberOfReadBits = 8;
            }
            int rezultat = 0;
            auxBufferReader = BufferReader;
            BufferReader = BufferReader >> 1;
            auxBufferReader = auxBufferReader & 1;

            rezultat = auxBufferReader;
            NumberOfReadBits--;
            return rezultat;
        }
        public int ReadNBit(uint nr)
        {

            int bit = 0;
            int rezultat = 0;
            for (var i = 0; i < nr; i++)
            {
                bit = ReadBit();
                bit = bit << i;
                rezultat = rezultat | bit;
            }
            return rezultat;
        }
    }
}
