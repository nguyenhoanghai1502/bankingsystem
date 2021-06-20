using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.DTO
{
    public class Transaction
    {
        private static Transaction instance;

        public static Transaction Instance {
            get
            {
                if (instance == null) instance = new Transaction();
                return Transaction.instance;
            }
            private set { Transaction.instance = value; }
        }

        public string CusName { get => cusName; set => cusName = value; }
        public string CusNum { get => cusNum; set => cusNum = value; }
        public string CusTitle { get => cusTitle; set => cusTitle = value; }
        public string TranType1 { get => TranType; set => TranType = value; }
        public string Date { get => date; set => date = value; }
        public string Amount { get => amount; set => amount = value; }
        public string FromAcc1 { get => FromAcc; set => FromAcc = value; }
        public string ToAcc1 { get => ToAcc; set => ToAcc = value; }

        private string cusName;
        private string cusNum;
        private string cusTitle;
        private string TranType;
        private string date;
        private string amount;
        private string FromAcc;
        private string ToAcc;

        public Transaction()
        {
        }
        public Transaction(string cusNum, string cusName, string cusTitle, string tranType, string date, string amount, string from, string to)
        {
            this.cusNum = cusNum;
            this.cusName = cusName;
            this.cusTitle = cusTitle;
            this.TranType = tranType;
            this.date = date;
            this.amount = amount;
            this.FromAcc = from;
            this.ToAcc = to;
        }
    }
}
