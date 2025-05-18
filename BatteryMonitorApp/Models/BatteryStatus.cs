namespace BatteryMonitorApp.Models
{
    public class BatteryStatus
    {
        public int BatteryLevel { get; set; } = 80;
        public bool IsMounted { get; set; } = true;
        public bool IsCharging { get; set; } = true;
        public bool IsConnected { get; set; } = false;
    }
}
