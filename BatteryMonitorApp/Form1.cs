using System;
using System.Drawing;
using System.Windows.Forms;
using BatteryMonitorApp.CommunicationHandlers;
using BatteryMonitorApp.Services;
using System.IO.Ports;
using InTheHand.Net.Sockets;
using BatteryMonitorApp.Models;
using System.Configuration;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;

namespace BatteryMonitorApp
{
    public partial class Form1 : Form
    {
        private ICommunicationHandler? _communicationHandler;
        private BatteryMonitorService _batteryService;
        //private NotificationService _notificationService;
        private Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private string lowThreshold = "";
        private string highThreshold = "";
        private string coms = "";

        bool _isFirstStart = true;
        int _restartCount = 0;

        bool _isSearchingForDevices;
        public bool IsSearchingForDevices
        {
            get => _isSearchingForDevices;
            set
            {
                _isSearchingForDevices = value;
                btnConnect.Enabled = !_isSearchingForDevices;
            }
        }

        private enum CommunicationType
        {
            SerialPort,
            Bluetooth
        }

        private CommunicationType _currentCommunicationType = CommunicationType.SerialPort;
        public Form1()
        {
            InitializeComponent();

            _batteryService = new BatteryMonitorService();
            //_notificationService = new NotificationService(this);

            InitializeServices();
        }

        private async void InitializeServices()
        {
            // get low & high thresholds from configuration file
            lowThreshold = ConfigurationManager.AppSettings.Get("LOWT") ?? string.Empty;
            highThreshold = ConfigurationManager.AppSettings.Get("HIGHT") ?? string.Empty;

            // get com  to automatically connect if setted 
            coms = ConfigurationManager.AppSettings.Get("COMs") ?? string.Empty;

            // refresh list of ports
            RefreshPorts();

            //set configuration
            cbxLow.SelectedIndex = cbxLow.FindStringExact(lowThreshold.ToString());
            cbxHigh.SelectedIndex = cbxHigh.FindStringExact(highThreshold.ToString());
            cboPorts.SelectedIndex = cboPorts.FindStringExact(coms.ToString());

            //Connect to device if already connected 
            if (cboPorts.SelectedItem != null)
            {
                await connectDevice();
            }

            //set notification
            notifyIcon1.BalloonTipTitle = "Battery Monitor";
            notifyIcon1.BalloonTipText = "Battery Monitor is running in the background.";
            notifyIcon1.Text = "Battery Monitor";

            // Setup battery status update event
            _batteryService.BatteryStatusChanged += OnBatteryStatusChanged;
            _batteryService.StartMonitoring();
            UpdateConnectionStatus(false);
        }

        private void OnBatteryStatusChanged(object? sender, BatteryStatus status)
        {
            // Update UI elements
            UpdateBatteryDisplay(status);
            CheckBatteryThresholds(status);
        }

        private void UpdateBatteryDisplay(BatteryStatus status)
        {
            // Thread-safe UI update
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateBatteryDisplay(status)));
                return;
            }

            lblBatteryPercentage.Text = $"{status.BatteryLevel}%";
            lblMountStatus.Text = status.IsMounted ? "Mounted" : "Not Mounted";
            lblChargingStatus.Text = status.IsCharging ? "Charging" : "Not Charging";
            UpdateConnectionStatus(status.IsConnected);
            if (!status.IsConnected && _isFirstStart && _restartCount == 0)
            {
                _restartCount++;
                DialogResult dialogResult = MessageBox.Show("The Application can not conntect to device,\r \n do you want to restart?", "Conection Error", MessageBoxButtons.YesNo);
                
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        _batteryService.BatteryStatusChanged -= OnBatteryStatusChanged;
                        restartApp();
                        break;
                    case DialogResult.No:
                        _isFirstStart = false;
                        break;
                }
            }
        }

        private void CheckBatteryThresholds(BatteryStatus status)
        {
            if (status.BatteryLevel <= Int32.Parse(lowThreshold))
            {
                //_notificationService.ShowNotification(
                //    "Battery Low",
                //    txtLowMessage.Text.Replace("%LEVEL%", status.BatteryLevel.ToString())
                //);
                notifyIcon1.ShowBalloonTip(3000, "Battery Low", status.BatteryLevel.ToString(), ToolTipIcon.Info);
                if (_communicationHandler != null) _communicationHandler.SendMessage("d");
            }
            else if (status.BatteryLevel >= Int32.Parse(highThreshold))
            {
                //_notificationService.ShowNotification(
                //    "Battery High",
                //    txtHighMessage.Text.Replace("%LEVEL%", status.BatteryLevel.ToString())
                //);
                notifyIcon1.ShowBalloonTip(3000, "Battery High", status.BatteryLevel.ToString(), ToolTipIcon.Info);
                if (_communicationHandler != null) _communicationHandler.SendMessage("c");
            }
        }



        private void RefreshPorts()
        {
            cboPorts.Items.Clear();

            if (_currentCommunicationType == CommunicationType.SerialPort)
            {
                // Populate Serial Ports
                string[] ports = SerialPort.GetPortNames();
                cboPorts.Items.AddRange(ports);
            }
            else
            {
                // Discover Bluetooth Devices
                try
                {
                    using (var bluetoothClient = new BluetoothClient())
                    {
                        BluetoothDeviceInfo[] devices = (BluetoothDeviceInfo[])bluetoothClient.DiscoverDevices();
                        foreach (var device in devices)
                        {
                            cboPorts.Items.Add($"{device.DeviceName} [{device.DeviceAddress}]");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bluetooth Discovery Error: {ex.Message}");
                }
            }
        }



        private void UpdateConnectionStatus(bool connected)
        {
            lblConnectionStatus.Text = connected ? "Connected" : "Disconnected";
            lblConnectionStatus.ForeColor = connected ? Color.Green : Color.Red;
        }

        private async void btnConnect_Click_1(object sender, EventArgs e)
        {
            IsSearchingForDevices = true;

            await connectDevice();

            IsSearchingForDevices = false;
        }

        private async Task connectDevice() 
        {
            if (cboPorts.SelectedItem == null)
            {
                MessageBox.Show("Please select a port/device.");
                return;
            }

            string selectedPort = cboPorts.SelectedItem?.ToString() ?? string.Empty;
            //set com port to config file
            if (selectedPort != coms)
            {
                configuration.AppSettings.Settings["COMs"].Value = selectedPort;
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            // Disconnect existing connection if any
            await Task.Run(() => _communicationHandler?.Disconnect());

            // Create appropriate communication handler
            _communicationHandler = _currentCommunicationType == CommunicationType.SerialPort
                ? new SerialPortHandler(selectedPort)
                : new BluetoothHandler(selectedPort);

            // Connect and start monitoring
            if (await Task.Run(() => _communicationHandler.Connect()))
            {
                _batteryService.StartMonitoring(_communicationHandler);
                UpdateConnectionStatus(true);
            }
            else
            {
                MessageBox.Show("Connection failed.");
            }
        }

        private void btnRefreshPorts_Click(object sender, EventArgs e)
        {
            RefreshPorts();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
                this.Hide();
                e.Cancel = true;
            }
        }

        private void btnSetLow_Click(object sender, EventArgs e)
        {

            string? selectedLow = cbxLow.SelectedItem?.ToString();

            if (selectedLow != null && highThreshold != null && Int32.Parse(selectedLow) < Int32.Parse(highThreshold))
            {
                configuration.AppSettings.Settings["LOWT"].Value = selectedLow;
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                lowThreshold = selectedLow;
                toolStripStatusLabel1.Text = "LOW threshold : " + lowThreshold;
            }
            else
            {
                cbxLow.SelectedIndex = cbxLow.FindStringExact(lowThreshold);
                MessageBox.Show($"Error setting LOW threshold, please note that the low threshold must be less than high threshold");
            }
        }

        private void btnSetHigh_Click(object sender, EventArgs e)
        {
            string? selectedHigh = cbxHigh.SelectedItem?.ToString();

            if (selectedHigh != null && lowThreshold != null && Int32.Parse(selectedHigh) > Int32.Parse(lowThreshold))
            {
                configuration.AppSettings.Settings["HIGHT"].Value = selectedHigh;
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                highThreshold = selectedHigh;
                toolStripStatusLabel1.Text = "High threshold : " + highThreshold;
            }
            else
            {
                cbxLow.SelectedIndex = cbxLow.FindStringExact(highThreshold);
                MessageBox.Show($"Error setting High threshold, please note that the high threshold must be more than low threshold");
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _batteryService.StopMonitoring();
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var primaryScreen = Screen.PrimaryScreen;
            if (primaryScreen != null)
            {
                int screenWidth = primaryScreen.Bounds.Size.Width;
                int screenHeight = primaryScreen.Bounds.Size.Height;
                int formWidth = this.Width;
                int formHeight = this.Height;

                this.Location = new Point(screenWidth - formWidth, screenHeight - formHeight -50);
            }
            else
            {
                MessageBox.Show("Primary screen not detected.");
            }
            SystemEvents.PowerModeChanged += OnPowerChange;
        }

        private void OnPowerChange(object s, PowerModeChangedEventArgs e)
        {
            //string path = Directory.GetCurrentDirectory();
            int r = 0;
            switch (e.Mode)
            {
                case PowerModes.Resume:
                    r += 1;
                    break;
                case PowerModes.Suspend:
                    r += 1;
                    break;
            }
            if (r != 0)
            {
                r= 0;
                restartApp();
            }
        }

        private void restartApp()
        {
            string path = Directory.GetCurrentDirectory();
            //MessageBox.Show("Please Restart the Application!");
            SystemEvents.PowerModeChanged -= OnPowerChange;
            Application.Exit();
            Process.Start("BatteryMonitorApp.exe", path + "BatteryMonitorApp.exe");
        }
    }
}
