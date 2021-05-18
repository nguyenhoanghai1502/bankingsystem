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
    public partial class frmAddAccount : Form
    {
        public object SizeToContent { get; private set; }

        public frmAddAccount()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
                   }


        private void frmAddAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbHours.Text = DateTime.Now.ToString("HH:mm");
            lbSecond.Text = DateTime.Now.ToString("ss");
            lbDate.Text = DateTime.Now.ToString("MM dd yyyy").ToUpper();
            lbDay.Text = DateTime.Now.ToString("dddd").ToUpper();
        }

        private void frmAddAccount_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void frmAddAccount_SizeChanged(object sender, EventArgs e)
        {
            int width = (tabCreateAcc.Width - 19) / 5;
            tabCreateAcc.ItemSize = new Size(width, 50);
        }
    }
}
