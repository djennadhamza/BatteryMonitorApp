using System;
using System.Timers;
using BatteryMonitorApp.CommunicationHandlers;
using BatteryMonitorApp.Models;

namespace BatteryMonitorApp.Services
{
    public class BatteryMonitorService
    {
        private System.Timers.Timer _monitorTimer;
        private ICommunicationHandler _communicationHandler;
        private BatteryStatus _currentStatus;
        private PowerStatus ps = SystemInformation.PowerStatus;

        public event EventHandler<BatteryStatus>? BatteryStatusChanged;

        public BatteryMonitorService()
        {
            _currentStatus = new BatteryStatus();
            _monitorTimer = new System.Timers.Timer(1000); // 1 second interval
            _monitorTimer.Elapsed += MonitorBatteryStatus;
            _communicationHandler = null!; // Initialize with null-forgiving operator
        }

        public void StartMonitoring(ICommunicationHandler communicationHandler)
        {
            _communicationHandler = communicationHandler ?? throw new ArgumentNullException(nameof(communicationHandler));
            _communicationHandler.DataReceived += ProcessReceivedData;
            _monitorTimer.Start();
        }

        public void StartMonitoring()
        {
            _monitorTimer.Start();
        }

        private void ProcessReceivedData(object? sender, string data)
        {
            // Parse incoming battery data
            // Example parsing logic (customize based on your device protocol)
            if (data.StartsWith("BATTERY:"))
            {
                var parts = data.Split(':');
                if (parts.Length >= 5)
                {
                    _currentStatus.BatteryLevel = int.Parse(parts[1]);
                    _currentStatus.IsMounted = parts[2].ToLower() == "mounted";
                    _currentStatus.IsCharging = parts[3].ToLower() == "charging";
                    _currentStatus.IsConnected = parts[4].ToLower() == "connected";

                    BatteryStatusChanged?.Invoke(this, _currentStatus);
                }
            }
        }

        private void MonitorBatteryStatus(object? sender, ElapsedEventArgs e)
        {
            bool isConnected = false;
            if (_communicationHandler != null) 
            {
                try { _communicationHandler.SendMessage(""); isConnected = _communicationHandler.IsConnected(); } catch { isConnected = false; }
            }
                // Simulated battery status for testing
                // Replace with actual monitoring logic
            int batteryLevel = (int)(ps.BatteryLifePercent * 100);
            string chargStatus = ps.BatteryChargeStatus.ToString().ToLower();
            if (chargStatus.Contains("char")) _currentStatus.IsCharging = true; else _currentStatus.IsCharging= false;

                _currentStatus.BatteryLevel = batteryLevel;
            _currentStatus.IsConnected = isConnected;
            BatteryStatusChanged?.Invoke(this, _currentStatus);
        }

        public void StopMonitoring()
        {
            _monitorTimer.Stop();
        }
    }
}
