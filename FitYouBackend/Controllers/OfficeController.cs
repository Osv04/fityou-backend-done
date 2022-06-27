using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using ExcelDataReader;
using FitYouBackend.Models;

namespace FitYouBackend.Controllers
{
    [AllowAnonymous]
    public class OfficeController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/GetOffices
        [Route("api/GetOffices")]
        [HttpGet]
        public IEnumerable<Office> GetOffices()
        {
            return db.Offices.ToList();
        }

        // GET: api/GetOfficeById/5
        [ResponseType(typeof(Office))]
        [Route("api/GetOfficeById/{id}")]
        [HttpGet]
        public IHttpActionResult GetOffice(int id)
        {
            Office office = db.Offices.Find(id);
            if (office == null)
            {
                return NotFound();
            }

            return Ok(office);
        }

        // PUT: api/PutOffice/5
        [ResponseType(typeof(void))]
        [Route("api/PutOffice/{id}")]
        [HttpPut]
        public IHttpActionResult PutOffice(int id, [FromBody] Office office)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != office.Id)
            {
                return BadRequest();
            }

            db.Entry(office).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Office updated successfully.");
        }

        // POST: api/PostOffice
        [ResponseType(typeof(Office))]
        [Route("api/PostOffice")]
        [HttpPost]
        public IHttpActionResult PostOffice([FromBody] Office office)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Offices.Add(office);
            db.SaveChanges();

            return Ok("Office created successfully.");
        }

        // DELETE: api/DeleteOffice/5
        [ResponseType(typeof(Office))]
        [Route("api/DeleteOffice/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteOffice(int id)
        {
            Office office = db.Offices.Find(id);
            if (office == null)
            {
                return NotFound();
            }

            db.Offices.Remove(office);
            db.SaveChanges();

            return Ok("Office deleted successfully.");
        }

        [HttpPost]
        [Route("api/office/Importar")]
        public IHttpActionResult loadDataFromExcel()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("El modelo no es valido para enviuar");
            }
            else
            {

                HttpResponseMessage ResponseMessage = null;
                var httpRequest = HttpContext.Current.Request;
                DataSet dsexcelRecords = new DataSet();
                IExcelDataReader reader = null;
                HttpPostedFile Inputfile = null;
                Stream FileStream = null;
                int execution = 0;

                if (httpRequest.Files.Count > 0)
                {
                    Inputfile = httpRequest.Files[0];
                    FileStream = Inputfile.InputStream;

                    if (Inputfile.FileName.EndsWith(".xls"))
                        reader = ExcelReaderFactory.CreateBinaryReader(FileStream);
                    else if (Inputfile.FileName.EndsWith(".xlsx"))
                        reader = ExcelReaderFactory.CreateOpenXmlReader(FileStream);
                    else
                        return NotFound(); 

                    
                    dsexcelRecords = reader.AsDataSet();
                    reader.Close();

                    int count = 0;

                    if (dsexcelRecords != null && dsexcelRecords.Tables.Count > 0)
                    {

                        DataTable dtStudentRecords = dsexcelRecords.Tables[0];

                        for (int i = 1; i < dtStudentRecords.Rows.Count; i++)
                        {

                            Office sucrusal = new Office();
                            sucrusal.Longitude = Convert.ToString(dtStudentRecords.Rows[i].ItemArray[0]);
                            sucrusal.Latitude = Convert.ToString(dtStudentRecords.Rows[i].ItemArray[0]);
                            sucrusal.PhoneNumber = Convert.ToString(dtStudentRecords.Rows[i].ItemArray[0]);
                            sucrusal.CompanyId = int.Parse(dtStudentRecords.Rows[i].ItemArray[0].ToString());

                            db.Offices.Add(sucrusal);
                            count += db.SaveChanges();
                        }

                        if (count > dtStudentRecords.Rows.Count)
                        {
                            return Ok("Los datos se guardaron correctamente");
                        }
                        else
                        {
                            return BadRequest("Ha ocurrido un error");
                        }
                    }
                    else
                    {
                        return BadRequest("Ha ocurrido un error en el proceso");
                    }

                }
                else
                {
                    return Ok("El documento esta vacio");
                }
            }

            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OfficeExists(int id)
        {
            return db.Offices.Count(e => e.Id == id) > 0;
        }
    }
}