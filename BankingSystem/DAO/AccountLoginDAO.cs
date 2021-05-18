using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.DAO
{
    public class AccountLoginDAO
    {
        private static AccountLoginDAO instance;

        public static AccountLoginDAO Instance {

            get
            {
                if (instance == null)
                    instance = new AccountLoginDAO();
                return AccountLoginDAO.instance;
            }
            private set { AccountLoginDAO.instance = value; } 
        }
        private AccountLoginDAO() { }
        public bool adminLogin(string username, string password)
        {
            string query = "SELECT * FROM dbo.adminAccount WHERE username=N'"+username+"' AND password=N'"+password+"'";
            DataTable result = DataProvider.Instance.ExcuteQuery(query);
            return result.Rows.Count>0;
        }
        public bool customerLogin(string username, string password)
        {
            string query = "Select * FROM dbo.CustomerAccount WHERE id=N'" + username + "' AND password=N'" + password + "'";
            DataTable result = DataProvider.Instance.ExcuteQuery(query);
            return result.Rows.Count > 0;
        }
    }
}
