using BankingSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null) instance = new AccountDAO();
                return AccountDAO.instance;
            }
            private set { AccountDAO.instance = value; }
        }
        private AccountDAO() { }

        public bool CreateAccount(string name, string number, string title, string type, string dob, string address, string phone,
            string gender, string email, string company, string occupation, string deposit, byte[] pic)
        {
            string query = string.Format(@"INSERT dbo.CustomerAccount (name, id, gender, address, phone, email," +
                "company, occupation, initialdeposit, acctitle, acctype, dob, pic) VALUES ( N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}',N'{9}', N'{10}', N'{11}', @Pic)", name, number, gender, address, phone, email,
                company, occupation, deposit, title, type, dob);
            return DAO.DataProvider.Instance.ExecuteNonQuery(query, pic);
        }

        public DataTable SearchAccount(string AccName , string AccNum , string AccTitle )
        {
            string query = string.Format(@"SELECT * FROM dbo.CustomerAccount WHERE (name='" + AccName + "' OR id='" + AccNum + "' OR acctitle='" + AccTitle + "')");
            return DAO.DataProvider.Instance.ExcuteQuery(query);
        }
        public bool UpDateAccount(string name, string title, string number, string type, string address, string phone, string email,
            string company, string occupation, byte[] pic)
        {
            string query = string.Format(@"UPDATE dbo.CustomerAccount SET name=N'{0}', acctitle=N'{1}', acctype=N'{2}', address=N'{3}', phone=N'{4}', email=N'{5}',company=N'{6}', occupation=N'{7}', pic=@Pic WHERE id='" + number + "'", name, title, type, address,
            phone, email, company, occupation);
            return DAO.DataProvider.Instance.ExecuteNonQuery(query, pic);
        }
        public DataTable SearchAccountWithAccNum( string AccNum )
        {
            string query = string.Format(@"SELECT * FROM dbo.CustomerAccount WHERE  id='" + AccNum + "'");
            return DAO.DataProvider.Instance.ExcuteQuery(query);
        }

        public DataTable CusList()
        {
            string query = string.Format("SELECT * FROM dbo.CustomerAccount");
            return DAO.DataProvider.Instance.ExcuteQuery(query);
        }

        public bool Deposit(string amount, string num)
        {
            string query = string.Format(@"UPDATE dbo.CustomerAccount SET initialdeposit='" + amount + "' WHERE id='" + num + "'");
            return DAO.DataProvider.Instance.ExecuteNonQuery(query);
        }

        public bool Withdraw(string amount, string num)
        {
            string query = string.Format(@"UPDATE dbo.CustomerAccount SET initialdeposit='" + amount + "' WHERE id='" + num + "'");
            return DAO.DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
