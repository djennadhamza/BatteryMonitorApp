using System;
using System.IO.Ports;
using BatteryMonitorApp.CommunicationHandlers;

namespace BatteryMonitorApp.CommunicationHandlers
{
    public class SerialPortHandler : ICommunicationHandler
    {
        private SerialPort _serialPort = null!;
        private string _portName;

        public event EventHandler<string>? DataReceived;

        public SerialPortHandler(string portName)
        {
            _portName = portName;
        }

        public bool Connect()
        {
            try
            {
                _serialPort = new SerialPort(_portName, 115200);
                _serialPort.Open();
                _serialPort.DataReceived += OnSerialDataReceived;
                return true;
            }
            catch (Exception ex)
            {
                OnError($"Serial Connection Error: {ex.Message}");
                return false;
            }
        }

        public void Disconnect()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
                _serialPort.Dispose();
            }
        }

        public bool IsConnected() 
        {
            if (_serialPort != null && _serialPort.IsOpen) return true; else return false;
        }

        public void SendMessage(string message)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.WriteLine(message);
            }
        }

        private void OnSerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = _serialPort.ReadLine();
                DataReceived?.Invoke(this, data);
            }
            catch (System.IO.IOException error)
            {
                return;
            }
            catch (System.InvalidOperationException error)
            {
                return;
            }
        }

        private void OnError(string errorMessage)
        {
            // Log or handle errors
            DataReceived?.Invoke(this, errorMessage);
        }
    }
}