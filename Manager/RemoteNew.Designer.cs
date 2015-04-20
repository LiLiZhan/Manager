namespace Manager
{
    partial class RemoteNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteNew));
            this.lbTagName = new System.Windows.Forms.Label();
            this.tTagName = new System.Windows.Forms.TextBox();
            this.tServerName = new System.Windows.Forms.TextBox();
            this.lbServer = new System.Windows.Forms.Label();
            this.tDomain = new System.Windows.Forms.TextBox();
            this.lbDomain = new System.Windows.Forms.Label();
            this.tUserName = new System.Windows.Forms.TextBox();
            this.lbUserName = new System.Windows.Forms.Label();
            this.tPasswprd = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.checkBoxDrives = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.checkBoxShowProcess = new System.Windows.Forms.CheckBox();
            this.checkBoxShowService = new System.Windows.Forms.CheckBox();
            this.checkBoxRemote = new System.Windows.Forms.CheckBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTagName
            // 
            this.lbTagName.AutoSize = true;
            this.lbTagName.Location = new System.Drawing.Point(76, 23);
            this.lbTagName.Name = "lbTagName";
            this.lbTagName.Size = new System.Drawing.Size(41, 12);
            this.lbTagName.TabIndex = 0;
            this.lbTagName.Text = "名称：";
            // 
            // tTagName
            // 
            this.tTagName.Location = new System.Drawing.Point(123, 20);
            this.tTagName.Name = "tTagName";
            this.tTagName.Size = new System.Drawing.Size(123, 21);
            this.tTagName.TabIndex = 1;
            // 
            // tServerName
            // 
            this.tServerName.Location = new System.Drawing.Point(123, 47);
            this.tServerName.Name = "tServerName";
            this.tServerName.Size = new System.Drawing.Size(123, 21);
            this.tServerName.TabIndex = 3;
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(22, 50);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(95, 12);
            this.lbServer.TabIndex = 2;
            this.lbServer.Text = "计算机名/地址：";
            // 
            // tDomain
            // 
            this.tDomain.Location = new System.Drawing.Point(299, 20);
            this.tDomain.Name = "tDomain";
            this.tDomain.Size = new System.Drawing.Size(123, 21);
            this.tDomain.TabIndex = 5;
            // 
            // lbDomain
            // 
            this.lbDomain.AutoSize = true;
            this.lbDomain.Location = new System.Drawing.Point(264, 23);
            this.lbDomain.Name = "lbDomain";
            this.lbDomain.Size = new System.Drawing.Size(29, 12);
            this.lbDomain.TabIndex = 4;
            this.lbDomain.Text = "域：";
            // 
            // tUserName
            // 
            this.tUserName.Location = new System.Drawing.Point(123, 71);
            this.tUserName.Name = "tUserName";
            this.tUserName.Size = new System.Drawing.Size(123, 21);
            this.tUserName.TabIndex = 7;
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(64, 74);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(53, 12);
            this.lbUserName.TabIndex = 6;
            this.lbUserName.Text = "用户名：";
            // 
            // tPasswprd
            // 
            this.tPasswprd.Location = new System.Drawing.Point(299, 71);
            this.tPasswprd.Name = "tPasswprd";
            this.tPasswprd.PasswordChar = '*';
            this.tPasswprd.Size = new System.Drawing.Size(123, 21);
            this.tPasswprd.TabIndex = 9;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(252, 74);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(41, 12);
            this.lbPassword.TabIndex = 8;
            this.lbPassword.Text = "密码：";
            // 
            // checkBoxDrives
            // 
            this.checkBoxDrives.AutoSize = true;
            this.checkBoxDrives.Checked = true;
            this.checkBoxDrives.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDrives.Location = new System.Drawing.Point(123, 98);
            this.checkBoxDrives.Name = "checkBoxDrives";
            this.checkBoxDrives.Size = new System.Drawing.Size(108, 16);
            this.checkBoxDrives.TabIndex = 10;
            this.checkBoxDrives.Text = "共享磁盘驱动器";
            this.checkBoxDrives.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(266, 151);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(347, 151);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowProcess
            // 
            this.checkBoxShowProcess.AutoSize = true;
            this.checkBoxShowProcess.Checked = true;
            this.checkBoxShowProcess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowProcess.Location = new System.Drawing.Point(123, 120);
            this.checkBoxShowProcess.Name = "checkBoxShowProcess";
            this.checkBoxShowProcess.Size = new System.Drawing.Size(96, 16);
            this.checkBoxShowProcess.TabIndex = 13;
            this.checkBoxShowProcess.Text = "允许查询进程";
            this.checkBoxShowProcess.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowService
            // 
            this.checkBoxShowService.AutoSize = true;
            this.checkBoxShowService.Checked = true;
            this.checkBoxShowService.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowService.Location = new System.Drawing.Point(299, 120);
            this.checkBoxShowService.Name = "checkBoxShowService";
            this.checkBoxShowService.Size = new System.Drawing.Size(96, 16);
            this.checkBoxShowService.TabIndex = 14;
            this.checkBoxShowService.Text = "允许查询服务";
            this.checkBoxShowService.UseVisualStyleBackColor = true;
            // 
            // checkBoxRemote
            // 
            this.checkBoxRemote.AutoSize = true;
            this.checkBoxRemote.Location = new System.Drawing.Point(299, 98);
            this.checkBoxRemote.Name = "checkBoxRemote";
            this.checkBoxRemote.Size = new System.Drawing.Size(72, 16);
            this.checkBoxRemote.TabIndex = 15;
            this.checkBoxRemote.Text = "允许远程";
            this.checkBoxRemote.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(185, 151);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 16;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Visible = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // RemoteNew
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(450, 193);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.checkBoxRemote);
            this.Controls.Add(this.checkBoxShowService);
            this.Controls.Add(this.checkBoxShowProcess);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.checkBoxDrives);
            this.Controls.Add(this.tPasswprd);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.tUserName);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.tDomain);
            this.Controls.Add(this.lbDomain);
            this.Controls.Add(this.tServerName);
            this.Controls.Add(this.lbServer);
            this.Controls.Add(this.tTagName);
            this.Controls.Add(this.lbTagName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RemoteNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加/编辑设置";
            this.Load += new System.EventHandler(this.RemoteNew_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTagName;
        private System.Windows.Forms.TextBox tTagName;
        private System.Windows.Forms.TextBox tServerName;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.TextBox tDomain;
        private System.Windows.Forms.Label lbDomain;
        private System.Windows.Forms.TextBox tUserName;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.TextBox tPasswprd;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.CheckBox checkBoxDrives;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox checkBoxShowProcess;
        private System.Windows.Forms.CheckBox checkBoxShowService;
        private System.Windows.Forms.CheckBox checkBoxRemote;
        private System.Windows.Forms.Button btnDel;
    }
}