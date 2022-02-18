using System;

namespace Blazm.Hid
{
    [Serializable]
    public class HidDeviceFilter : IHidFilter
    {
        public int? vendorId { get; set; } = null;
        public int? productId { get; set; } = null;
        public string? classCode { get; set; } = null;
        public string? subclassCode { get; set; } = null;
        public string? protocolCode { get; set; } = null;
        public string? serialNumber { get; set; } = null;

        public HidDeviceFilter() { }

        public HidDeviceFilter(int VID, int PID)
		{
            vendorId = VID;
            productId = PID;
        }

        public HidDeviceFilter(string VID, string PID)
        {
            vendorId = Convert.ToInt32(VID, 16); 
            productId = Convert.ToInt32(PID, 16);
        }



    }
}
