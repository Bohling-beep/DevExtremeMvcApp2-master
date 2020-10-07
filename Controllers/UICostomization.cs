using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevExtremeMvcApp2.Controllers
{
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
}