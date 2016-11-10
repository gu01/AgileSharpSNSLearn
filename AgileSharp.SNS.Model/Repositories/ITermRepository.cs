using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Model.Repositories
{
    public interface ITermRepository
    {
        Term GetCurrentTerm();
        bool Save(Term term);
        bool Delete(string termName);

        List<Term> GetAll();
        string GetTermContentByName(string termName);
    }
}
