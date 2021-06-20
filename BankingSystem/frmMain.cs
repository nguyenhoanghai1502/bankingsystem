using BankingSystem.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingSystem
{
    public partial class frmAddAccount : Form
    {

        #region Events
        public frmAddAccount()
        {
            InitializeComponent();
        }
        private void frmAddAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbHours.Text = DateTime.Now.ToString("HH:mm");
            lbSecond.Text = DateTime.Now.ToString("ss");
            lbDate.Text = DateTime.Now.ToString("MM dd yyyy").ToUpper();
            lbDay.Text = DateTime.Now.ToString("dddd").ToUpper();
        }

        private void frmAddAccount_Load(object sender, EventArgs e)
        {
            timer1.Start();
            getAccounts();
        }

        private void frmAddAccount_SizeChanged(object sender, EventArgs e)
        {
            if (tabCreateAcc.Width>0)
            {
                int width = (tabCreateAcc.Width - 19) / 5;
                tabCreateAcc.ItemSize = new Size(width, 50);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = this.txtCusNameCre.Text;
            string number = this.txtAccNumCre.Text;
            string title = this.txtCreAccTitle.Text;
            string type = this.cbCreAccType.Text;
            string dob = this.dtCreDate.Value.ToString();
            string address = this.txtCreAdd.Text;
            string phone = this.txtCrePhone.Text;
            string gender = "";
            if (rabtnMale.Checked == true)
            {
                gender = "Male";
            }
            else if (rabtnFemale.Checked == true)
            {
                gender = "Female";
            }
            else if (rabtnOther.Checked == true)
            {
                gender = "Other";
            }
            string email = this.txtCreEmail.Text;
            string company = this.txtCreCom.Text;
            string occupation = this.txtCreOccu.Text;
            string initialde = this.txtCreDeposit.Text;
            MemoryStream stream = new MemoryStream();
            profileptr.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] pic = stream.ToArray();
            Account acc = new Account(name, number, title, type, dob, address, phone, gender, email, company, occupation, initialde, pic);
            if (DAO.AccountDAO.Instance.CreateAccount(acc))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
                getAccounts();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại!");
            }
        }

        private void txtCrePhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') || txtCrePhone.Text.Length > 10)
            {
                e.Handled = true;
            }

        }

        private void txtCreDeposit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtAccNumCre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtCusNameCre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar == ' ') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || e.KeyChar == (char)8))
                e.Handled = true;
        }

        private void lbClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetForm();
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Images(.jpg,.png)|*.png;*.jpg", ValidateNames = true, Multiselect = false })
            {

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    profileptr.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void btnADSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string name = txtADSearhName.Text;
            string num = txtADSearchNum.Text;
            string title = txtADTitle.Text;
            Account acc = DTO.Account.Instance.SearchAccount();
            if (acc != null)
            {
                txtADName.Text = acc.CusName;
                txtADNum.Text = acc.AccNum;
                txtADType.Text = acc.AccType;
                txtADAccTitle.Text = acc.AccTitle;
                txtADDOB.Text = acc.DOB1;
                txtADAdd.Text = acc.Address;
                txtADPhone.Text = acc.PhoneNum;
                txtADGender.Text = acc.Gender;
                txtADEmail.Text = acc.Email;
                txtADComName.Text = acc.Company;
                txtADOccu.Text = acc.Occupation;
                txtADBalance.Text = acc.InitialDe;
                ptrProfileAD.Image = ConvertByteArrayToImage(acc.Pic);
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại!");
            }
        }

        private void btnCBSearch_Click(object sender, EventArgs e)
        {
            string name = txtCBSName.Text;
            string num = txtCBSNum.Text;
            string title = txtCBSTitle.Text;
            Account acc = DTO.Account.Instance.SearchAccount(name, num, title);
            if (acc!=null)
            {
                txtCBName.Text = acc.CusName;
                txtCBTitle.Text = acc.AccTitle;
                txtCBBalance.Text = acc.InitialDe;
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại!");
            }
            txtCBSName.Clear();
            txtCBSNum.Clear();
            txtCBSTitle.Clear();
        }

        private void btnUASearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string num = txtUASearchNum.Text;
            if (IsNumber(txtUASearchNum.Text))
            {
                dt = DAO.AccountDAO.Instance.SearchAccountWithAccNum(num);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tài khoản không tồn tại!");
                    txtUASearchNum.Clear();
                }
                else
                {
                    txtUAName.Text = dt.Rows[0]["name"].ToString();
                    cbUAType.Text = dt.Rows[0]["acctype"].ToString();
                    txtUATitle.Text = dt.Rows[0]["acctitle"].ToString();
                    txtUAAdd.Text = dt.Rows[0]["address"].ToString();
                    txtUAPhone.Text = dt.Rows[0]["phone"].ToString();
                    txtUAEmail.Text = dt.Rows[0]["email"].ToString();
                    txtUACom.Text = dt.Rows[0]["company"].ToString();
                    txtUAOccu.Text = dt.Rows[0]["occupation"].ToString();
                    if (dt.Rows[0]["pic"].ToString().Length != 0)
                    {
                        DataRow row = dt.Rows[0];
                        profilePictr.Image = ConvertByteArrayToImage((byte[])row["pic"]);
                    }
                    else
                    {
                        profilePictr.Image = BankingSystem.Properties.Resources._127066563_1053964071708972_5273578564006566232_o;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại số tài khoản vừa nhập!");
                txtUASearchNum.Clear();
            }
        }

        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Images(.jpg,.png)|*.png;*.jpg", ValidateNames = true, Multiselect = false })
            {

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    profilePictr.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string number= txtUASearchNum.Text;
            string name = this.txtUAName.Text;
            string title = this.txtUATitle.Text;
            string type = this.cbUAType.Text;
            string address = this.txtUAAdd.Text;
            string phone = this.txtUAPhone.Text;
            string email = this.txtUAEmail.Text;
            string company = this.txtUACom.Text;
            string occupation = this.txtUAOccu.Text;
            MemoryStream stream = new MemoryStream();
            profilePictr.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] pic = stream.ToArray();
            if (DAO.AccountDAO.Instance.UpDateAccount(name,  title, number, type, address, phone, email, company, occupation, pic))
            {
                MessageBox.Show("Update thành công!");
                dtgrvCusList.DataSource = DAO.AccountDAO.Instance.CusList();
            }
            else
            {
                MessageBox.Show("Update thất bại!");
            }
            ResetForm();
        }
        private void btnSearchAcc_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string num = txtSAccNumber.Text;
            if (IsNumber(num))
            {
                dt = DAO.AccountDAO.Instance.SearchAccountWithAccNum(num);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tài khoản không tồn tại!");
                    txtSAccNumber.Clear();
                }
                else
                {
                    dtgrvSearchAcc.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại số tài khoản!");
                txtSAccNumber.Clear();
            }
        }

        private void tabSearch_Leave(object sender, EventArgs e)
        {
            txtSAccNumber.Clear();
            dtgrvSearchAcc.DataSource = DAO.AccountDAO.Instance.SearchAccountWithAccNum(null);
        }

        private void tabAccDetail_Leave(object sender, EventArgs e)
        {
            this.txtADSearhName.Clear();
            this.txtADSearchNum.Clear();
            this.txtADTitle.Clear();
            this.txtADName.Clear();
            this.txtADNum.Clear();
            this.txtADType.Clear();
            this.txtADAccTitle.Clear();
            this.txtADDOB.Clear();
            this.txtADAdd.Clear();
            this.txtADPhone.Clear();
            this.txtADGender.Clear();
            this.txtADEmail.Clear();
            this.txtADComName.Clear();
            this.txtADOccu.Clear();
            this.txtADBalance.Clear();
            this.ptrProfileAD.Image = BankingSystem.Properties.Resources._127066563_1053964071708972_5273578564006566232_o;
        }

        private void txtCBSName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar == ' ') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || e.KeyChar == (char)8))
                e.Handled = true;
        }

        private void txtADSearhName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar == ' ') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || e.KeyChar == (char)8))
                e.Handled = true;
        }

        private void txtSearchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar == ' ') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || e.KeyChar == (char)8))
                e.Handled = true;
        }

        private void txtDeSeCusName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar == ' ') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || e.KeyChar == (char)8))
                e.Handled = true;
        }

        private void txtCBSNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnDeSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string name = txtDeSeCusName.Text;
            string num = txtDeAccNum.Text;
            string title = txtDeSearchTitle.Text;
            Account acc = DTO.Account.Instance.SearchAccount(name, num, title);
            if (acc != null)
            {
                txtDeCusName.Text = acc.CusName;
                txtDeTitle.Text = acc.AccTitle;
                txtDeBalace.Text = acc.InitialDe;
                txtDEAccNumCon.Text = acc.AccNum;
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại!");
            }
            txtDeSeCusName.Clear();
            txtDeAccNum.Clear();
            txtDeSearchTitle.Clear();
        }

        private void btnConfirmDe_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(txtDeBalace.Text);
            int y = Int32.Parse(txtDeAmount.Text);
            x += y;
            if (DAO.AccountDAO.Instance.Deposit(x.ToString(), txtDEAccNumCon.Text))
            {
                MessageBox.Show("Update thành công!");
                txtDeBalace.Text = x.ToString();
                Transaction tran = new Transaction();
                tran.CusName = txtDeCusName.Text;
                tran.CusNum = txtDEAccNumCon.Text;
                tran.CusTitle = txtDeTitle.Text;
                tran.Date = DateTime.Now.ToString();
                tran.Amount = txtDeAmount.Text;
                tran.TranType1 = "Deposit";
                tran.ToAcc1 = "";
                tran.FromAcc1 = "";
                DAO.TransactionDAO.Instance.CreateTran(tran);
                txtDeAmount.Clear();
                dtgrvCusList.DataSource = DAO.AccountDAO.Instance.CusList();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnWithSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string name = txtSearchName.Text;
            string num = txtSearchNum.Text;
            string title = txtSearchTitle.Text;
            Account acc = DTO.Account.Instance.SearchAccount(name, num, title);
            if (acc != null)
            {
                txtWithName.Text = acc.CusName;
                txtWithTitle.Text = acc.AccTitle;
                txtWithBa.Text = acc.InitialDe;
                txtWithNum.Text = acc.AccNum;
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại!");
            }
            txtSearchName.Clear();
            txtSearchNum.Clear();
            txtSearchTitle.Clear();
        }

        private void btnWithConfirm_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(txtWithBa.Text);
            int y = Int32.Parse(txtWithAmount.Text);
            x -= y;
            if (DAO.AccountDAO.Instance.Withdraw(x.ToString(), txtWithNum.Text))
            {
                MessageBox.Show("Update thành công!");
                txtWithBa.Text = x.ToString();
                Transaction tran = new Transaction();
                tran.CusName = txtWithName.Text;
                tran.CusNum = txtWithNum.Text;
                tran.CusTitle = txtWithTitle.Text;
                tran.Date = DateTime.Now.ToString();
                tran.Amount = txtWithAmount.Text;
                tran.TranType1 = "Withdraw";
                tran.ToAcc1 = "";
                tran.FromAcc1 = "";
                DAO.TransactionDAO.Instance.CreateTran(tran);
                txtWithAmount.Clear();
                getAccounts();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnFromSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string name = txtFromName.Text;
            string num = txtFromNum.Text;
            string title = txtFromTitle.Text;
            Account acc = DTO.Account.Instance.SearchAccount(name, num, title);
            if (acc != null)
            {
                txtFromName.Text = acc.CusName;
                txtFromTitle.Text = acc.AccTitle;
                txtFromBalance.Text = acc.InitialDe;
                txtFromNum.Text = acc.AccNum;
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại!");
            }
        }

        private void btnToSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string name = txtToName.Text;
            string num = txtToNum.Text;
            string title = txtToTitle.Text;
            Account acc = DTO.Account.Instance.SearchAccount(name, num, title);
            if (acc != null)
            {
                txtToName.Text = acc.CusName;
                txtToTitle.Text = acc.AccTitle;
                txtToBalance.Text = acc.InitialDe;
                txtToNum.Text = acc.AccNum;
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại!");
            }
        }

        private void btnTransConfirm_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(txtFromBalance.Text);
            int y = Int32.Parse(txtTranAmount.Text);
            int z = Int32.Parse(txtToBalance.Text);
            if (x < y)
            {
                MessageBox.Show("Tài khoản của quý khách không đủ!");
                txtToBalance.Clear();
                txtToName.Clear();
                txtToTitle.Clear();
                txtToNum.Clear();
                txtFromBalance.Clear();
                txtFromName.Clear();
                txtFromTitle.Clear();
                txtFromNum.Clear();
                txtTranAmount.Clear();
            }
            else
            {
                x -= y;
                z += y;
                if (DAO.AccountDAO.Instance.Withdraw(x.ToString(), txtFromNum.Text) && DAO.AccountDAO.Instance.Deposit(z.ToString(), txtToNum.Text))
                {
                    MessageBox.Show("Chuyển Khoản Thành Công!");
                    txtFromBalance.Text = x.ToString();
                    txtToBalance.Text = z.ToString();
                    Transaction tran1 = new Transaction();
                    tran1.CusName = txtFromName.Text;
                    tran1.CusNum = txtFromNum.Text;
                    tran1.CusTitle = txtFromTitle.Text;
                    tran1.Date = DateTime.Now.ToString();
                    tran1.Amount = txtTranAmount.Text;
                    tran1.TranType1 = "Transfer";
                    tran1.ToAcc1 = txtFromNum.Text;
                    tran1.FromAcc1 = txtToNum.Text;
                    DAO.TransactionDAO.Instance.CreateTran(tran1);
                    txtToBalance.Clear();
                    txtToName.Clear();
                    txtToTitle.Clear();
                    txtToNum.Clear();
                    txtFromBalance.Clear();
                    txtFromName.Clear();
                    txtFromTitle.Clear();
                    txtFromNum.Clear();
                    txtTranAmount.Clear();
                    getAccounts();
                }
                else
                {
                    MessageBox.Show("Chuyển Khoản Thất Bại!");
                }
            }
        }

        private void tabDeposit_Leave(object sender, EventArgs e)
        {
            txtDeSeCusName.Clear();
            txtDeAccNum.Clear();
            txtDeSearchTitle.Clear();
            txtDeCusName.Clear();
            txtDeTitle.Clear();
            txtDEAccNumCon.Clear();
            txtDeBalace.Clear();
        }

        private void btnTransSearch_Click(object sender, EventArgs e)
        {
            string num = txtTransNum.Text;
            dtgrvTransaction.DataSource = DAO.TransactionDAO.Instance.getAccount(num);
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            calculator cal = new calculator();
            cal.Show();
        }

        private void btnCurrency_Click(object sender, EventArgs e)
        {
            CurrencyConverter form = new CurrencyConverter();
            form.Show();
        }

        private void btnNotepad_Click(object sender, EventArgs e)
        {
            notepad form = new notepad();
            form.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            pnlAdmin.Visible = true;
            dtgrvAdmin.DataSource = DTO.admin.Instance.getData();
        }

        private void btnCloseAdmin_Click(object sender, EventArgs e)
        {
            pnlAdmin.Visible = false;
        }

        private void btnSaveAdmin_Click(object sender, EventArgs e)
        {
            DataGridViewRow dtgrvr = dtgrvAdmin.CurrentRow;
            admin person = new admin();
            if (string.IsNullOrEmpty(dtgrvr.Cells["Username"].Value.ToString()) || string.IsNullOrEmpty(dtgrvr.Cells["Password"].Value.ToString()))
            {
                person.Username = dtgrvr.Cells["Username"].Value.ToString();
                person.Password = dtgrvr.Cells["Password"].Value.ToString();
                DTO.admin.Instance.addData(person);
            }
            else
            {
                person.Username = dtgrvr.Cells["Username"].Value.ToString();
                person.Password = dtgrvr.Cells["Password"].Value.ToString();
                DTO.admin.Instance.updateData(person);
            }
        }
        #endregion

        #region Methods
        public void ResetForm()
        {
            this.txtCusNameCre.Clear();
            this.txtAccNumCre.Clear();
            this.txtCreAccTitle.Clear();
            this.cbCreAccType.SelectedIndex = -1;
            this.dtCreDate.Value = DateTime.Now;
            this.txtCreAdd.Clear();
            this.txtCrePhone.Clear();
            this.txtUAName.Clear();
            this.txtUATitle.Clear();
            this.cbUAType.SelectedIndex = -1;
            this.txtUAAdd.Clear();
            this.txtUAPhone.Clear();
            this.txtUAEmail.Clear();
            this.txtUACom.Clear();
            this.txtUAOccu.Clear();
            this.txtUASearchNum.Clear();
            this.txtCBSName.Clear();
            this.txtCBSNum.Clear();
            this.txtCBSTitle.Clear();
            if (rabtnMale.Checked == true)
            { rabtnMale.Checked = false; }
            else if (rabtnFemale.Checked == true)
            { rabtnFemale.Checked = false; }
            else if (rabtnOther.Checked == true)
            { rabtnOther.Checked = false; }
            this.txtCreEmail.Clear();
            this.txtCreCom.Clear();
            this.txtCreOccu.Clear();
            this.txtCreDeposit.Clear();
            this.profileptr.Image = BankingSystem.Properties.Resources._127066563_1053964071708972_5273578564006566232_o;
            this.profilePictr.Image = BankingSystem.Properties.Resources._127066563_1053964071708972_5273578564006566232_o;

        }
        public Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        public bool IsNumber(string a)
        {
            foreach (char c in a)
            {
                if (!Char.IsNumber(c))
                {
                    return false;
                }
            }
            return true;
        }

        public void getAccounts()
        {
            dtgrvCusList.DataSource = DAO.AccountDAO.Instance.CusList();
        }

        #endregion
    }

}
