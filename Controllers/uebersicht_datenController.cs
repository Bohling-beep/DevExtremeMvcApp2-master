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
    [Route("api/uebersicht_daten/{action}", Name = "uebersicht_datenApi")]
    public class uebersicht_datenController : ApiController
    {
        private FuhrparkContextEntities _context = new FuhrparkContextEntities();

        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions) {
            var uebersicht_daten = _context.uebersicht_daten.Select(i => new {
                i.Id,
                i.Kennzeichen,
                i.Marke,
                i.Modell,
                i.Fahrzeughalter,
                i.Niederlassung,
                i.Kraftstoff,
                i.Neuwagen,
                i.Status
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Request.CreateResponse(await DataSourceLoader.LoadAsync(uebersicht_daten, loadOptions));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form) {
            var model = new uebersicht_daten();
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            var result = _context.uebersicht_daten.Add(model);
            await _context.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.Created, result.Id);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form) {
            var key = Convert.ToInt32(form.Get("key"));
            var model = await _context.uebersicht_daten.FirstOrDefaultAsync(item => item.Id == key);
            if(model == null)
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
        public async Task Delete(FormDataCollection form) {
            var key = Convert.ToInt32(form.Get("key"));
            var model = await _context.uebersicht_daten.FirstOrDefaultAsync(item => item.Id == key);

            _context.uebersicht_daten.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(uebersicht_daten model, IDictionary values) {
            string ID = nameof(uebersicht_daten.Id);
            string KENNZEICHEN = nameof(uebersicht_daten.Kennzeichen);
            string MARKE = nameof(uebersicht_daten.Marke);
            string MODELL = nameof(uebersicht_daten.Modell);
            string FAHRZEUGHALTER = nameof(uebersicht_daten.Fahrzeughalter);
            string NIEDERLASSUNG = nameof(uebersicht_daten.Niederlassung);
            string KRAFTSTOFF = nameof(uebersicht_daten.Kraftstoff);
            string NEUWAGEN = nameof(uebersicht_daten.Neuwagen);
            string STATUS = nameof(uebersicht_daten.Status);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(KENNZEICHEN)) {
                model.Kennzeichen = Convert.ToString(values[KENNZEICHEN]);
            }

            if(values.Contains(MARKE)) {
                model.Marke = Convert.ToString(values[MARKE]);
            }

            if(values.Contains(MODELL)) {
                model.Modell = Convert.ToString(values[MODELL]);
            }

            if(values.Contains(FAHRZEUGHALTER)) {
                model.Fahrzeughalter = Convert.ToString(values[FAHRZEUGHALTER]);
            }

            if(values.Contains(NIEDERLASSUNG)) {
                model.Niederlassung = Convert.ToString(values[NIEDERLASSUNG]);
            }

            if(values.Contains(KRAFTSTOFF)) {
                model.Kraftstoff = Convert.ToString(values[KRAFTSTOFF]);
            }

            if(values.Contains(NEUWAGEN)) {
                model.Neuwagen = values[NEUWAGEN] != null ? Convert.ToBoolean(values[NEUWAGEN]) : (bool?)null;
            }

            if(values.Contains(STATUS)) {
                model.Status = Convert.ToString(values[STATUS]);
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}