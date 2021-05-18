using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    class Account
    {
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string accountid { get; set; }
        public string gender { get; set; }
        public DateTime DOB { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string NIC { get; set; }
        public string email { get; set; }
        public string company { get; set; }
        public string occupation { get; set; }
        public string initialdeposit { get; set; }

        public Account() { }
        public Account(string username, string password, string name, string accountid, string gender, DateTime DOB
            , string address, string phone, string NIC, string email, string company, string occupation, string initialdeposit)
        {
            this.username = username;
            this.password = password;
            this.name = name;
            this.accountid = accountid;
            this.gender = gender;
            this.DOB = DOB;
            this.address = address;
            this.phone = phone;
            this.NIC = NIC;
            this.email = email;
            this.company = company;
            this.occupation = occupation;
            this.initialdeposit = initialdeposit;
        }

            
    }
}
