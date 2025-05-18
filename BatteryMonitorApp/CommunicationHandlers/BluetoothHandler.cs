using System;
using InTheHand.Net.Sockets;
using InTheHand.Net;
using BatteryMonitorApp.CommunicationHandlers;
using InTheHand.Net.Bluetooth;

namespace BatteryMonitorApp.CommunicationHandlers
{
    public class BluetoothHandler : ICommunicationHandler
    {
        private BluetoothClient _bluetoothClient = null!;
        private string _deviceAddress;

        public event EventHandler<string> DataReceived = null!;

        public BluetoothHandler(string deviceInfo)
        {
            // Parse device address from selected item
            _deviceAddress = ExtractBluetoothAddress(deviceInfo);
        }

        private string ExtractBluetoothAddress(string deviceInfo)
        {
            // Extract Bluetooth address from device info string
            int startIndex = deviceInfo.IndexOf('[') + 1;
            int endIndex = deviceInfo.IndexOf(']');
            return deviceInfo.Substring(startIndex, endIndex - startIndex);
        }

        public bool Connect()
        {
            try
            {
                BluetoothAddress address = BluetoothAddress.Parse(_deviceAddress);
                _bluetoothClient = new BluetoothClient();
                _bluetoothClient.Connect(new BluetoothEndPoint(address, BluetoothService.SerialPort));
                return true;
            }
            catch (Exception ex)
            {
                OnError($"Bluetooth Connection Error: {ex.Message}");
                return false;
            }
        }

        public void Disconnect()
        {
            _bluetoothClient?.Close();
        }

        public bool IsConnected() 
        {
            if (_bluetoothClient != null) return true; else return false;
        }

        public void SendMessage(string message)
        {
            try
            {
                var stream = _bluetoothClient.GetStream();
                byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                OnError($"Bluetooth Send Error: {ex.Message}");
            }
        }

        private void OnError(string errorMessage)
        {
            DataReceived?.Invoke(this, errorMessage);
        }
    }
}