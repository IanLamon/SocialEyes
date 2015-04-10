using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialEyes.Domain.Abstract;
using SocialEyes.Domain.Entities;

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

        //create method
        public ActionResult Create()
        {
            return View(new Company());
        }

        [HttpPost]
        public ActionResult Create(Company company)
        {
            objContext.SaveCompany(company);
            return RedirectToAction("Index");
        }
    }
}