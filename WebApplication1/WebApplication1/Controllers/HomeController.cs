using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        TODContext _context = new TODContext();
        public ActionResult Index()
        {
            var listofData = _context.Persons.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create( Person model)
        {
            _context.Persons.Add(model);
            _context.SaveChanges();
            ViewBag.message = "Data Inserted successfully";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Persons.Where(x => x.PersonID == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Person model)
        {
            var data = _context.Persons.Where(x=>x.PersonID == model.PersonID).FirstOrDefault();
            if(data != null)
            {
                data.PersonID = model.PersonID;
                data.FirstName = model.FirstName;   
                data.LastName = model.LastName;
                data.Address = model.Address;
                data.City = model.City;
                _context.SaveChanges();
               
            }
            return RedirectToAction("index");
        }
        public ActionResult delete(int id)
        {
            var data = _context.Persons.Where(x => x.PersonID == id).FirstOrDefault();
            _context.Persons.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}