using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Management;
using System.Text;
using System.Windows.Forms;

namespace Manager
{
    public partial class ProcessForm : Form, IRemote
    {
        private ManagementScope scope = null;
        private ManagementClass managementClass = null;
        private string path = null;
        public RemoteMachine Machine { get; set; }
        public ProcessForm(RemoteMachine machine)
        {
            InitializeComponent();
            Text = string.Format("【进程】{0}", machine.DesktopName);
            this.Machine = machine;
            this.path = "\\\\" + this.Machine.Server + "\\root\\cimv2:Win32_Process";
            this.managementClass = new ManagementClass(this.path);
            ConnectionOptions options = null;
            if (this.Machine.Server != "." && this.Machine.UserName != null && this.Machine.UserName.Length > 0)
            {
                options = new ConnectionOptions();
                options.Username = this.Machine.UserName;
                options.Password = this.Machine.Password;
                //options.EnablePrivileges = true;
                //options.Impersonation = ImpersonationLevel.Impersonate;
                //options.Authority = "ntlmdomain:domain"; 
            }
            this.scope = new ManagementScope("\\\\" + this.Machine.Server + "\\root\\cimv2", options);
            this.managementClass.Scope = this.scope;
        }

        private DataGridView dataGrid;
        private ContextMenuStrip contextMenu;
        private ProcessInfo[] processes;
        private void ProcessForm_Load(object sender, EventArgs e)
        {
            this.contextMenu = new ContextMenuStrip();
            ToolStripItem item = this.contextMenu.Items.Add("停止");
            item.Click += item_Click;
            this.dataGrid = new DataGridView() { Dock = DockStyle.Fill, ContextMenuStrip = this.contextMenu, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AllowUserToAddRows = false, AllowUserToDeleteRows = false, ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize, ReadOnly = true, RowHeadersWidth = 21 };
            this.Controls.Add(this.dataGrid);
            ReLoad();
        }

        private void ReLoad()
        {
            this.dataGrid.DataSource = null;
            this.processes = null;
            if (Connect())
            {
                processes = GetProcess();
                DataTable table = ProcessInfo.ConvertTo(processes);
                BindData(table);
            }
        }

        private void item_Click(object sender, EventArgs e)
        {
            if (this.dataGrid.SelectedRows.Count == 1)
            {
                try
                {
                    UInt32 processId = Convert.ToUInt32(this.dataGrid.SelectedRows[0].Cells[0].Value);
                    string processName = this.dataGrid.SelectedRows[0].Cells[1].Value.ToString();
                    if (processName != null && MessageBox.Show(string.Format("是否停止\"{0}\"进程？", processName), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ProcessInfo process = Array.Find(processes, (pro) => { return pro.Name == processName && pro.ProcessId == processId; });
                        KillProcess(process);
                        ReLoad();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
            }
        }

        public bool Connect()
        {
            try
            {
                scope.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return scope.IsConnected;
        }

        public void Disconnect()
        {

        }

        public void BindData(DataTable table)
        {
            this.dataGrid.DataSource = table;
        }

        public ProcessInfo[] GetProcess()
        {
            ManagementObjectCollection queryCollection = this.managementClass.GetInstances();
            List<ProcessInfo> processes = new List<ProcessInfo>();
            foreach (ManagementObject m in queryCollection)
            {
                ProcessInfo process = new ProcessInfo(m);
                processes.Add(process);
            }
            return processes.ToArray();
        }

        public void KillProcess(ProcessInfo process)
        {
            ObjectQuery query = new ObjectQuery(string.Format("select * from Win32_Process where ProcessId={0}", process.ProcessId));
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection queryCollection = searcher.Get();
            foreach (ManagementObject m in queryCollection)
            {
                string[] args = new string[] { "0" };
                object obj = m.InvokeMethod("Terminate", args);
                Console.WriteLine(obj.ToString());
                return;
            }
        }
    }
}
