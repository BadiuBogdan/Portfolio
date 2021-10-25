using System;


namespace LZW
{
    class BitWriter
    {
        
        private int BufferWrite = 0;
        public Byte ByteWrite;
        private int NumberOfBitsWrite = 0;
        private string filePath;
        private long length;

        public long Length { get => length; set => length = value; }

        public BitWriter(string filePath)
        {
            this.filePath = filePath;
            BufferWrite = 0;
            NumberOfBitsWrite = 0;
        }

        private void WriteBit(int valBit)
        {
            valBit = valBit << 7;

            BufferWrite = BufferWrite >> 1; //salveaza bitul in buffer, la mine buff este un int care o sa fie convertit in byte inainte de scriere
            BufferWrite = BufferWrite | valBit; //  pentru a ma asigura ca este 1 byte scris

            NumberOfBitsWrite++;

            if (NumberOfBitsWrite == 8)
            {
                NumberOfBitsWrite = 0;
                ByteWrite = Convert.ToByte(BufferWrite); //Convertesc in byte sa fiu 100% sigur ca o sa am 1 Byte cand scriu

                using (System.IO.FileStream
                     fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate))
                {
                    length = fileStream.Length;
                    long endPoint = fileStream.Length; //luam lungimea pentru a putea plasa nextElem la sfarsitul fisierului
                    fileStream.Seek(endPoint, System.IO.SeekOrigin.Begin);//plaseaza nextElem la sfarsitul fisierului
                    fileStream.WriteByte(ByteWrite);
                    fileStream.Close();
                }

                ByteWrite = 0;
                BufferWrite = 0;
            }

        }

        public void WriteNBits(uint nrBiti, int val)
        {
            int auxBit;
            for (var i = 0; i < nrBiti; i++)
            {
                auxBit = (int)(val % 2);
                val = val / 2;
                WriteBit(auxBit);

            }
        }

    }
}
