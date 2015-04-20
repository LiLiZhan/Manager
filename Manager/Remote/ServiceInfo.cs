using System;
using System.Collections.Generic;
using System.Data;

using System.Management;
using System.Text;

namespace Manager
{
    public class ServiceInfo
    {
        public ServiceInfo()
            : this(null)
        { }
        public ServiceInfo(ManagementObject mo)
        {
            if (mo != null)
            {
                this.Name = mo["Name"].ToString();
                this.ProcessId = Convert.ToUInt32(mo["ProcessId"]);
                this.Description = mo["Description"] != null ? mo["Description"].ToString() : null;
                this.DisplayName = mo["DisplayName"] != null ? mo["DisplayName"].ToString() : null;
                this.PathName = mo["PathName"] != null ? mo["PathName"].ToString() : null;
                this.Status = mo["Status"] != null ? mo["Status"].ToString() : null;
                this.State = mo["State"] != null ? mo["State"].ToString() : null;
                this.ServiceType = mo["ServiceType"] != null ? mo["ServiceType"].ToString() : null;
                this.Started = Convert.ToBoolean(mo["Started"]);
                this.AcceptPause = Convert.ToBoolean(mo["AcceptPause"]);
                this.AcceptStop = Convert.ToBoolean(mo["AcceptStop"]);
            }
        }

        public string Name { get; set; }
        public UInt32 ProcessId { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string PathName { get; set; }
        public bool Started { get; set; }
        public string Status { get; set; }
        public string State { get; set; }
        public string ServiceType { get; set; }
        public bool AcceptPause { get; set; }
        public bool AcceptStop { get; set; }

        public override string ToString()
        {
            return string.Format("{0:D6}:{1}", this.ProcessId, this.Name);
        }

        public static DataTable ConvertTo(ServiceInfo[] services)
        {
            DataTable table = new DataTable();
            table.Columns.Add("PID", typeof(UInt32));
            table.Columns.Add("名称", typeof(string));
            table.Columns.Add("状态", typeof(string));
            table.Columns.Add("描述", typeof(string));
            if (services != null)
            {
                foreach (ServiceInfo service in services)
                {
                    table.Rows.Add(new object[] { service.ProcessId, service.Name, service.State, service.Description });
                }
            }
            return table;
        }
    }
}
