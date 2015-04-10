using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialEyes.Domain.Abstract;

namespace SocialEyes.WebUI.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyRepository objContext;

        public CompanyController (ICompanyRepository companyRepository)
        {
            this.objContext = companyRepository;
        }
        
        // GET: Company
        public ActionResult Index()
        {
            return View(objContext.Companies);
        }
    }
}