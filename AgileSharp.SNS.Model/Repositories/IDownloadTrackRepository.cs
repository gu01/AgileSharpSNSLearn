using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Model.Repositories
{
    public interface IDownloadTrackRepository
    {
         DownloadTrack GetTrackInfoByProductId(int productId);
         void SaveDailyTrack(int productId, int dailyCount);
         void SaveWeeklyTrack(int productId, int weeklyCount);
         void SaveMonthTrack(int productId, int monthCount);

         List<DownloadTrack> GetDailyTopTracks(int requestSize);
         List<DownloadTrack> GetWeeklyTopTracks(int requestSize);
         List<DownloadTrack> GetMonthTopTracks(int requestSize);
         List<DownloadTrack> GetTotalTopTracks(int requestSize);
    }
}
