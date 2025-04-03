using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{
    class epitoanyag
    {
        public double suly { get; set; }
        public string nev { get; set; }
        public int ar { get; set; }
    }

    class Tegla : epitoanyag
    {
        public string teglatipus { get; set; }
        public string szin { get; set; }
    }

    class Fa : epitoanyag
    {
        public string faanyag { get; set; }
        public double kemenyseg { get; set; }
    }

    class Vas : epitoanyag
    {
        public string femtipus { get; set; }
        public double suruseg { get; set; }
    }
}
