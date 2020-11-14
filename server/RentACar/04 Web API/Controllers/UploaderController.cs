using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MySpace
{
    [EnableCors("*","*","*")]
    public class UploaderController : ApiController
    {
        [HttpPost]
        [Route("api/upload/{userID}")]
        public HttpResponseMessage SaveImage(int userID)
        {
            try
            {
                //string s = HttpContext.Current.Request.Files[0].FileName;

                //unique file name
                string fileName = Guid.NewGuid() + ".jpg";
                
                //find entire path to the uploads diectory on server
                string fullPath = HttpContext.Current.Server.MapPath("~/Uploads/" + fileName);
                
                //create a stream pointing to that location for creating a new file
                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    //copy the uploaded file into the new stream:
                    HttpContext.Current.Request.InputStream.CopyTo(stream); // saving the file
                }
                
                // saving in the database only the file name
                // הנ"ל userID-שמירת שם התמונה בטבלת המשתמשים ברשומה של ה



                // return response to the client
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
