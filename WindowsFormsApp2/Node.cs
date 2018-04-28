using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Node
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Node(double x1, double y1, double z1)
        {
            X = x1;
            Y = y1;
            Z = z1;
        }
    }
}
