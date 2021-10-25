using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieClusterring.Class
{
    class CombinatiaMaxima
    {
        private int[,] correspondenceMatrix;
        private List<Element> combinatiaMaxim;
        private List<Element> combinatiaCurenta;
        private int valMaxim;
        private int nrLine;
        private int nrCol;
        public CombinatiaMaxima(ref int[,] correspondenceMatrix)
        {
            this.correspondenceMatrix = correspondenceMatrix;
            combinatiaCurenta = new List<Element>();
            combinatiaMaxim = new List<Element>();
            nrLine = this.correspondenceMatrix.GetLength(0);
            nrCol = this.correspondenceMatrix.GetLength(1);
            valMaxim = -1;
        }

        private void BackTracking(byte nivel)
        {

            if ((nivel == nrLine) || (combinatiaCurenta.Count() == nrCol))
            {
                int tempMaxim = 0;
                foreach (var elem in combinatiaCurenta)
                {
                    tempMaxim += elem.mValoare;
                }
                if (tempMaxim > valMaxim)
                {
                    valMaxim = tempMaxim;
                    combinatiaMaxim.Clear();
                    foreach (var elem in combinatiaCurenta)
                        combinatiaMaxim.Add(elem);
                }
                return;
            }
            List<byte> intermediar = new List<byte>();
            bool salt;
            for (byte i = 0; i < nrCol; i++)
            {
                salt = false;
                foreach (var elem in combinatiaCurenta)
                {
                    if (elem.mIndexColoana == i)
                    {
                        salt = true;
                        break;
                    }
                }
                if (!salt)
                {
                    if (correspondenceMatrix[nivel, i] != 0)
                        intermediar.Add(i);
                }
            }
            Element e;
            foreach (var elem in intermediar)
            {
                e = new Element(nivel, elem, (Int16)correspondenceMatrix[nivel, elem]);
                combinatiaCurenta.Add(e);
                if (nivel < nrLine) BackTracking((byte)(nivel + 1));
                combinatiaCurenta.Remove(e);
            }
            return;
        }

        public List<Element> GetCombinatieMaxima()
        {
            BackTracking(0);
            Console.WriteLine("Maxim: " + valMaxim);
            foreach (var elem in combinatiaMaxim)
            {
                Console.WriteLine(elem.mIndexLinie.ToString() + " " + elem.mIndexColoana.ToString() + " " + elem.mValoare.ToString());
            }
            return combinatiaMaxim;
        }
    }
}
