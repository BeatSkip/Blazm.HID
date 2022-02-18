using System;
using System.Threading.Tasks;

namespace Blazm.Hid
{
	public interface IHidDevice
	{
		public bool Opened { get; }
		Task OpenAsync();
		Task CloseAsync();
		Task SendReportAsync(byte reportId, byte[] data);

		event EventHandler<OnInputReportArgs> ReportReceived;

		event EventHandler Connected;

		event EventHandler Disconnected;
	}

}