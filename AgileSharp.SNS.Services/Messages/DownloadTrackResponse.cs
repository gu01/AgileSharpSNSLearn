using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Services.ViewModels;

namespace AgileSharp.SNS.Services.Messages
{
    public class DownloadTrackResponse:ResponseBase
    {
        public List<DownloadTrackViewModel> DownloadTracks { get; set; }
    }
}
