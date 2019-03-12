using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_2
{
    class Control : Calc
    {
        public event EventHandler<MyEventArgs> ToUpTxt = null;
        public event EventHandler<MyEventArgs> PrintToTxt = null;
        public void SetNumber(double num)
        {
                if (lastOperation == null)
                {
                    num1 = num;
                }
                else
                {
                    num2 = num;
                }

        }

        public void SetOperation(string op)
        {
            if (lastOperation != null && lastWasEqual == false)
            {
                if (ToUpTxt != null)        //event to up label
                    ToUpTxt(this, new MyEventArgs(string.Format("{0} {1} ", num2, op)));

                switch (lastOperation)
                {
                    case "+":
                        num1 = num1 + num2;
                        break;
                    case "-":
                        num1 = num1 - num2;
                        break;
                    case "*":
                        num1 = num1 * num2;
                        break;
                    case "/":
                        num1 = num1 / num2;
                        break;
                }
            }
            else
            {
                if (ToUpTxt != null)        //event to up label
                    ToUpTxt(this, new MyEventArgs(string.Format("{0} {1} ", num1, op)));
            }
            if (PrintToTxt != null)     //event to main txtbox
                PrintToTxt(this, new MyEventArgs(num1.ToString()));

            if (op == "/" || op == "*")
                num2 = 1;
            else
                num2 = 0;

            lastOperation = op;
            lastWasEqual = false;
        }

        public void Equal()
        {
            lastWasEqual = true;
            switch (lastOperation)
            {
                case "+":
                    num1 = num1 + num2;
                    break;
                case "-":
                    num1 = num1 - num2;
                    break;
                case "*":
                    num1 = num1 * num2;
                    break;
                case "/":
                    num1 = num1 / num2;
                    break;
            }

            if (PrintToTxt != null)     //event to main txtbox
                PrintToTxt(this, new MyEventArgs(num1.ToString()));

            //lastOperation = null;
        }

        public void Clear()
        {
            lastOperation = null;
            lastWasEqual = false;
            num1 = num2 = 0;

        }
    }
}
