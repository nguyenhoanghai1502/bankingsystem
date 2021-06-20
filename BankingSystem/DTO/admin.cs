using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.DTO
{
    public class admin
    {
        private static admin instance;

        public static admin Instance {
            get
            {
                if (instance == null) instance = new admin();
                return admin.instance;
            }
            private set { admin.instance = value; }
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        private string username;
        private string password;

        public DataTable getData()
        {
            return DAO.adminDAO.Instance.getlist();
        }
        public bool addData(admin ad)
        {
            return DAO.adminDAO.Instance.addData(ad);
        }
        public bool updateData(admin ad)
        {
            return DAO.adminDAO.Instance.updateData(ad);
        }
    }
}
