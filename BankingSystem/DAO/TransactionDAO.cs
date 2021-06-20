using BankingSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.DAO
{
    public class TransactionDAO
    {
        private static TransactionDAO instance;

        public TransactionDAO()
        {
        }

        public static TransactionDAO Instance {
            get
            {
                if (instance == null) instance = new TransactionDAO();
                return TransactionDAO.instance;
            }
            private set { TransactionDAO.instance = value; }
        }
         public bool CreateTran(Transaction tran)
        {
            string query = string.Format(@"INSERT INTO [Transaction] (cusName, cusNumber, cusTitle, transType, date, amount, fromAcc, toAcc) VALUES ('"+ tran.CusName+"',"+"'"+tran.CusNum+"',"+"'"+ tran.CusTitle+"',"+"'"+ 
                tran.TranType1+"',"+"'"+ tran.Date+"',"+"'"+ tran.Amount+"',"+"'"+ tran.FromAcc1+"',"+"'"+ tran.ToAcc1+"')");
            return DAO.DataProvider.Instance.ExecuteNonQuery(query);
        }
        public DataTable getAccount(string num)
        {
            string query = string.Format(@"SELECT * FROM [Transaction] WHERE cusNumber='" + num + "'");
            return DAO.DataProvider.Instance.ExcuteQuery(query);
        }
    }
}
