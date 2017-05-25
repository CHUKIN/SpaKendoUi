using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Лаба2.Models;

namespace Лаба2.Controllers
{
    public class ApiController : Controller
    {
        public ActionResult Index()
        {
            return Content("Api");
        }

        public ActionResult Chart1()
        {
            List<Chart1> resultList = new List<Chart1>();
      
            Chart1 root = new Chart1("Марки",140);

            root.items.Add(new Chart1("Лифан", 19));
            root.items.Add(new Chart1("Нисан", 10));
            root.items.Add(new Chart1("Пежо", 15));
            root.items.Add(new Chart1("Семёрочка", 4));
            root.items.Add(new Chart1("Джип", 5));

            resultList.Add(root);

            return Json(resultList,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Chart2()
        {
            List<Chart2> resultList = new List<Chart2>();

            resultList.Add(new Chart2(2000,"Лифан"));
            resultList.Add(new Chart2(3000, "Нисан"));
            resultList.Add(new Chart2(4000, "Пежо"));

            return Json(resultList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Chart3()
        {
            List<Chart3> resultList = new List<Chart3>();

            resultList.Add(new Chart3("first",1.2,1996,2000));
            resultList.Add(new Chart3("second", 5, 2005, 2575));
            resultList.Add(new Chart3("third", 2.8, 5000, 5200));

            return Json(resultList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Chart4()
        {
            List<Chart4> resultList = new List<Chart4>();

            resultList.Add(new Chart4("first","2008", 2578));
            resultList.Add(new Chart4("second", "2007",  5000));
            resultList.Add(new Chart4("first", "2006", 3278));
            resultList.Add(new Chart4("second", "200", 5300));



            return Json(resultList, JsonRequestBehavior.AllowGet);
        }
    }
}