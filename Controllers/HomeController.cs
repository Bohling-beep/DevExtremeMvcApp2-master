
using DevExtremeMvcApp2.Models;

using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace DevExtremeMvcApp2.Controllers {
    public class HomeController : Controller {

        FuhrparkContextEntities context = new FuhrparkContextEntities();
        public ActionResult Index()
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
        public ActionResult GanttPartial()
        {
            return PartialView("~/Views/Home/_GanttPartial.cshtml");
        }
        public ActionResult GanttBatchUpdate(
                            )
        {




            return PartialView("~/Views/Home/_GanttPartial.cshtml");
        }


    }
}