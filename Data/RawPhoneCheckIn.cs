using System;
using System.ComponentModel.DataAnnotations;

namespace GDayMateBackend.Data
{
    public class RawPhoneCheckIn
    {
        public string Timestamp { get; set; }
        public RawPhoneCheckInDetail Detail { get; set; }
    }

    public class RawPhoneCheckInDetail
    {
        public string ResponsesString { get; set; }
        public string Destination { get; set; }
    }
}