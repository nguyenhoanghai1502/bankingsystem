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
    public partial class CurrencyConverter : Form
    {
        public CurrencyConverter()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            txtResult.Text = DTO.Currency.Instance.CurrencyConvert(cbbTypeCurrency.Text, Double.Parse(txtCurrencyAmount.Text));
        }

        private void btnCurrencyClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
