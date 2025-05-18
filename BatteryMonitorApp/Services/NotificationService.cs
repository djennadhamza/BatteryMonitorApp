using System.Windows.Forms;

namespace BatteryMonitorApp.Services
{
    public class NotificationService
    {
        private Form _parentForm;
        private NotifyIcon _notifyIcon = null!;

        public NotificationService(Form parentForm)
        {
            _parentForm = parentForm;
            InitializeNotifyIcon();
        }

        private void InitializeNotifyIcon()
        {
            _notifyIcon = new NotifyIcon
            {
                BalloonTipTitle = "Battery Monitor",
                BalloonTipText = "Battery Monitor is running in the background.",
                Text = "Battery Monitor"
            };
        }

        public void ShowNotification(string title, string message)
        {
            _notifyIcon.ShowBalloonTip(3000, title, message, ToolTipIcon.Info);
        }
    }
}
