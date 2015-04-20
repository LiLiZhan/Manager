using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;

using System.Text;
using System.Windows.Forms;

namespace Manager
{
    public partial class MainForm : Form
    {
        private IniFile ini;
        private List<RemoteMachine> macs;
        private string inipath;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadIni(Path.Combine(Application.StartupPath, "config.ini"));
        }

        private void LoadIni(string path)
        {
            inipath = path;
            ini = new IniFile(path);
            macs = RemoteMachine.Load(ini);
            iRemoteDesktop.DropDownItems.Clear();
            iRemoteProcess.DropDownItems.Clear();
            iRemoteService.DropDownItems.Clear();
            iRemoteWMI.DropDownItems.Clear();
            iEdit.DropDownItems.Clear();

            if (macs != null)
            {
                foreach (RemoteMachine mac in macs)
                {
                    ToolStripMenuItem edit = new ToolStripMenuItem(mac.DesktopName);
                    edit.Tag = mac;
                    edit.Click += edit_Click;
                    iEdit.DropDownItems.Add(edit);
                    ToolStripMenuItem wmi = new ToolStripMenuItem(mac.DesktopName);
                    wmi.Tag = mac;
                    iRemoteWMI.DropDownItems.Add(wmi);
                    wmi.Click += wmi_Click;
                    if (mac.RemoteAble)
                    {
                        ToolStripMenuItem desktop = new ToolStripMenuItem(mac.DesktopName);
                        desktop.Tag = mac;
                        iRemoteDesktop.DropDownItems.Add(desktop);
                        desktop.Click += desktop_Click;
                    }
                    if (mac.ShowProcess)
                    {
                        ToolStripMenuItem process = new ToolStripMenuItem(mac.DesktopName);
                        process.Tag = mac;
                        iRemoteProcess.DropDownItems.Add(process);
                        process.Click += process_Click;
                    }
                    if (mac.ShowService)
                    {
                        ToolStripMenuItem service = new ToolStripMenuItem(mac.DesktopName);
                        service.Tag = mac;
                        iRemoteService.DropDownItems.Add(service);
                        service.Click += service_Click;
                    }
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                try
                {
                    RemoteMachine mac = item.Tag as RemoteMachine;
                    using (RemoteNew _new = new RemoteNew(this.ini, mac))
                    {
                        if (_new.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            LoadIni(inipath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
            }
        }

        private void wmi_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                try
                {
                    RemoteMachine mac = item.Tag as RemoteMachine;
                    WMIForm wmi = new WMIForm(mac);
                    wmi.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
            }
        }

        private void service_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                try
                {
                    RemoteMachine mac = item.Tag as RemoteMachine;
                    ServiceForm sf = new ServiceForm(mac);
                    sf.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
            }
        }

        private void process_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                try
                {
                    RemoteMachine mac = item.Tag as RemoteMachine;
                    ProcessForm pf = new ProcessForm(mac);
                    pf.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
            }
        }

        private void remoteNew_Click(object sender, EventArgs e)
        {
            using (RemoteNew rn = new RemoteNew(this.ini))
            {
                if (rn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LoadIni(inipath);
                }
            }
        }

        private void desktop_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                try
                {
                    RemoteMachine mac = item.Tag as RemoteMachine;
                    using (DesktopForm df = new DesktopForm(mac))
                    {
                        df.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
            }
        }

        private void iOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Ini文件|*.ini", InitialDirectory = Application.StartupPath, Multiselect = false, Title = "选择打开的配置文件" })
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    LoadIni(ofd.FileName);
                }
            }
        }
    }
}
