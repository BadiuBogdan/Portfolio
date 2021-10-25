using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieClusterring.Class
{
    public class ConfusionMatrixData
    {
        private int tP;
        private int tN;
        private int fP;
        private int fN;

        public ConfusionMatrixData(int tP, int tN, int fP, int fN)
        {
            this.tP = tP;
            this.tN = tN;
            this.fP = fP;
            this.fN = fN;
        }

        public int TP { get => tP; set => tP = value; }
        public int TN { get => tN; set => tN = value; }
        public int FP { get => fP; set => fP = value; }
        public int FN { get => fN; set => fN = value; }
    }
}
