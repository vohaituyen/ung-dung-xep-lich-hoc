namespace XepLichPhongKhoa
{
    partial class fInsertAcc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fInsertAcc));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAddAccount = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbInsertPhoto = new System.Windows.Forms.PictureBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.cbPrem = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbbSex = new System.Windows.Forms.ComboBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbCareer = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabAccount = new System.Windows.Forms.TabPage();
            this.panel14 = new System.Windows.Forms.Panel();
            this.tbSearchA = new System.Windows.Forms.TextBox();
            this.lbSearchC = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgvAcc = new System.Windows.Forms.DataGridView();
            this.btnDeleteAcc = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabAddAccount.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInsertPhoto)).BeginInit();
            this.panel17.SuspendLayout();
            this.tabAccount.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAcc)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAddAccount);
            this.tabControl1.Controls.Add(this.tabAccount);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1189, 549);
            this.tabControl1.TabIndex = 0;
            // 
            // tabAddAccount
            // 
            this.tabAddAccount.BackColor = System.Drawing.Color.Gainsboro;
            this.tabAddAccount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabAddAccount.BackgroundImage")));
            this.tabAddAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabAddAccount.Controls.Add(this.panel2);
            this.tabAddAccount.Controls.Add(this.panel17);
            this.tabAddAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabAddAccount.Location = new System.Drawing.Point(4, 34);
            this.tabAddAccount.Name = "tabAddAccount";
            this.tabAddAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddAccount.Size = new System.Drawing.Size(1181, 511);
            this.tabAddAccount.TabIndex = 0;
            this.tabAddAccount.Text = "Thêm tài khoản";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.panel2.Controls.Add(this.pbInsertPhoto);
            this.panel2.Location = new System.Drawing.Point(59, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(362, 416);
            this.panel2.TabIndex = 6;
            // 
            // pbInsertPhoto
            // 
            this.pbInsertPhoto.BackColor = System.Drawing.Color.White;
            this.pbInsertPhoto.Location = new System.Drawing.Point(23, 21);
            this.pbInsertPhoto.Name = "pbInsertPhoto";
            this.pbInsertPhoto.Size = new System.Drawing.Size(316, 370);
            this.pbInsertPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInsertPhoto.TabIndex = 4;
            this.pbInsertPhoto.TabStop = false;
            this.pbInsertPhoto.Click += new System.EventHandler(this.pbInsertPhoto_Click);
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.panel17.Controls.Add(this.cbPrem);
            this.panel17.Controls.Add(this.label9);
            this.panel17.Controls.Add(this.cbbSex);
            this.panel17.Controls.Add(this.tbPassword);
            this.panel17.Controls.Add(this.label8);
            this.panel17.Controls.Add(this.tbUsername);
            this.panel17.Controls.Add(this.label1);
            this.panel17.Controls.Add(this.btnCancel);
            this.panel17.Controls.Add(this.dtpBirthday);
            this.panel17.Controls.Add(this.btnSaveUser);
            this.panel17.Controls.Add(this.tbAddress);
            this.panel17.Controls.Add(this.tbCareer);
            this.panel17.Controls.Add(this.tbName);
            this.panel17.Controls.Add(this.label7);
            this.panel17.Controls.Add(this.label6);
            this.panel17.Controls.Add(this.label5);
            this.panel17.Controls.Add(this.label4);
            this.panel17.Controls.Add(this.label3);
            this.panel17.Controls.Add(this.label2);
            this.panel17.Location = new System.Drawing.Point(504, 52);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(611, 413);
            this.panel17.TabIndex = 5;
            // 
            // cbPrem
            // 
            this.cbPrem.AutoSize = true;
            this.cbPrem.Location = new System.Drawing.Point(491, 285);
            this.cbPrem.Name = "cbPrem";
            this.cbPrem.Size = new System.Drawing.Size(18, 17);
            this.cbPrem.TabIndex = 23;
            this.cbPrem.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.label9.Location = new System.Drawing.Point(335, 283);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 25);
            this.label9.TabIndex = 22;
            this.label9.Text = "Quyền quản lý :";
            // 
            // cbbSex
            // 
            this.cbbSex.BackColor = System.Drawing.Color.White;
            this.cbbSex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSex.FormattingEnabled = true;
            this.cbbSex.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbbSex.Location = new System.Drawing.Point(487, 163);
            this.cbbSex.Name = "cbbSex";
            this.cbbSex.Size = new System.Drawing.Size(92, 33);
            this.cbbSex.TabIndex = 21;
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.White;
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(446, 103);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(133, 30);
            this.tbPassword.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.label8.Location = new System.Drawing.Point(336, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 25);
            this.label8.TabIndex = 19;
            this.label8.Text = "Mật khẩu :";
            // 
            // tbUsername
            // 
            this.tbUsername.BackColor = System.Drawing.Color.White;
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(186, 101);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(129, 30);
            this.tbUsername.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.label1.Location = new System.Drawing.Point(40, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tên tài khoản :";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Azure;
            this.btnCancel.Location = new System.Drawing.Point(375, 337);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(204, 38);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.CustomFormat = "dd/MM/yyy";
            this.dtpBirthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthday.Location = new System.Drawing.Point(168, 225);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(147, 30);
            this.dtpBirthday.TabIndex = 15;
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.btnSaveUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveUser.ForeColor = System.Drawing.Color.Azure;
            this.btnSaveUser.Location = new System.Drawing.Point(128, 337);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(204, 38);
            this.btnSaveUser.TabIndex = 12;
            this.btnSaveUser.Text = "Lưu tài khoản";
            this.btnSaveUser.UseVisualStyleBackColor = false;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // tbAddress
            // 
            this.tbAddress.BackColor = System.Drawing.Color.White;
            this.tbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddress.Location = new System.Drawing.Point(128, 280);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(187, 30);
            this.tbAddress.TabIndex = 10;
            // 
            // tbCareer
            // 
            this.tbCareer.BackColor = System.Drawing.Color.White;
            this.tbCareer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCareer.Location = new System.Drawing.Point(461, 222);
            this.tbCareer.Name = "tbCareer";
            this.tbCareer.Size = new System.Drawing.Size(118, 30);
            this.tbCareer.TabIndex = 9;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.White;
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(104, 163);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(211, 30);
            this.tbName.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.label7.Location = new System.Drawing.Point(159, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(232, 36);
            this.label7.TabIndex = 5;
            this.label7.Text = "Thêm tài khoản";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.label6.Location = new System.Drawing.Point(336, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Chức danh :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.label5.Location = new System.Drawing.Point(40, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Địa chỉ :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.label4.Location = new System.Drawing.Point(40, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày sinh :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.label3.Location = new System.Drawing.Point(395, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Giới tính :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.label2.Location = new System.Drawing.Point(40, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên :";
            // 
            // tabAccount
            // 
            this.tabAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.tabAccount.Controls.Add(this.btnDeleteAcc);
            this.tabAccount.Controls.Add(this.panel14);
            this.tabAccount.Controls.Add(this.panel1);
            this.tabAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabAccount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabAccount.Location = new System.Drawing.Point(4, 34);
            this.tabAccount.Name = "tabAccount";
            this.tabAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccount.Size = new System.Drawing.Size(1181, 511);
            this.tabAccount.TabIndex = 1;
            this.tabAccount.Text = "Danh sách tài khoản";
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.tbSearchA);
            this.panel14.Controls.Add(this.lbSearchC);
            this.panel14.Location = new System.Drawing.Point(538, 411);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(518, 56);
            this.panel14.TabIndex = 9;
            // 
            // tbSearchA
            // 
            this.tbSearchA.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchA.Location = new System.Drawing.Point(171, 7);
            this.tbSearchA.Name = "tbSearchA";
            this.tbSearchA.Size = new System.Drawing.Size(335, 38);
            this.tbSearchA.TabIndex = 1;
            this.tbSearchA.TextChanged += new System.EventHandler(this.tbSearchA_TextChanged);
            // 
            // lbSearchC
            // 
            this.lbSearchC.AutoSize = true;
            this.lbSearchC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSearchC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.lbSearchC.Location = new System.Drawing.Point(16, 10);
            this.lbSearchC.Name = "lbSearchC";
            this.lbSearchC.Size = new System.Drawing.Size(123, 31);
            this.lbSearchC.TabIndex = 0;
            this.lbSearchC.Text = "Tìm kiếm";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgvAcc);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1169, 353);
            this.panel1.TabIndex = 0;
            // 
            // dtgvAcc
            // 
            this.dtgvAcc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvAcc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.dtgvAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvAcc.Location = new System.Drawing.Point(1, 1);
            this.dtgvAcc.Name = "dtgvAcc";
            this.dtgvAcc.RowTemplate.Height = 24;
            this.dtgvAcc.Size = new System.Drawing.Size(1167, 352);
            this.dtgvAcc.TabIndex = 0;
            this.dtgvAcc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvAcc_CellClick);
            // 
            // btnDeleteAcc
            // 
            this.btnDeleteAcc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.btnDeleteAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnDeleteAcc.Location = new System.Drawing.Point(115, 411);
            this.btnDeleteAcc.Name = "btnDeleteAcc";
            this.btnDeleteAcc.Size = new System.Drawing.Size(275, 56);
            this.btnDeleteAcc.TabIndex = 10;
            this.btnDeleteAcc.Text = "Xóa tài khoản";
            this.btnDeleteAcc.UseVisualStyleBackColor = false;
            this.btnDeleteAcc.Click += new System.EventHandler(this.btnDeleteAcc_Click);
            // 
            // fInsertAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(1190, 550);
            this.Controls.Add(this.tabControl1);
            this.Name = "fInsertAcc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tabControl1.ResumeLayout(false);
            this.tabAddAccount.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbInsertPhoto)).EndInit();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.tabAccount.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAcc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAddAccount;
        private System.Windows.Forms.TabPage tabAccount;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbCareer;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbInsertPhoto;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.TextBox tbSearchA;
        private System.Windows.Forms.Label lbSearchC;
        private System.Windows.Forms.DataGridView dtgvAcc;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbSex;
        private System.Windows.Forms.CheckBox cbPrem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDeleteAcc;

    }
}