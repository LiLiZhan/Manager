using System.Collections.Generic;

namespace Manager
{
    public class RemoteMachine
    {
        /// <summary>
        /// 桌面名称
        /// </summary>
        public string DesktopName { get { return this._DesktopName ?? this.Server; } set { this._DesktopName = value; } }
        private string _DesktopName = null;
        /// <summary>
        /// 远程桌面的IP地址或者域名
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// IP
        /// </summary>
        public string Domain { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 允许查询进程
        /// </summary>
        public bool ShowProcess { get { return _ShowProcess; } set { _ShowProcess = value; } }
        private bool _ShowProcess = true;
        /// <summary>
        /// 允许远程
        /// </summary>
        public bool RemoteAble { get { return _RemoteAble; } set { _RemoteAble = value; } }
        private bool _RemoteAble = true;
        /// <summary>
        /// 允许查询服务
        /// </summary>
        public bool ShowService { get { return _ShowService; } set { _ShowService = value; } }
        private bool _ShowService = true;
        /// <summary>
        /// 共享磁盘驱动器
        /// </summary>
        public bool RedirectDrives { get { return _RedirectDrives; } set { _RedirectDrives = value; } }
        private bool _RedirectDrives = true;
        /// <summary>
        /// 共享打印机
        /// </summary>
        public bool RedirectPrinters { get { return _RedirectPrinters; } set { _RedirectPrinters = value; } }
        private bool _RedirectPrinters = false;
        /// <summary>
        /// 共享端口
        /// </summary>
        public bool RedirectPorts { get { return _RedirectPorts; } set { _RedirectPorts = value; } }
        private bool _RedirectPorts = false;
        /// <summary>
        /// 色彩深度
        /// </summary>
        public Colors ColorDepth { get { return _ColorDepth; } set { _ColorDepth = value; } }
        private Colors _ColorDepth = Colors.Color24;

        public override string ToString()
        {
            return string.Format("{0}:{1}", this.DesktopName, this.Server);
        }

        public void Save(IniFile iniFile)
        {
            Save(this, iniFile);
        }

        public void Delete(IniFile iniFile)
        {
            string section = string.Format("Remote({0})", this.DesktopName);
            iniFile.DeleteSection(section);
        }

        public void Load(IniFile iniFile, string desktopName)
        {
            string section = string.Format("Remote({0})", desktopName);
            this.DesktopName = desktopName;
            this.Server = iniFile.ReadString(section, "Server", "");
            this.UserName = iniFile.ReadString(section, "UserName", "");
            this.Domain = iniFile.ReadString(section, "Domain", "");
            this.Password = iniFile.ReadString(section, "Password", "");
            this.RemoteAble = iniFile.ReadInt(section, "RemoteAble", 0) == 1;
            this.ShowProcess = iniFile.ReadInt(section, "ShowProcess", 0) == 1;
            this.ShowService = iniFile.ReadInt(section, "ShowService", 0) == 1;
            this.RedirectDrives = iniFile.ReadInt(section, "RedirectDrives", 0) == 1;
            this.RedirectPrinters = iniFile.ReadInt(section, "RedirectPrinters", 0) == 1;
            this.RedirectPorts = iniFile.ReadInt(section, "RedirectPorts", 0) == 1;
            this.ColorDepth = (Colors)iniFile.ReadInt(section, "ColorDepth", 0);
        }

        public static RemoteMachine Load(string desktopName, IniFile iniFile)
        {
            string section = string.Format("Remote({0})", desktopName);
            RemoteMachine mac = new RemoteMachine();
            mac.DesktopName = desktopName;
            mac.Server = iniFile.ReadString(section, "Server", "");
            mac.UserName = iniFile.ReadString(section, "UserName", "");
            mac.Domain = iniFile.ReadString(section, "Domain", "");
            mac.Password = iniFile.ReadString(section, "Password", "");
            mac.RemoteAble = iniFile.ReadInt(section, "RemoteAble", 0) == 1;
            mac.ShowProcess = iniFile.ReadInt(section, "ShowProcess", 0) == 1;
            mac.ShowService = iniFile.ReadInt(section, "ShowService", 0) == 1;
            mac.RedirectDrives = iniFile.ReadInt(section, "RedirectDrives", 0) == 1;
            mac.RedirectPrinters = iniFile.ReadInt(section, "RedirectPrinters", 0) == 1;
            mac.RedirectPorts = iniFile.ReadInt(section, "RedirectPorts", 0) == 1;
            mac.ColorDepth = (Colors)iniFile.ReadInt(section, "ColorDepth", 0);
            return mac;
        }

        public static void Save(RemoteMachine machine, IniFile iniFile)
        {
            string section = string.Format("Remote({0})", machine.DesktopName);
            iniFile.WriteString(section, "DesktopName", machine.DesktopName);
            iniFile.WriteString(section, "Server", machine.Server);
            iniFile.WriteString(section, "UserName", machine.UserName);
            iniFile.WriteString(section, "Domain", machine.Domain);
            iniFile.WriteString(section, "Password", machine.Password);
            iniFile.WriteInt(section, "RemoteAble", machine.RemoteAble ? 1 : 0);
            iniFile.WriteInt(section, "ShowProcess", machine.ShowProcess ? 1 : 0);
            iniFile.WriteInt(section, "ShowService", machine.ShowService ? 1 : 0);
            iniFile.WriteInt(section, "RedirectDrives", machine.RedirectDrives ? 1 : 0);
            iniFile.WriteInt(section, "RedirectPrinters", machine.RedirectPrinters ? 1 : 0);
            iniFile.WriteInt(section, "RedirectPorts", machine.RedirectPorts ? 1 : 0);
            iniFile.WriteInt(section, "ColorDepth", (int)machine.ColorDepth);
        }

        public static List<RemoteMachine> Load(IniFile iniFile)
        {
            string[] infos = iniFile.ReadAllSectionNames();
            if (infos != null)
            {
                List<RemoteMachine> macs = new List<RemoteMachine>();
                foreach (string info in infos)
                {
                    string section = info.Substring(7, info.Length - 8);
                    RemoteMachine mac = RemoteMachine.Load(section, iniFile);
                    macs.Add(mac);
                }
                return macs;
            }
            return null;
        }
    }

    public enum Colors : int
    {
        Color8 = 8,
        Color16 = 16,
        Color24 = 24,
        Color32 = 32
    }
}
