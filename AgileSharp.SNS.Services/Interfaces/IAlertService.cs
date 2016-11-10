using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Services.Interfaces
{
    public interface IAlertService
    {
        void AddAccountCreateAlert();
        void AddAccountModifiedAlert();
        void AddProfileCreateAlert();
        void AddProfileModifiedAlert();
        void AddNewAvatarAlert();
        List<Alert> GetAlertsByAccountId(int accountId);
        Alert GetLastestAlert(int accountId);
    }
}
