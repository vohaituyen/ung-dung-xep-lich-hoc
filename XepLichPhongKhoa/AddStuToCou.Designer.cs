
namespace XepLichPhongKhoa
{
    partial class AddStuToCou
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
            this.panel17 = new System.Windows.Forms.Panel();
            this.btnAddCouToStu = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dtgvCourseOfStu = new System.Windows.Forms.DataGridView();
            this.panel32 = new System.Windows.Forms.Panel();
            this.tbSearchS = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCourseOfStu)).BeginInit();
            this.panel32.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.panel17.Controls.Add(this.panel32);
            this.panel17.Controls.Add(this.dtgvCourseOfStu);
            this.panel17.Controls.Add(this.btnAddCouToStu);
            this.panel17.Controls.Add(this.label7);
            this.panel17.Location = new System.Drawing.Point(4, 5);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(792, 449);
            this.panel17.TabIndex = 6;
            // 
            // btnAddCouToStu
            // 
            this.btnAddCouToStu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.btnAddCouToStu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCouToStu.ForeColor = System.Drawing.Color.Azure;
            this.btnAddCouToStu.Location = new System.Drawing.Point(578, 403);
            this.btnAddCouToStu.Name = "btnAddCouToStu";
            this.btnAddCouToStu.Size = new System.Drawing.Size(173, 38);
            this.btnAddCouToStu.TabIndex = 12;
            this.btnAddCouToStu.Text = "Thêm ";
            this.btnAddCouToStu.UseVisualStyleBackColor = false;
            this.btnAddCouToStu.Click += new System.EventHandler(this.BtnAddCouToStu_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.label7.Location = new System.Drawing.Point(277, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(232, 36);
            this.label7.TabIndex = 5;
            this.label7.Text = "Thêm khóa học";
            // 
            // dtgvCourseOfStu
            // 
            this.dtgvCourseOfStu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvCourseOfStu.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.dtgvCourseOfStu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCourseOfStu.Location = new System.Drawing.Point(0, 48);
            this.dtgvCourseOfStu.Name = "dtgvCourseOfStu";
            this.dtgvCourseOfStu.RowHeadersWidth = 51;
            this.dtgvCourseOfStu.RowTemplate.Height = 24;
            this.dtgvCourseOfStu.Size = new System.Drawing.Size(792, 334);
            this.dtgvCourseOfStu.TabIndex = 17;
            this.dtgvCourseOfStu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgvCourseOfStu_CellClick);
            // 
            // panel32
            // 
            this.panel32.Controls.Add(this.tbSearchS);
            this.panel32.Controls.Add(this.label17);
            this.panel32.Location = new System.Drawing.Point(252, 400);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(289, 46);
            this.panel32.TabIndex = 18;
            // 
            // tbSearchS
            // 
            this.tbSearchS.BackColor = System.Drawing.Color.White;
            this.tbSearchS.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchS.Location = new System.Drawing.Point(110, 6);
            this.tbSearchS.Name = "tbSearchS";
            this.tbSearchS.Size = new System.Drawing.Size(164, 32);
            this.tbSearchS.TabIndex = 1;
            this.tbSearchS.TextChanged += new System.EventHandler(this.TbSearchS_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.label17.Location = new System.Drawing.Point(3, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(101, 26);
            this.label17.TabIndex = 0;
            this.label17.Text = "Tìm kiếm";
            // 
            // AddStuToCou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(800, 458);
            this.Controls.Add(this.panel17);
            this.Name = "AddStuToCou";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddStuToCou";
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCourseOfStu)).EndInit();
            this.panel32.ResumeLayout(false);
            this.panel32.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Button btnAddCouToStu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dtgvCourseOfStu;
        private System.Windows.Forms.Panel panel32;
        private System.Windows.Forms.TextBox tbSearchS;
        private System.Windows.Forms.Label label17;
    }
}