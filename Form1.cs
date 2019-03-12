using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_2
{
    public partial class Form1 : Form
    {
        Control calc = new Control();
        private bool lastWasOperation = false;
        public Form1()
        {
            InitializeComponent();
            CenterToScreen();

            calc.PrintToTxt += Calc_PrintToTxt;
            calc.ToUpTxt += Calc_ToUpTxt;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyData)
            {
                case Keys.D1:
                case Keys.NumPad1:
                    number_Click(button1, null);
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    number_Click(button2, null);
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    number_Click(button3, null);
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    number_Click(button4, null);
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    number_Click(button5, null);
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    number_Click(button6, null);
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    number_Click(button12, null);
                    break;
                case Keys.D8:
                case Keys.NumPad8:
                    number_Click(button11, null);
                    break;
                case Keys.D9:
                case Keys.NumPad9:
                    number_Click(button10, null);
                    break;
                case Keys.D0:
                case Keys.NumPad0:
                    number_Click(button8, null);
                    break;
                case Keys.Decimal:
                case Keys.Separator:
                    Comma_Click(button7, null);
                    break;
                case Keys.Add:
                case Keys.Shift | Keys.Oemplus:
                    operation_Click(button16, null);
                    break;
                case Keys.Subtract:
                case Keys.Shift | Keys.OemMinus:
                    operation_Click(button15, null);
                    break;
                case Keys.Multiply:
                case Keys.Shift | Keys.D8:
                    operation_Click(button14, null);
                    break;
                case Keys.Divide:
                    operation_Click(button13, null);
                    break;
                case Keys.Escape:
                    Clear_Click(button9, null);
                    break;
                case Keys.Back:
                    Back_Click(null, null);         //backspace
                    break;
            }
        }
        private void Calc_ToUpTxt(object sender, MyEventArgs e)
        {
            if (!lastWasOperation)
                uptxt.Text += e.Message;
        }

        private void number_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;

            if (calc.hasOperation)
                textBox1.Text += bt.Text;
            else
                textBox1.Text = bt.Text;

            calc.hasOperation = true;
            lastWasOperation = false;
        }

        private void Calc_PrintToTxt(object sender, MyEventArgs e)
        {
            textBox1.Text = e.Message;
        }

        private void operation_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;

            if (!lastWasOperation)
            {
                try
                {
                    calc.SetNumber(double.Parse(textBox1.Text));
                    calc.SetOperation(bt.Text);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                calc.SetOperation(bt.Text);
                if (bt.Text == "/" || bt.Text == "*")
                    calc.SetNumber(1);
                else
                    calc.SetNumber(0);

                uptxt.Text = uptxt.Text.Remove(uptxt.Text.Length - 2) + bt.Text + ' ';
            }
            calc.hasOperation = false;
            lastWasOperation = true;
        }

        private void equalB_Click(object sender, EventArgs e)
        {
            try
            {
                if (!calc.lastWasEqual)
                    calc.SetNumber(double.Parse(textBox1.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            calc.Equal();
            uptxt.Text = "";
            calc.hasOperation = false;
            lastWasOperation = false;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            calc.Clear();
            uptxt.Text = "";
            textBox1.Text = "0";
            calc.hasOperation = false;
            lastWasOperation = false;
        }

        private void Comma_Click(object sender, EventArgs e)
        {
            textBox1.Text += ',';
        }
        private void Back_Click(object sender, EventArgs e)
        {
            //backspace function
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            if (textBox1.Text == "")
                textBox1.Text = "0";
        }
    }
}
