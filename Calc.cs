using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_2
{
    class Calc
    {
        protected double num1 { get; set;}
        protected double num2 { get; set; }
        protected string lastOperation { get; set; }

        public bool lastWasEqual = false;

        public bool hasOperation = false;

    }
}
