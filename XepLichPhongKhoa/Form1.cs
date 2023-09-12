using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XepLichPhongKhoa
{
    public partial class fLogin : Form
    {
        private AccountDAL bllaccount = new AccountDAL();
        private int _Prem;
        public int Prem
        {
            get { return _Prem; }
        }
        public fLogin()
        {
            InitializeComponent();
            panel1.Parent = pictureBox1;
            panel1.BackColor = Color.Transparent;
            panel2.Parent = pictureBox1;
            panel2.BackColor = Color.Transparent;
        }
        private bool CheckDataLogin(){
            if (string.IsNullOrEmpty(tbUsername.Text) || string.IsNullOrEmpty(tbUsername.Text))
            {
                return false;
            }
            return true;
        }
        private bool Login()
        {
            if (!CheckDataLogin()) return false;
            _Prem = bllaccount.CheckLogin(tbUsername.Text, tbPassword.Text);
            if (_Prem == 0 || _Prem == 1)
            {
                return true;
            }
            return false;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (Login())
            {
                fMain f = new fMain(_Prem,tbUsername.Text);
                this.Hide();
                f.ShowDialog();
                tbPassword.Text = null;
                this.Show();
                tbPassword.Focus();
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu bạn nhập không đúng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEcs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
