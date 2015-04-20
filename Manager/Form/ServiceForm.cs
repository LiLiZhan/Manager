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
    public partial class ServiceForm : Form, IRemote
    {
        private ManagementScope scope = null;
        private ManagementClass managementClass = null;
        private string path = null;
        public RemoteMachine Machine { get; set; }
        public ServiceForm(RemoteMachine machine)
        {
            InitializeComponent();
            Text = string.Format("【服务】{0}", machine.DesktopName);
            this.Machine = machine;
            this.path = "\\\\" + this.Machine.Server + "\\root\\cimv2:Win32_Service";
            this.managementClass = new ManagementClass(this.path);
            ConnectionOptions options = null;
            if (this.Machine.Server != "." && this.Machine.UserName != null && this.Machine.UserName.Length > 0)
            {
                options = new ConnectionOptions();
                options.Username = this.Machine.UserName;
                options.Password = this.Machine.Password;
                //options.Impersonation = ImpersonationLevel.Impersonate;
                //options.Authentication = AuthenticationLevel.PacketIntegrity;
                //options.EnablePrivileges = true;
                //options.Authority = "ntlmdomain:domain"; 
            }
            this.scope = new ManagementScope("\\\\" + this.Machine.Server + "\\root\\cimv2", options);
            this.managementClass.Scope = this.scope;
        }

        private DataGridView dataGrid;
        private ContextMenuStrip contextMenu;
        private ServiceInfo[] services;
        private void ServiceForm_Load(object sender, EventArgs e)
        {
            this.contextMenu = new ContextMenuStrip();
            ToolStripItem start = this.contextMenu.Items.Add("启动");
            start.Click += start_Click;
            ToolStripItem stop = this.contextMenu.Items.Add("停止");
            stop.Click += stop_Click;
            ToolStripItem reStart = this.contextMenu.Items.Add("重启");
            reStart.Click += reStart_Click;
            this.dataGrid = new DataGridView() { Dock = DockStyle.Fill, ContextMenuStrip = this.contextMenu, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AllowUserToAddRows = false, AllowUserToDeleteRows = false, ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize, ReadOnly = true, RowHeadersWidth = 21 };
            this.Controls.Add(this.dataGrid);
            ReLoad();
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (this.dataGrid.SelectedRows.Count == 1)
            {
                try
                {
                    UInt32 processId = Convert.ToUInt32(this.dataGrid.SelectedRows[0].Cells[0].Value);
                    string serviceName = this.dataGrid.SelectedRows[0].Cells[1].Value.ToString();
                    string serviceStatus = this.dataGrid.SelectedRows[0].Cells[2].Value.ToString();
                    if (serviceStatus == "Running")
                    {
                        MessageBox.Show(string.Format("\"{0}\"服务已经运行！", serviceName), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        return;
                    }
                    if (services != null && serviceStatus == "Stopped" && serviceName != null && MessageBox.Show(string.Format("是否启动\"{0}\"服务？", serviceName), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ServiceInfo service = Array.Find(services, (ser) => { return ser.Name == serviceName; });
                        serviceStart(service);
                        ReLoad();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
            }
        }

        private void reStart_Click(object sender, EventArgs e)
        {
            if (this.dataGrid.SelectedRows.Count == 1)
            {
                try
                {
                    UInt32 processId = Convert.ToUInt32(this.dataGrid.SelectedRows[0].Cells[0].Value);
                    string serviceName = this.dataGrid.SelectedRows[0].Cells[1].Value.ToString();
                    string serviceStatus = this.dataGrid.SelectedRows[0].Cells[2].Value.ToString();
                    if (services != null && serviceStatus == "Running" && serviceName != null && MessageBox.Show(string.Format("是否重启\"{0}\"服务？", serviceName), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ServiceInfo service = Array.Find(services, (ser) => { return ser.Name == serviceName; });
                        serviceStop(service);
                        serviceStart(service);
                        ReLoad();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            if (this.dataGrid.SelectedRows.Count == 1)
            {
                try
                {
                    UInt32 processId = Convert.ToUInt32(this.dataGrid.SelectedRows[0].Cells[0].Value);
                    string serviceName = this.dataGrid.SelectedRows[0].Cells[1].Value.ToString();
                    string serviceStatus = this.dataGrid.SelectedRows[0].Cells[2].Value.ToString();
                    if (serviceStatus == "Stopped")
                    {
                        MessageBox.Show(string.Format("\"{0}\"服务已经停止！", serviceName), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        return;
                    }
                    if (services != null && serviceStatus == "Running" && serviceName != null && MessageBox.Show(string.Format("是否停止\"{0}\"服务？", serviceName), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ServiceInfo service = Array.Find(services, (ser) => { return ser.Name == serviceName; });
                        serviceStop(service);
                        ReLoad();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
            }
        }

        private void ReLoad()
        {
            this.dataGrid.DataSource = null;
            this.services = null;
            if (Connect())
            {
                services = GetServices();
                DataTable table = ServiceInfo.ConvertTo(services);
                BindData(table);
            }
        }

        public void BindData(DataTable table)
        {
            this.dataGrid.DataSource = table;
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

        public ServiceInfo[] GetServices()
        {
            ManagementObjectCollection queryCollection = this.managementClass.GetInstances();
            List<ServiceInfo> services = new List<ServiceInfo>();
            foreach (ManagementObject m in queryCollection)
            {
                ServiceInfo service = new ServiceInfo(m);
                services.Add(service);
            }
            return services.ToArray();
        }

        private void serviceStart(ServiceInfo service)
        {
            if (service != null)
            {
                ManagementObject mo = this.managementClass.CreateInstance();
                mo.Path = new ManagementPath(this.path + ".Name=\"" + service.Name + "\"");
                if (mo["State"].ToString() == "Stopped")
                {
                    object obj = mo.InvokeMethod("StartService", null);
                    Console.WriteLine(obj.ToString());
                }
            }
        }

        private void serviceStop(ServiceInfo service)
        {
            if (service != null)
            {
                ManagementObject mo = this.managementClass.CreateInstance();
                mo.Path = new ManagementPath(this.path + ".Name=\"" + service.Name + "\"");
                if (Convert.ToBoolean(mo["AcceptStop"]))
                {
                    object obj = mo.InvokeMethod("StopService", null);
                    Console.WriteLine(obj.ToString());
                }
            }
        }
    }
}
