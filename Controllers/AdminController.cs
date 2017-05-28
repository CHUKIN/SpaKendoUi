using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Лаба2.Models;

namespace Лаба2.Controllers
{
    public class AdminController : Controller
    {
        LabaContext db = new LabaContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Change(int id)
        {

            return View(db.Cars.Find(id));
        }
    }
}