using AxMSTSCLib;
using System;
using System.Windows.Forms;

namespace Manager
{
    public partial class DesktopForm : Form, IRemote
    {
        private AxMsRdpClient4 rdpc = null;
        public RemoteMachine Machine { get; set; }
        public DesktopForm(RemoteMachine machine)
        {
            InitializeComponent();
            Text = string.Format("【远程】{0}", machine.DesktopName);
            this.Machine = machine;
        }

        private void DesktopForm_Load(object sender, EventArgs e)
        {
            this.rdpc = new AxMsRdpClient4() { Dock = DockStyle.Fill };
            this.rdpc.OnDisconnected += rdpc_OnDisconnected;
            this.Controls.Add(this.rdpc);
            this.SetRdpClientProperties(this.Machine);
            Connect();
        }

        private void rdpc_OnDisconnected(object sender, IMsTscAxEvents_OnDisconnectedEvent e)
        {

        }

        public bool Connect()
        {
            try
            {
                rdpc.Connect();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (rdpc.Connected == 1)
                    rdpc.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetRdpClientProperties(RemoteMachine machine)
        {
            rdpc.Server = machine.Server;
            rdpc.UserName = machine.UserName;
            rdpc.Domain = machine.Domain;
            if (!string.IsNullOrEmpty(machine.Password))
                rdpc.AdvancedSettings5.ClearTextPassword = machine.Password;
            rdpc.AdvancedSettings5.RedirectDrives = machine.RedirectDrives;
            rdpc.AdvancedSettings5.RedirectPrinters = machine.RedirectPrinters;
            rdpc.AdvancedSettings5.RedirectPorts = machine.RedirectPorts;
            rdpc.ColorDepth = (int)machine.ColorDepth;
            rdpc.Dock = DockStyle.Fill;
        }
    }
}
