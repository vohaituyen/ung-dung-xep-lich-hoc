using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace XepLichPhongKhoa
{
    public partial class fInsertAcc : Form
    {
        private AccountDAL bllaccount = new AccountDAL();
        private string UserName;
        private string Prem;
        public fInsertAcc()
        {
            InitializeComponent();
            LoadAccount();
        }
        public void LoadAccount()
        {
            AccountDAL account = new AccountDAL();
            dtgvAcc.DataSource = account.getAccount();
            ClearTextbox();
            btnDeleteAcc.Enabled = false;
            //btnDeleteAcc.ForeColor = Color.Azure;
        }
        private bool CheckDataAccount()
        {
            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                MessageBox.Show("Bạn chưa nhập Tên tài khoản !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbUsername.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mật khẩu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbUsername.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Bạn chưa nhập Tên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbbSex.Text))
            {
                MessageBox.Show("Bạn chưa nhập Giới tính !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbSex.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtpBirthday.Text))
            {
                MessageBox.Show("Bạn chưa nhập Tên tài khoản !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpBirthday.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbCareer.Text))
            {
                MessageBox.Show("Bạn chưa nhập Chức danh !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbCareer.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbAddress.Text))
            {
                MessageBox.Show("Bạn chưa nhập Địa chỉ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbAddress.Focus();
                return false;
            }
            return true;
        }
        private void ClearTextbox()
        {
            tbUsername.Text = null;
            tbPassword.Text = null;
            tbName.Text = null;
            tbCareer.Text = null;
            tbAddress.Text = null;
            //pbInsertPhoto.Image = null;
        }

        private byte[] ImageToByte(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }

        private void pbInsertPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbInsertPhoto.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }

        private void tbSearchA_TextChanged(object sender, EventArgs e)
        {
            string str = tbSearchA.Text;
            if (!string.IsNullOrEmpty(str))
            {
                DataTable data = bllaccount.FindAccount(tbSearchA.Text);
                dtgvAcc.DataSource = data;
                //btnDeleteAcc.Enabled=true;
            }
            else
            {
                LoadAccount();
            }
        }


        private void dtgvAcc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                UserName = dtgvAcc.Rows[index].Cells[0].Value.ToString();
                Prem = dtgvAcc.Rows[index].Cells[5].Value.ToString();
                btnDeleteAcc.Enabled = true;
            }
           
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (CheckDataAccount())
            {
                Account acc = new Account();
                acc.Username = tbUsername.Text;
                acc.Password = tbPassword.Text;
                acc.Name = tbName.Text;
                if (cbbSex.Text == "Nam") acc.Sex = true;
                else acc.Sex = false;
                acc.Birthday = dtpBirthday.Value;
                acc.Career = tbCareer.Text;
                acc.Address = tbAddress.Text;
                if (cbPrem.Checked)
                {
                    acc.Premission = false;
                }
                else acc.Premission = false;
                acc.Photo = ImageToByte(pbInsertPhoto.Image);
                if (bllaccount.InsertAccountDAL(acc))
                {
                    MessageBox.Show("Thêm thành công tài khoản !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra ??? !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearTextbox();
        }

        private void btnDeleteAcc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa tài khoản này ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Account acc = new Account();
                acc.Username = UserName;

                if (Prem == "True")
                {
                    MessageBox.Show("Không thể xóa tài khoản có quyền quản trị !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (bllaccount.DeleteAcountDAL(acc))
                {
                    if (string.IsNullOrEmpty(tbSearchA.Text))
                    {
                        LoadAccount();
                    }
                    else
                    {
                        LoadAccount();
                        tbSearchA_TextChanged(sender, e);
                    }
                    btnDeleteAcc.Enabled = false;
                }
            }
        }

    }
}
