using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Manager
{
    public partial class RemoteNew : Form
    {
        private RemoteMachine mac;
        private IniFile ini;
        public RemoteNew(IniFile ini)
        {
            InitializeComponent();
            this.ini = ini;
        }

        public RemoteNew(IniFile ini, RemoteMachine mac)
        {
            InitializeComponent();
            this.ini = ini;
            this.mac = mac;
        }

        private void RemoteNew_Load(object sender, EventArgs e)
        {
            if (this.mac == null)
            {
                btnDel.Visible = false;
                this.mac = new RemoteMachine() { RedirectDrives = true };
            }
            else
            {
                btnDel.Visible = true;
                tTagName.Enabled = false;

                tTagName.Text = mac.DesktopName;
                tServerName.Text = mac.Server;
                tDomain.Text = mac.Domain;
                tUserName.Text = mac.UserName;
                tPasswprd.Text = mac.Password;
                checkBoxDrives.Checked = mac.RedirectDrives;
                checkBoxRemote.Checked = mac.RemoteAble;
                checkBoxShowProcess.Checked = mac.ShowProcess;
                checkBoxShowService.Checked = mac.ShowService;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tServerName.Text) || string.IsNullOrEmpty(tUserName.Text))
            {
                MessageBox.Show("不允许为空！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }
            mac.DesktopName = tTagName.Text;
            mac.Server = tServerName.Text;
            mac.Domain = tDomain.Text;
            mac.UserName = tUserName.Text;
            mac.Password = tPasswprd.Text;
            mac.RedirectDrives = checkBoxDrives.Checked;
            mac.RemoteAble = checkBoxRemote.Checked;
            mac.ShowProcess = checkBoxShowProcess.Checked;
            mac.ShowService = checkBoxShowService.Checked;
            mac.Save(ini);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("确认删除\"{0}\"？", this.mac.DesktopName), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.mac.Delete(this.ini);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
