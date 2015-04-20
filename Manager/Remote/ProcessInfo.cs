using System;
using System.Collections.Generic;
using System.Data;
using System.Management;
using System.Text;

namespace Manager
{
    public class ProcessInfo
    {
        public ProcessInfo()
            : this(null)
        { }

        public ProcessInfo(ManagementObject mo)
        {
            if (mo != null)
            {
                //ManagementBaseObject _mbo = mo.GetMethodParameters("GetOwner");
                //ManagementBaseObject mbo = mo.InvokeMethod("GetOwner", _mbo, null);
                //this.Owner = mbo["User"] != null ? mbo["User"].ToString() : null;

                this.Name = mo["Name"].ToString();
                this.ProcessId = Convert.ToUInt32(mo["ProcessId"]);
                this.SessionId = Convert.ToUInt32(mo["SessionId"]);
                this.ThreadCount = Convert.ToUInt32(mo["ThreadCount"]);
                this.Status = mo["Status"] != null ? mo["Status"].ToString() : null;
                this.OSCreationClassName = mo["OSCreationClassName"] != null ? mo["OSCreationClassName"].ToString() : null;
                this.CommandLine = mo["CommandLine"] != null ? mo["CommandLine"].ToString() : null;
                this.Caption = mo["Caption"] != null ? mo["Caption"].ToString() : null;
                this.Description = mo["Description"] != null ? mo["Description"].ToString() : null;
                this.ExecutablePath = mo["ExecutablePath"] != null ? mo["ExecutablePath"].ToString() : null;
                this.VirtualSize = Convert.ToUInt64(mo["VirtualSize"]);
                this.WorkingSetSize = Convert.ToUInt64(mo["WorkingSetSize"]);
            }
        }
        //public string Owner { get; set; }
        public UInt32 ThreadCount { get; set; }
        public UInt32 SessionId { get; set; }
        public UInt32 ProcessId { get; set; }
        public string Name { get; set; }
        public string OSCreationClassName { get; set; }
        public string Status { get; set; }
        public string CommandLine { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string ExecutablePath { get; set; }
        public UInt64 VirtualSize { get; set; }
        public UInt64 WorkingSetSize { get; set; }

        public override string ToString()
        {
            return string.Format("{0:D6}:{1}", this.ProcessId, this.Name);
        }

        public static DataTable ConvertTo(ProcessInfo[] processes)
        {
            DataTable table = new DataTable();
            table.Columns.Add("PID", typeof(UInt32));
            table.Columns.Add("映像名称", typeof(string));
            //table.Columns.Add("用户名", typeof(string));
            table.Columns.Add("会话ID", typeof(UInt32));
            table.Columns.Add("工作设置(内存)", typeof(UInt64));
            table.Columns.Add("线程数", typeof(UInt32));
            table.Columns.Add("描述", typeof(string));
            table.Columns.Add("命令行", typeof(string));
            if (processes != null)
            {
                foreach (ProcessInfo process in processes)
                {
                    table.Rows.Add(new object[] { process.ProcessId, process.Name,/*process.Owner,*/ process.SessionId, process.WorkingSetSize, process.ThreadCount, process.Description, process.CommandLine });
                }
            }
            return table;
        }
    }
}
