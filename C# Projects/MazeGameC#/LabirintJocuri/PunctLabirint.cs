using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintJocuri
{
    class PunctLabirint
    {
        private Point point;
        private int value;

        public PunctLabirint(Point point, int value)
        {
            this.point = point;
            this.value = value;
        }

        public Point Point { get => point; set => point = value; }
        public int Value { get => value; set => this.value = value; }
    }
}
