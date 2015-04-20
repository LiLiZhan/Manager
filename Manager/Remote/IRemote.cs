using System;
using System.Collections.Generic;

using System.Text;

namespace Manager
{
    public interface IRemote
    {
        RemoteMachine Machine { get; set; }
        bool Connect();
        void Disconnect();
    }
}
