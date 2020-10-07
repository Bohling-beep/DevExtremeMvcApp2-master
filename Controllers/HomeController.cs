using DevExpress.Web.Mvc;
using DevExtremeMvcApp2.Models;

using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace DevExtremeMvcApp2.Controllers
{
    public class HomeController : Controller
    {

        FuhrparkContextEntities context = new FuhrparkContextEntities();
        public ActionResult Index()
        {


            return View();

        }
        public ActionResult Login()
        {


            return View();

        }

        [HttpPost]
        public ActionResult Login(CBUserModel model)
        {
            FuhrparkContextEntities1 cbe = new FuhrparkContextEntities1();
            var s = cbe.GetCBLoginInfo(model.UserName, model.Password);

            var item = s.FirstOrDefault();
            if (item == "Success")
            {

                return View("Index");
            }
            else if (item == "User Does not Exists")

            {
                ViewBag.NotValidUser = item;

            }
            else
            {
                ViewBag.Failedcount = item;
            }

            return View("Login");
        }
        public ActionResult UserLandingView()
        {
            return View();
        }


        public ActionResult Create()

        {

            return View();
        }
        public ActionResult about()

        {

            return View();
        }
        public ActionResult Modelle()

        {

            return View();
        }


        DevExtremeMvcApp2.Models.FuhrparkContextEntities db = new DevExtremeMvcApp2.Models.FuhrparkContextEntities();

        [ValidateInput(false)]
        public ActionResult CardViewPartial()
        {
            var model = db.view_uebersicht;
            return PartialView("_CardViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CardViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] DevExtremeMvcApp2.Models.view_uebersicht item)
        {
            var model = db.view_uebersicht;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_CardViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CardViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] DevExtremeMvcApp2.Models.view_uebersicht item)
        {
            var model = db.view_uebersicht;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_CardViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CardViewPartialDelete(System.Int32 Id)
        {
            var model = db.view_uebersicht;
            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == Id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_CardViewPartial", model.ToList());
        }

       
        public partial class UICustomizationController : Controller
        {
            public ActionResult Columns()
            {
                return View("Columns");
            }
            public ActionResult ColumnsPartial()
            {
                return PartialView("ColumnsPartial");
            }
        }

        public ActionResult GanttPartial()
        {
            return PartialView("_GanttPartial");
        }
        public ActionResult GanttBatchUpdate(
            MVCxGanttTaskUpdateValues<DevExtremeMvcApp2.Models.Termine, string> taskUpdateValues
            )
        {
            foreach (var item in taskUpdateValues.Update)
            {
                // Task update logic
            }
            foreach (var itemKey in taskUpdateValues.DeleteKeys)
            {
                // Task delete logic
            }
            foreach (var item in taskUpdateValues.Insert)
            {
                // Task insert logic
            }




            return PartialView("_GanttPartial");
        }
    }
}

