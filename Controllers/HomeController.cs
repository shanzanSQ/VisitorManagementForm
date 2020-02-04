using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VisitorManagementForm.DAL;
using VisitorManagementForm.Models;

namespace VisitorManagementForm.Controllers
{
    public class HomeController : Controller
    {
        HomeDAL homeDAL = new HomeDAL();
        public ActionResult Visitor()
        {
            return View();
        }

        public ActionResult VisitorManagementForm()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult LoadBusinessUnit()
        {
            return Json(homeDAL.GetBusinessUnit(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadLocation()
        {
            return Json(homeDAL.GetLocation(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveVisitorForApprove(VisitorRequestModel visitor)
        {

            return Json(homeDAL.SavevisitoToDatabase(visitor),JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpPost]
        public ActionResult GetRequestVisitor()
        {
            List<VisitorRequestModel> visitorInformation = new List<VisitorRequestModel>();
            visitorInformation = homeDAL.GetAllRequestInformation();
            return PartialView("_allRequestPartialView", visitorInformation);
        }

        [HttpPost]
        public ActionResult IndividualRequestShow(int PrimaryKey)
        {
            return PartialView("_modalVisitorRequest", homeDAL.IndividualRequestShow(PrimaryKey));
        }
    }
}