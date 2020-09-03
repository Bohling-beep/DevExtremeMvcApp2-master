using DevExpress.DataAccess.Wizard.Model;
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

            var data = context.Database.SqlQuery<GetIndexUebersicht_Result>("GetIndexUebersicht").ToList();
            return View();

        }

        
        public ActionResult Create()

        {
            SqlParameter[] param = new SqlParameter[]
            {
                
                new SqlParameter("@Kennzeichen",20),
                new SqlParameter("@Marke",20),
                new SqlParameter("@Modell",20),
                new SqlParameter("@Fahrzeughalter",20),
                new SqlParameter("@Niederlassung",20),
                new SqlParameter("@Kraftstoff",20),
                new SqlParameter("@Neuwagen",20),
                new SqlParameter("@Status",20),
           

            };
            var insert = context.Database.SqlQuery<GetIndexUebersicht_Result>("InsertIntoIndexUebersicht");
            return View();
        }



    }
}