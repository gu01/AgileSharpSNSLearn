using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileSharp.SNS.Services.ViewModels
{
    public class DownloadTrackViewModel
    {
        public int TrackId { get; set; }
        public int ProductId { get; set; }
        public int DailyDownloadCount { get; set; }
        public int WeeklyDownloadCount { get; set; }
        public int MonthlyDownloadCount { get; set; }      
    }
}
