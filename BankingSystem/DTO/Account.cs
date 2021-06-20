using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.DTO
{
    
    
    public class Account

    {
        private static Account instance;
        private string cusName;
        private string accNum;
        private string accTitle;
        private string accType;
        private string DOB;
        private string address;
        private string phoneNum;
        private string gender;
        private string email;
        private string company;
        private string occupation;
        private string initialDe;
        private byte[] pic;

        public Account()
        {
        }
        public Account(string cusname, string accnum, string acctitle, string acctype, string dob, string address, string phonenum, string gender,
            string email, string company, string occupation, string initialde, byte[] pic)
        {
            this.cusName = cusname;
            this.accNum = accnum;
            this.accTitle = acctitle;
            this.accType = acctype;
            this.DOB = dob;
            this.address = address;
            this.phoneNum = phonenum;
            this.gender = gender;
            this.email = email;
            this.company = company;
            this.occupation = occupation;
            this.initialDe = initialde;
            this.pic = pic;
        }

        public static Account Instance {
            get
            {
                if (instance == null) instance = new Account();
                return Account.instance;
            }
            private set { Account.instance = value; }
        }
        public string CusName { get => cusName; set => cusName = value; }
        public string AccNum { get => accNum; set => accNum = value; }
        public string AccTitle { get => accTitle; set => accTitle = value; }
        public string AccType { get => accType; set => accType = value; }
        public string DOB1 { get => DOB; set => DOB = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNum { get => phoneNum; set => phoneNum = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Email { get => email; set => email = value; }
        public string Company { get => company; set => company = value; }
        public string Occupation { get => occupation; set => occupation = value; }
        public string InitialDe { get => initialDe; set => initialDe = value; }
        public byte[] Pic { get => pic; set => pic = value; }

        public Account SearchAccount(string name="", string number="", string title = "")
        {
            DataTable dt = new DataTable();
            if (name == "")
            {
                if (number == "")
                {
                    dt=DAO.AccountDAO.Instance.SearchAccountWithAccTitle(title);
                }
                else
                {
                    dt=DAO.AccountDAO.Instance.SearchAccountWithAccNum(number);
                }
            }
            else
            {
                dt = DAO.AccountDAO.Instance.SearchAccountWithAccName(name);
            }
            if (dt.Rows.Count > 0)
            {
                Account acc = new Account();
                acc.CusName = dt.Rows[0]["name"].ToString();
                acc.AccNum = dt.Rows[0]["id"].ToString();
                acc.AccTitle = dt.Rows[0]["acctype"].ToString();
                acc.AccType = dt.Rows[0]["acctitle"].ToString();
                acc.DOB1 = dt.Rows[0]["dob"].ToString();
                acc.Address = dt.Rows[0]["address"].ToString();
                acc.PhoneNum = dt.Rows[0]["phone"].ToString();
                acc.Gender = dt.Rows[0]["gender"].ToString();
                acc.Email = dt.Rows[0]["email"].ToString();
                acc.Company = dt.Rows[0]["company"].ToString();
                acc.Occupation = dt.Rows[0]["occupation"].ToString();
                acc.InitialDe = dt.Rows[0]["initialdeposit"].ToString();
                if (dt.Rows[0]["pic"] != null)
                {
                    DataRow row = dt.Rows[0];
                    acc.Pic = (byte[])row["pic"];
                }
                return acc;
            }
            else
                return null;
        }
    }
}
