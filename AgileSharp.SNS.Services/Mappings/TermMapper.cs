using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Services.ViewModels;
using AgileSharp.SNS.Model.Entities;
using AutoMapper;

namespace AgileSharp.SNS.Services.Mappings
{
    public static class TermMapper
    {
        public static TermViewModel ToViewModel(this Term term)
        {
            return Mapper.Map<Term, TermViewModel>(term);
        }

        public static Term ToModel(this TermViewModel term)
        {
            return Mapper.Map<TermViewModel, Term>(term);
        }

        public static List<TermViewModel> ToViewModels(this List<Term> terms)
        {
            List<TermViewModel> result = null;
            if (terms != null && terms.Count > 0)
            {
                result = new List<TermViewModel>();
                foreach (var term in terms)
                {
                    result.Add(term.ToViewModel());
                }
            }
            return result;
        }
    
    }
}
