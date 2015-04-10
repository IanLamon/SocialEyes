using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEyes.Domain.Entities;

namespace SocialEyes.Domain.Abstract
{
    public interface ICompanyRepository
    {
        IQueryable<Company> Companies { get; }

        //code to save company to database
        void SaveCompany(Company company);

        //code to delete company from database
        Company DeleteCompany(int companyId);
    }
}
