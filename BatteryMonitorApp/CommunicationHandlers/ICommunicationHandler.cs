using System;

namespace BatteryMonitorApp.CommunicationHandlers
{
    public interface ICommunicationHandler
    {
        bool Connect();
        void Disconnect();
        void SendMessage(string message);
        bool IsConnected();
        event EventHandler<string> DataReceived;
    }
}