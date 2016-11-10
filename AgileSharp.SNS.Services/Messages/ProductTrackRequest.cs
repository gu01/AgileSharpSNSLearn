using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileSharp.SNS.Services.Messages
{
    public class DownloadTrackRequest
    {
        public int RequestCount { get; set; }
        public int ProductId { get; set; }
        public DownloadTrackType TrackType { get; set; }
    }

    public enum DownloadTrackType
    {
        Daily,
        Weekly,
        Month,
        All
    }
}
