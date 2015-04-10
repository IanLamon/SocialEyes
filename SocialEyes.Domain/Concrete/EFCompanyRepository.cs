using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEyes.Domain.Abstract;
using SocialEyes.Domain.Entities;

namespace SocialEyes.Domain.Concrete
{
    public class EFCompanyRepository : ICompanyRepository
    {
        private EFdbContext context = new EFdbContext();

        public IQueryable<Company> Companies
        {
            get { return context.Companies; }
        }

        //method to create/update a company to database
        public void SaveCompany(Company company)
        {
            if (company.CompanyId == 0)
            {
                context.Companies.Add(company);
            }
            else
            {
                Company com = context.Companies.Find(company.CompanyId);
                if (com != null)
                {
                    com.CompanyId = company.CompanyId;
                    com.CompanyName = company.CompanyName;
                    com.Address1 = company.Address1;
                    com.Address2 = company.Address2;
                    com.Address3 = company.Address3;
                    com.Address4 = company.Address4;
                    com.Email = company.Email;
                    com.Telephone = company.Telephone;
                    com.LogoURL = company.LogoURL;
                }
            }
            context.SaveChanges();
        } //ends create/update company method
    }
}
