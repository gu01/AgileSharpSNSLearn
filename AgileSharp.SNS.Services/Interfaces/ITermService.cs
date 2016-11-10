using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;
using AgileSharp.SNS.Services.ViewModels;
using AgileSharp.SNS.Services.Messages;

namespace AgileSharp.SNS.Services.Interfaces
{
    public interface ITermService
    {
        TermViewModel GetCurrentTerm();
        bool SaveTerm(TermViewModel term);
        bool DeleteTerm(string termName);

        GetTermResponse GetAll();
        string GetTermContentByName(string termName);
    }
}
