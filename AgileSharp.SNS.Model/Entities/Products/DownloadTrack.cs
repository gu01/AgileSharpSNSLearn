using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace AgileSharp.SNS.Model.Entities
{
    public class DownloadTrack
    {
        public int TrackId { get; set; }
        public int ProductId { get; set; }
        public int DailyDownloadCount { get; set; }
        public int WeeklyDownloadCount { get; set; }
        public int MonthlyDownloadCount { get; set; }
        public Binary Version { get; set; }
    }
}
