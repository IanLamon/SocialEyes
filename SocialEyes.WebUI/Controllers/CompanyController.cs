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

        //Update functionality
        public ActionResult Edit(int id)
        {
            Company company = objContext.Companies.Where(
                x => x.CompanyId == id).SingleOrDefault();
            return View(company);
        }
        [HttpPost]
        public ActionResult Edit(Company model)
        {
            if (ModelState.IsValid)
            {
                objContext.SaveCompany(model);
                return RedirectToAction("Company", "Company", new { id = model.CompanyId });
            }
            else
            {
                //problem processing request
                return View(model);
            }
        }

        //delete functionality
        public ActionResult Delete(int id)
        {
            Company company = objContext.DeleteCompany(id);
            return View(company);
        }

        //display details functionality
        public ViewResult Details(int id)
        {
            Company company = objContext.Companies.Where(x => x.CompanyId == id).SingleOrDefault();
            return View(company);
        }

        //method to display company details with all events
        public ViewResult Company(int id)
        {
            Company company = objContext.Companies.Where(x => x.CompanyId == id).SingleOrDefault();
            return View(company);
        }
    }
}