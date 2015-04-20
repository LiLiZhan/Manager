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
    public partial class WMIForm : Form, IRemote
    {
        private ManagementScope scope = null;
        private ManagementClass managementClass = null;
        private string path;
        public RemoteMachine Machine { get; set; }
        public WMIForm(RemoteMachine machine)
        {
            InitializeComponent();
            Text = string.Format("【WMI】{0}", machine.DesktopName);
            this.Machine = machine;
            ConnectionOptions options = null;
            if (this.Machine.Server != "." && this.Machine.UserName != null && this.Machine.UserName.Length > 0)
            {
                options = new ConnectionOptions();
                options.Username = this.Machine.UserName;
                options.Password = this.Machine.Password;
                //options.Authority = "ntlmdomain:DOMAIN"; 
            }
            this.scope = new ManagementScope("\\\\" + this.Machine.Server + "\\root\\cimv2", options);
        }

        private ComboBox comboBox;
        private DataGridView dataGrid;
        private void WMIForm_Load(object sender, EventArgs e)
        {
            this.dataGrid = new DataGridView() { Dock = DockStyle.Fill, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AllowUserToAddRows = false, AllowUserToDeleteRows = false, ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize, ReadOnly = true, RowHeadersWidth = 21 };
            this.Controls.Add(this.dataGrid);
            Panel panel = new Panel() { Dock = DockStyle.Top, Height = 25 };
            this.Controls.Add(panel);
            panel.Controls.Add(new Label() { Text = "请选择WMI类型", Location = new System.Drawing.Point(12, 5), Size = new System.Drawing.Size(90, 20) });
            this.comboBox = new ComboBox() { Location = new System.Drawing.Point(102, 2), Size = new System.Drawing.Size(200, 20) };
            this.comboBox.Items.AddRange(Enum.GetNames(typeof(WMIType)));
            panel.Controls.Add(this.comboBox);
            Button button = new Button() { Location = new System.Drawing.Point(303, 1), Size = new System.Drawing.Size(75, 23), Text = "查询" };
            button.Click += button_Click;
            panel.Controls.Add(button);
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.comboBox.Text))
            {
                if (Enum.IsDefined(typeof(WMIType), this.comboBox.Text))
                {
                    WMIType type = (WMIType)Enum.Parse(typeof(WMIType), this.comboBox.Text);
                    SetType(type.ToString());
                }
                else
                    SetType(this.comboBox.Text);
                if (Connect())
                {
                    DataTable table = GetProperties();
                    this.dataGrid.DataSource = table;
                }
            }
        }

        public void SetType(string type)
        {
            this.path = string.Format("\\\\{0}\\root\\cimv2:{1}", this.Machine.Server, type);
            this.managementClass = new ManagementClass(this.path);
            this.managementClass.Scope = this.scope;
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

        public DataTable GetProperties()
        {
            ObjectGetOptions objectGetOptions = new ObjectGetOptions();
            PropertyDataCollection properties = this.managementClass.Properties;
            DataTable table = new DataTable();
            foreach (PropertyData property in properties)
            {
                table.Columns.Add(property.Name);
            }
            foreach (ManagementObject mo in this.managementClass.GetInstances())
            {
                object[] items = new object[properties.Count];
                int index = 0;
                foreach (PropertyData property in properties)
                {
                    items[index++] = mo.Properties[property.Name].Value;
                }
                table.Rows.Add(items);
            }
            return table;
        }

        public void Disconnect()
        {
        }

        public enum WMIType
        {
            Win32_1394Controller,
            Win32_Account,
            Win32_AllocatedResource,
            Win32_Battery,
            Win32_BaseBoard, // 主板
            Win32_BaseService,
            Win32_BIOS, // BIOS 芯片
            Win32_BootConfiguration,
            Win32_Bus,
            Win32_CacheMemory,
            Win32_CDROMDrive, // 光盘驱动器
            Win32_CurrentProbe,
            Win32_ClassicCOMApplicationClasses,
            Win32_ClassicCOMClass,
            Win32_ClassicCOMClassSetting,
            Win32_ClassicCOMClassSettings,
            Win32_ClusterShare,
            Win32_ClientApplicationSetting,
            Win32_CodecFile,
            Win32_COMApplication,
            Win32_COMApplicationClasses,
            Win32_COMApplicationSettings,
            Win32_COMClass,
            Win32_ComClassAutoEmulator,
            Win32_ComClassEmulator,
            Win32_ComponentCategory,
            Win32_COMSetting,
            Win32_ComputerSystem,
            Win32_DiskDrive, // 硬盘驱动器
            Win32_DiskPartition, // 磁盘分区
            Win32_DeviceMemoryAddress,
            Win32_DesktopMonitor, // 显示器
            Win32_DisplayConfiguration, // 显卡
            Win32_DisplayControllerConfiguration, // 显卡设置
            Win32_DMAChannel,
            Win32_DCOMApplication,
            Win32_DCOMApplicationSetting,
            Win32_DependentService,
            Win32_Desktop,
            Win32_ComputerSystemProduct,
            Win32_Directory,
            Win32_Environment,
            Win32_Fan,
            Win32_FloppyController,
            Win32_FloppyDrive, // 软盘驱动器
            Win32_Group,
            Win32_GroupUser,
            Win32_HeatPipe,
            Win32_ImplementedCategory,
            Win32_IDEController,
            Win32_InfraredDevice,
            Win32_IRQResource,
            Win32_Keyboard, // 键盘
            Win32_LoadOrderGroup,
            Win32_LoadOrderGroupServiceDependencies,
            Win32_LoadOrderGroupServiceMembers,
            Win32_LoggedOnUser,
            Win32_LogonSession,
            Win32_LogicalDisk, // 逻辑磁盘
            Win32_LogicalDiskToPartition, // 逻辑磁盘所在分区及始末位置。
            Win32_LogicalMemoryConfiguration, // 逻辑内存配置
            Win32_MemoryArray,
            Win32_MemoryDevice,
            Win32_MotherboardDevice,
            Win32_NetworkClient, // 已安装的网络客户端
            Win32_NetworkProtocol, // 已安装的网络协议
            Win32_NetworkAdapter, // 网络适配器
            Win32_NetworkAdapterConfiguration, // 网络适配器设置
            Win32_OperatingSystem,
            Win32_OperatingSystemQFE,
            Win32_OptionalFeature,
            Win32_OSRecoveryConfiguration,
            Win32_OnBoardDevice,
            Win32_Processor, // CPU 处理器
            Win32_PhysicalMemory, // 物理内存条
            Win32_PCMCIAController,
            Win32_PhysicalMemoryArray,
            Win32_PnPEntity,
            Win32_PortableBattery,
            Win32_PortConnector,
            Win32_PortResource,
            Win32_PowerManagementEvent,
            Win32_POTSModem, // MODEM
            Win32_POTSModemToSerialPort, // MODEM 端口
            Win32_Printer, // 打印机
            Win32_PrinterConfiguration, // 打印机设置
            Win32_PrintJob, // 打印机任务
            Win32_ParallelPort, // 并口
            Win32_PointingDevice, // 点输入设备，包括鼠标。
            Win32_PageFile,
            Win32_PageFileElementSetting,
            Win32_PageFileSetting,
            Win32_PageFileUsage,
            Win32_PrivilegesStatus,
            Win32_Process,
            Win32_ProcessStartup,
            Win32_ProgramGroup,
            Win32_ProgramGroupContents,
            Win32_ProgramGroupOrItem,
            Win32_ProtocolBinding,
            Win32_QuickFixEngineering,
            Win32_Registry,
            Win32_Refrigeration,
            Win32_SMBIOSMemory,
            Win32_SerialPort, // 串口
            Win32_SerialPortConfiguration, // 串口配置
            Win32_SoundDevice, // 多媒体设置，一般指声卡。
            Win32_ScheduledJob,
            Win32_Service,
            Win32_Session,
            Win32_SessionProcess,
            Win32_Share,
            Win32_ShareToDirectory,
            Win32_StartupCommand,
            Win32_SubDirectory,
            Win32_ShortcutFile,
            Win32_SystemAccount,
            Win32_SystemBIOS,
            Win32_SystemBootConfiguration,
            Win32_SystemConfigurationChangeEvent,
            Win32_SystemDesktop,
            Win32_SystemDevices,
            Win32_SystemDriver,
            Win32_SystemDriverPNPEntity,
            Win32_SystemEnclosure,
            Win32_SystemLoadOrderGroups,
            Win32_SystemLogicalMemoryConfiguration,
            Win32_SystemMemoryResource,
            Win32_SystemNetworkConnections,
            Win32_SystemOperatingSystem,
            Win32_SystemPartitions,
            Win32_SystemProcesses,
            Win32_SystemProgramGroups,
            Win32_SystemResources,
            Win32_SystemServices,
            Win32_SystemSetting,
            Win32_SystemSlot,
            Win32_SystemSystemDriver,
            Win32_SystemTimeZone,
            Win32_SystemUsers,
            Win32_Thread,
            Win32_TimeZone,
            Win32_TapeDrive,
            Win32_TemperatureProbe,
            Win32_TCPIPPrinterPort, // 打印机端口
            Win32_USBHub,
            Win32_USBController, // USB 控制器
            Win32_UninterruptiblePowerSupply,
            Win32_UserAccount,
            Win32_UserDesktop,
            Win32_VolumeChangeEvent,
            Win32_VideoConfiguration,
            Win32_VideoController, // 显卡细节。
            Win32_VideoSettings, // 显卡支持的显示模式。
            Win32_VoltageProbe
        }
    }
}
