using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingSystem
{
    public partial class calculator : Form
    {
        Double resultValue = 0;
        string operatorChoosed = "";
        bool isOperatorbtn = false;
        public calculator()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if ((txtResults.Text == "0")||(isOperatorbtn==true))
                txtResults.Clear();
            isOperatorbtn = false;
            Button btn = (Button)sender;
            if (btn.Text == ".")
            {
                if (!txtResults.Text.Contains("."))
                    txtResults.Text += btn.Text;
            }else
            txtResults.Text += btn.Text;
        }

        private void btnoperator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (resultValue != 0)
            {
                btnequal.PerformClick();
                operatorChoosed = btn.Text;
                lbequations.Text = resultValue + operatorChoosed;
                isOperatorbtn = true;
            }
            else
            {
                operatorChoosed = btn.Text;
                resultValue = Double.Parse(txtResults.Text);
                lbequations.Text = resultValue + operatorChoosed;
                isOperatorbtn = true;
            }
        }

        private void btnclearall_Click(object sender, EventArgs e)
        {
            txtResults.Text = "0";
            resultValue = 0;
            lbequations.Text = "";
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtResults.Text = "0";
        }

        private void btnequal_Click(object sender, EventArgs e)
        {
            switch (operatorChoosed)
            {
                case "+":
                    {
                        txtResults.Text = (resultValue + Double.Parse(txtResults.Text)).ToString();
                        break;
                    }
                case "-":
                    {
                        txtResults.Text = (resultValue - Double.Parse(txtResults.Text)).ToString();
                        break;
                    }
                case "X":
                    {
                        txtResults.Text = (resultValue * Double.Parse(txtResults.Text)).ToString();
                        break;
                    }
                case "/":
                    {
                        txtResults.Text = (resultValue * Double.Parse(txtResults.Text)).ToString();
                        break;
                    }
                default:
                    break;
            }
            resultValue = Double.Parse(txtResults.Text);
            lbequations.Text = "";
        }
    }
}
