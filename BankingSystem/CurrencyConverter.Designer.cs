
namespace BankingSystem
{
    partial class CurrencyConverter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlCurrency = new System.Windows.Forms.Panel();
            this.label84 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.btnCurrencyClose = new MetroFramework.Controls.MetroButton();
            this.btnConvert = new MetroFramework.Controls.MetroButton();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.cbbTypeCurrency = new System.Windows.Forms.ComboBox();
            this.txtCurrencyAmount = new System.Windows.Forms.TextBox();
            this.pnlCurrency.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCurrency
            // 
            this.pnlCurrency.Controls.Add(this.label84);
            this.pnlCurrency.Controls.Add(this.label83);
            this.pnlCurrency.Controls.Add(this.label82);
            this.pnlCurrency.Controls.Add(this.btnCurrencyClose);
            this.pnlCurrency.Controls.Add(this.btnConvert);
            this.pnlCurrency.Controls.Add(this.txtResult);
            this.pnlCurrency.Controls.Add(this.cbbTypeCurrency);
            this.pnlCurrency.Controls.Add(this.txtCurrencyAmount);
            this.pnlCurrency.Location = new System.Drawing.Point(26, 12);
            this.pnlCurrency.Name = "pnlCurrency";
            this.pnlCurrency.Size = new System.Drawing.Size(239, 219);
            this.pnlCurrency.TabIndex = 3;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label84.Location = new System.Drawing.Point(14, 100);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(51, 16);
            this.label84.TabIndex = 4;
            this.label84.Text = "Result:";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.Location = new System.Drawing.Point(14, 55);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(42, 16);
            this.label83.TabIndex = 4;
            this.label83.Text = "Type:";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label82.Location = new System.Drawing.Point(14, 12);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(61, 16);
            this.label82.TabIndex = 4;
            this.label82.Text = "Amount:";
            // 
            // btnCurrencyClose
            // 
            this.btnCurrencyClose.Location = new System.Drawing.Point(17, 136);
            this.btnCurrencyClose.Name = "btnCurrencyClose";
            this.btnCurrencyClose.Size = new System.Drawing.Size(75, 37);
            this.btnCurrencyClose.TabIndex = 3;
            this.btnCurrencyClose.Text = "Close";
            this.btnCurrencyClose.UseSelectable = true;
            this.btnCurrencyClose.Click += new System.EventHandler(this.btnCurrencyClose_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(144, 136);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 37);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "Covert";
            this.btnConvert.UseSelectable = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(78, 97);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(142, 20);
            this.txtResult.TabIndex = 2;
            this.txtResult.Text = "0";
            // 
            // cbbTypeCurrency
            // 
            this.cbbTypeCurrency.FormattingEnabled = true;
            this.cbbTypeCurrency.Items.AddRange(new object[] {
            "USA",
            "Japanese",
            "Chinese",
            "Korean",
            "Thailand",
            "Russian"});
            this.cbbTypeCurrency.Location = new System.Drawing.Point(78, 52);
            this.cbbTypeCurrency.Name = "cbbTypeCurrency";
            this.cbbTypeCurrency.Size = new System.Drawing.Size(142, 21);
            this.cbbTypeCurrency.TabIndex = 1;
            // 
            // txtCurrencyAmount
            // 
            this.txtCurrencyAmount.Location = new System.Drawing.Point(78, 9);
            this.txtCurrencyAmount.Name = "txtCurrencyAmount";
            this.txtCurrencyAmount.Size = new System.Drawing.Size(142, 20);
            this.txtCurrencyAmount.TabIndex = 0;
            this.txtCurrencyAmount.Text = "0";
            // 
            // CurrencyConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(294, 243);
            this.Controls.Add(this.pnlCurrency);
            this.MaximizeBox = false;
            this.Name = "CurrencyConverter";
            this.Text = "CurrencyConverter";
            this.pnlCurrency.ResumeLayout(false);
            this.pnlCurrency.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCurrency;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label82;
        private MetroFramework.Controls.MetroButton btnCurrencyClose;
        private MetroFramework.Controls.MetroButton btnConvert;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.ComboBox cbbTypeCurrency;
        private System.Windows.Forms.TextBox txtCurrencyAmount;
    }
}