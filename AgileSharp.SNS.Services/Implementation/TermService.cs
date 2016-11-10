using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Services.Interfaces;
using AgileSharp.SNS.Model.Entities;
using AgileSharp.SNS.Model.Repositories;
using StructureMap;
using AgileSharp.SNS.Infrastructure;
using AgileSharp.SNS.Services.ViewModels;
using AgileSharp.SNS.Services.Messages;
using AgileSharp.SNS.Services.Mappings;

namespace AgileSharp.SNS.Services.Implementation
{
    public class TermService : ITermService
    {
        private ITermRepository termRepository;

        public TermService()
        {
            termRepository = ObjectFactory.GetInstance<ITermRepository>();
        }

        public TermViewModel GetCurrentTerm()
        {
            TermViewModel result = null;
            var term = termRepository.GetCurrentTerm();
            if (term != null)
            {
                result = term.ToViewModel();
            }

            return result;
        }

        public bool SaveTerm(TermViewModel termViewModel)
        {
            bool result = false;
            if (termViewModel != null)
            {
                var term = termViewModel.ToModel();
                result = termRepository.Save(term);
            }
            return result;
        }

        public bool DeleteTerm(string termName)
        {
            bool result = false;
            if (termName.IsNotEmpty())
            {
                result = termRepository.Delete(termName);
            }
            return result;
        }

        public GetTermResponse GetAll()
        {
            GetTermResponse result = new GetTermResponse();
            var terms = termRepository.GetAll();
            if (terms != null && terms.Count > 0)
            {
                result.Terms = terms.ToViewModels();
                result.IsSuccess = true;
            }
            return result;
        }

        public string GetTermContentByName(string termName)
        {
            string result = string.Empty;
            if (termName.IsNotEmpty())
            {
                result = termRepository.GetTermContentByName(termName);
            }
            return result;
        }
    }
}
