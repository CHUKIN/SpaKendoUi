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
        LabaContext db = new LabaContext();

        public ActionResult GetCar(int id)
        {
            db.Cars.Find(id).Watch++;
            db.SaveChanges();
            return Json(db.Cars.Find(id), JsonRequestBehavior.AllowGet);
        }

       

        public ActionResult GetMarks()
        {
            List<string> listMarks = new List<string>();
            listMarks.Add("Лифан");
            listMarks.Add("Нисан");
            return Json(listMarks, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetModels()
        {
            List<object> listMarks = new List<object>();

            Dictionary<string, List<string>> listModels = new Dictionary<string, List<string>>();            
            listModels.Add("Лифан", new List<string> { "Бриз", "LLL" });
            listModels.Add("Нисан", new List<string> { "X1", "X2" });
            return Json(listModels, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Search(Car car)
        {
          if (car.Mark==null)
            {
                car.Mark = "";
            }
          if(car.Model==null)
            {
                car.Model = "";
            }
          if(car.Transmission=="on")
            {
                car.Transmission = "Автоматика";
            }
            if (car.Transmission == "off")
            {
                car.Transmission = "Ручное";
            }
            if(car.Cost==0)
            {
                car.Cost = 999999999;
            }
            if(car.Mileage==0)
            {
                car.Mileage = 9999999999;
            }
            if(car.Type==null)
            {
                car.Type = "";
            }
            return Json(db.Cars.Where(i => i.Cost <= car.Cost && i.Mark.Contains(car.Mark) && i.Mileage <= car.Mileage && i.Model.Contains(car.Model) && i.Type.Contains(car.Type)&&i.Year>=car.Year), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Change(Car car, HttpPostedFileBase File)
        {
            var oldCar = db.Cars.Find(car.Id);
            oldCar.Cost = car.Cost;
            oldCar.Amount = car.Amount;
            oldCar.Mark = car.Mark;
            oldCar.Mileage = car.Mileage;
            oldCar.Model = car.Model;
            oldCar.State = car.State;
            oldCar.Type = car.Type;
            oldCar.Watch = car.Watch;
            oldCar.Year = car.Year;
          
            File.SaveAs(Server.MapPath("~/Files/" + oldCar.Id + File.FileName));
            oldCar.PhotoUrl = "../Files/" + oldCar.Id + File.FileName;
            if (oldCar.Transmission == "on")
            {
                oldCar.Transmission = "Автоматика";
            }
            else
            {
                oldCar.Transmission = "Ручное";
            }
            db.SaveChanges();
            return Redirect("/Admin");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            db.Cars.Remove(db.Cars.Find(id));
            db.SaveChanges();
            return Redirect("/Admin");
        }

        [HttpPost]
        public ActionResult Create(Car car, HttpPostedFileBase File)
        {
            car.Watch = 0;
            db.Cars.Add(car);
            
            db.SaveChanges();
            File.SaveAs(Server.MapPath("~/Files/" + car.Id + File.FileName));
            car.PhotoUrl = "../Files/" + car.Id + File.FileName;
            if (car.Transmission == "on")
            {
                car.Transmission = "Автоматика";
            }
            else
            {
                car.Transmission = "Ручное";
            }
            db.SaveChanges();
            return Redirect("/Admin");
        }


        public ActionResult GetMostPopularCars()
        {

            return Json(db.Cars.OrderByDescending(i=>i.Watch).Take(25), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCars()
        {
            return Json(db.Cars, JsonRequestBehavior.AllowGet);
        }

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