using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MySpace
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/vehicles")]
    public class VehiclesController : ApiController
    {
        private VehiclesLogic logic = new VehiclesLogic();

        //display all vehicles
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAllVehicles()
        {
            try
            {
                List<VehicleAndVehicleTypeDTO> cars = logic.GetAllVehicles();
                return Request.CreateResponse(HttpStatusCode.OK, cars);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(
                HttpStatusCode.InternalServerError,
                ErrorsManager.GetInnerMessage(ex));
            }
        }

        // add image to vehicle
        [HttpPost]
        [Route("upload/{id}")]
        public IHttpActionResult SaveImage(int id)
        {
            string fileName = Guid.NewGuid() + ".jpg";

            for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
            {
                var myFile = HttpContext.Current.Request.Files[i];
                if (myFile != null && myFile.ContentLength != 0)
                {
                    string fullPath = HttpContext.Current.Server.MapPath("~/Uploads/" + fileName);
                    myFile.SaveAs(fullPath);
                }
            }
            //save db
            logic.SaveImage(id, fileName);
            VehicleDTO car = logic.GetOneVehicle(id);
            car.carImage = fileName;
            VehicleDTO update = logic.UpdateVehicle(car);

            return Ok();
        }

        //[HttpGet]
        //[Route("{id}")]
        //public HttpResponseMessage GetOneVehicle(int id)
        //{
        //    try
        //    {
        //        VehicleDTO car = logic.GetOneVehicle(id);
        //        return Request.CreateResponse(HttpStatusCode.OK, car);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(
        //            HttpStatusCode.InternalServerError,
        //                ErrorsManager.GetInnerMessage(ex));
        //    }
        //}

        //[HttpPut]
        //[Route("{id}")]
        //public HttpResponseMessage UpdateVehicle(int VehicleID, VehicleDTO car)
        //{
        //    try
        //    {
        //        // Route-עדכון קוד רכב לפי מה שנשלח ב
        //        car.vehicleID = VehicleID;

        //        // עדכון רכב במסד הנתונים
        //        VehicleDTO updatedCar = logic.UpdateVehicle(car);

        //        // 404 אם לא קיים רכב כזה - החזרת
        //        if (updatedCar == null)
        //            return Request.CreateResponse(HttpStatusCode.NotFound);

        //        // רכב קיים - החזר 200
        //        return Request.CreateResponse(HttpStatusCode.OK, updatedCar);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(
        //            HttpStatusCode.InternalServerError,
        //                ErrorsManager.GetInnerMessage(ex));
        //    }
        //}

        [HttpPost]
        // add new vehicle - manager
        [Route("newVehicle")]
        public HttpResponseMessage AddVehicle(VehicleDTO car)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        ErrorsManager.GetErrors(ModelState));
                }

                VehicleDTO addedCar = logic.AddVehicle(car);
                return Request.CreateResponse(HttpStatusCode.Created, addedCar);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                        ErrorsManager.GetInnerMessage(ex));
            }
        }


        // delete vehicle - manager
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteVehicle(int id)
        {
            try
            {
                logic.DeleteVehicle(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                        ErrorsManager.GetInnerMessage(ex));
            }
        }
    }
}
