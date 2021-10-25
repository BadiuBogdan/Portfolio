using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintJocuri
{
    class LabirintData
    {
        public static Labirint Get()
        {
            Labirint returnLabirint = new Labirint();

            string allMatrix = File.ReadAllText(@"./../../Matrice.txt");
            var allLines = allMatrix.Split('\n');
            var dimensiune= allLines[0].Split(' ');

            returnLabirint.Rows = Convert.ToInt32(dimensiune[0]);
            returnLabirint.Cols= Convert.ToInt32(dimensiune[1]);

            for (var i = 0; i < returnLabirint.Rows;i++)
            {
                var valoriLinie = allLines[i + 1].Split(' ');
                for (var j = 0; j < returnLabirint.Cols; j++)
                {
                    returnLabirint.Matrix[i, j] = Convert.ToInt32(valoriLinie[j]);
                }
            }
            return returnLabirint;
        }
    }
}
