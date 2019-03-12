using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_2
{
    class MyEventArgs : EventArgs
    {
        public string Message { get; private set; }
        public int num { get; private set; }

        public MyEventArgs(string message)
        {
            this.num = num;
            this.Message = message;
        }
    }
}
