using System;

namespace Blazm.Hid
{
    public interface IHidFilter
	{
        public int? vendorId { get;  }
        public int? productId { get; }
        public string? classCode { get; }
        public string? subclassCode { get;  }
        public string? protocolCode { get; }
        public string? serialNumber { get;  }
    }

   
}
