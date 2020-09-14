using DevExpress.Web.Mvc;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using DevExtremeMvcApp2.Models;


namespace DevExtremeMvcApp2.Controllers
{
    [Route("api/uebersicht_datenneu/{action}", Name = "uebersicht_datenneuApi")]
    public class uebersicht_datenneuController : ApiController
    {
        private FuhrparkContextEntities _context = new FuhrparkContextEntities();

        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions)
        {
            var view_uebersicht = _context.view_uebersicht.Select(i => new
            {
                i.Id,
                i.Kennzeichen,
                i.Marke,
                i.Modell,
                i.Fahrzeughalter,
                i.Niederlassung,
                i.Kraftstoff,
                i.Neuwagen,
                i.Status,
                i.EinkaufId,
                i.ListenpreisB,
                i.EKPreisB,
                i.Erstzulassung,
                i.KMDatum,
                i.Kaufdatum,
                i.KMStand,
               
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Request.CreateResponse(await DataSourceLoader.LoadAsync(view_uebersicht, loadOptions));
        }


        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form)
        {


            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            var model = new view_uebersicht();
            var result = _context.view_uebersicht.Add(model);
            var jk = "kek";
            string KENNZEICHEN = nameof(view_uebersicht.Kennzeichen);
            string MARKE = nameof(view_uebersicht.Marke);
            string MODELL = nameof(view_uebersicht.Modell);
            string FAHRZEUGHALTER = nameof(view_uebersicht.Fahrzeughalter);
            string NIEDERLASSUNG = nameof(view_uebersicht.Niederlassung);
            string KRAFTSTOFF = nameof(view_uebersicht.Kraftstoff);
            string NEUWAGEN = nameof(view_uebersicht.Neuwagen);
            string STATUS = nameof(view_uebersicht.Status);
            string LISTENPREIS_B = nameof(view_uebersicht.ListenpreisB);
            string EKPREIS_B = nameof(view_uebersicht.EKPreisB);
            string ERSTZULASSUNG = nameof(view_uebersicht.Erstzulassung);
            string KMDATUM = nameof(view_uebersicht.KMDatum);
            string KAUFDATUM = nameof(view_uebersicht.Kaufdatum);
            string KMSTAND = nameof(view_uebersicht.KMStand);
           




            _context.InsertIndexUebersicht(
                model.Kennzeichen = Convert.ToString(values[KENNZEICHEN]),
                model.Marke = Convert.ToString(values[MARKE]),
                model.Modell = Convert.ToString(values[MODELL]),
                model.Fahrzeughalter = Convert.ToString(values[FAHRZEUGHALTER]),
                model.Niederlassung = Convert.ToString(values[NIEDERLASSUNG]),
                model.Kraftstoff = Convert.ToString(values[KRAFTSTOFF]),
                model.Neuwagen = values[NEUWAGEN] != null ? Convert.ToBoolean(values[NEUWAGEN]) : (bool?)null,
                model.Status = Convert.ToString(values[STATUS]),
                model.Erstzulassung = Convert.ToString(values[ERSTZULASSUNG]),
                model.KMDatum = Convert.ToString(values[KMDATUM]),
                model.Kaufdatum = Convert.ToString(values[KAUFDATUM]),
                model.KMStand = Convert.ToString(values[KMSTAND]),
                model.ListenpreisB = Convert.ToString(values[LISTENPREIS_B]),
                model.EKPreisB = Convert.ToString(values[EKPREIS_B])

                );



            //   PopulateModel(model, values);           



            await _context.SaveChangesAsync();



            return Request.CreateResponse();
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));
            var model = await _context.uebersicht_daten.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "Object not found");

            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task Delete(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));
            var model = await _context.uebersicht_daten.FirstOrDefaultAsync(item => item.Id == key);

            _context.uebersicht_daten.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(uebersicht_daten model, IDictionary values)
        {
            string ID = nameof(uebersicht_daten.Id);
            string KENNZEICHEN = nameof(uebersicht_daten.Kennzeichen);
            string MARKE = nameof(uebersicht_daten.Marke);
            string MODELL = nameof(uebersicht_daten.Modell);
            string FAHRZEUGHALTER = nameof(uebersicht_daten.Fahrzeughalter);
            string NIEDERLASSUNG = nameof(uebersicht_daten.Niederlassung);
            string KRAFTSTOFF = nameof(uebersicht_daten.Kraftstoff);
            string NEUWAGEN = nameof(uebersicht_daten.Neuwagen);
            string STATUS = nameof(uebersicht_daten.Status);
            

            if (values.Contains(ID))
            {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if (values.Contains(KENNZEICHEN))
            {
                model.Kennzeichen = Convert.ToString(values[KENNZEICHEN]);
            }

            if (values.Contains(MARKE))
            {
                model.Marke = Convert.ToString(values[MARKE]);
            }

            if (values.Contains(MODELL))
            {
                model.Modell = Convert.ToString(values[MODELL]);
            }

            if (values.Contains(FAHRZEUGHALTER))
            {
                model.Fahrzeughalter = Convert.ToString(values[FAHRZEUGHALTER]);
            }

            if (values.Contains(NIEDERLASSUNG))
            {
                model.Niederlassung = Convert.ToString(values[NIEDERLASSUNG]);
            }

            if (values.Contains(KRAFTSTOFF))
            {
                model.Kraftstoff = Convert.ToString(values[KRAFTSTOFF]);
            }

            if (values.Contains(NEUWAGEN))
            {
                model.Neuwagen = values[NEUWAGEN] != null ? Convert.ToBoolean(values[NEUWAGEN]) : (bool?)null;
            }

            if (values.Contains(STATUS))
            {
                model.Status = Convert.ToString(values[STATUS]);
            }

        }


        private string GetFullErrorMessage(ModelStateDictionary modelState)
        {
            var messages = new List<string>();

            foreach (var entry in modelState)
            {
                foreach (var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}