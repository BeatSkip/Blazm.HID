﻿using Microsoft.JSInterop;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blazm.Hid
{

    [Serializable]
    public partial class HidDevice
    {
        private HidNavigator _webHidNavigator;
        public void InitHidDevice(HidNavigator webhidNavigator)
        {
            _webHidNavigator = webhidNavigator;
        }

        public string Id { get { return $"{VendorId}-{ProductId}"; } }
        public string? ProductName { get; set; }
        public ushort? VendorId { get; set; }
        public ushort? ProductId { get; set; }
        public bool Opened { get; set; }

        public async Task OpenAsync()
        {
            Opened = await _webHidNavigator.OpenDeviceAsync(this);
        }

        public async Task CloseAsync()
        {
            Opened = await _webHidNavigator.CloseDeviceAsync(this);
        }


        public async Task SendReportAsync(byte reportId, byte[] data)
        {
            await _webHidNavigator.SendReportAsync(this, reportId, data);
        }

        public async Task SendFeatureReportAsync(byte reportId, byte[] data)
        {
            await _webHidNavigator.SendFeatureReportAsync(this, reportId, data);
        }

        
        [JSInvokable]
        public void HandleOnInputReport(int reportId,byte[] data)
        {
            ReportReceived?.Invoke(this, new OnInputReportArgs() { ReportId = reportId, Data = data });
        }

        public event EventHandler<OnInputReportArgs> ReportReceived;

        [JSInvokable]
        public void HandleOnConnected()
        {
            Connected?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Connected;


        [JSInvokable]
        public void HandleOnDisconnected()
        {
            Disconnected?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Disconnected;

        //Promise<DataView> receiveFeatureReport([EnforceRange] octet reportId);

    }
}