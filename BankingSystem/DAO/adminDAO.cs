using BankingSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.DAO
{
    public class adminDAO
    {
        private static adminDAO instance;

        public static adminDAO Instance {
            get
            {
                if (instance == null) instance = new adminDAO();
                return adminDAO.instance;
            }
            private set { adminDAO.instance = value; }
        }

        public DataTable getlist()
        {
            string query = "Select * from dbo.adminAccount";
            return DAO.DataProvider.Instance.ExcuteQuery(query);
        }
        public bool addData(admin ad)
        {
            string query = "INSERT INTO dbo.adminAccount VALUES ('" + ad.Username + "', '" + ad.Password + "')";
            return DAO.DataProvider.Instance.ExecuteNonQuery(query);
        }
        public bool updateData(admin ad)
        {
            string query = "UPDATE dbo.adminAccount SET username='"+ad.Username+"', password='"+ad.Password+"' WHERE username='"+ad.Username+"'";
            return DAO.DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
