using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.DTO
{
    public class Account
    {
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

        public Account()
        {
        }
        public Account(string cusname, string accnum, string acctitle, string acctype, string dob, string address, string phonenum, string gender,
            string email, string company, string occupation, string initialde)
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
        public string Company1 { get => company; set => company = value; }
        public string InitialDe { get => initialDe; set => initialDe = value; }
    }
}
