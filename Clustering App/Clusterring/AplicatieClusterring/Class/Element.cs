using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieClusterring.Class
{
    class Element
    {
        public byte mIndexLinie;
        public byte mIndexColoana;
        public Int16 mValoare;
        public Element(byte aLinie, byte aColoana, Int16 aValoare)
        {
            mIndexLinie = aLinie;
            mIndexColoana = aColoana;
            mValoare = aValoare;
        }
    }
}
