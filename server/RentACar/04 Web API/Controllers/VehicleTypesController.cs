using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MySpace
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/vehicleTypes")]
    public class VehicleTypesController : ApiController
    {
        private VehicleTypesLogic logic = new VehicleTypesLogic();
        private SearchVehiclesLogic logic2 = new SearchVehiclesLogic();

        // סוג רכב

        //display all v.types
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAllVehicleTypes()
        {
            try
            {
                List<VehicleTypeDTO> vTypes = logic.GetAllVehicleTypes();
                return Request.CreateResponse(HttpStatusCode.OK, vTypes);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(
                HttpStatusCode.InternalServerError,
                ErrorsManager.GetInnerMessage(ex));

            }
        }

        //
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetOneVehicleType(int id)
        {
            try
            {
                VehicleTypeDTO vTypes = logic.GetOneVehicleType(id);
                return Request.CreateResponse(HttpStatusCode.OK, vTypes);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                        ErrorsManager.GetInnerMessage(ex));
            }
        }

        //[HttpPut]
        //[Route("{id}")]
        //public HttpResponseMessage UpdateVehicleType(int vehicleTypeID, VehicleTypeDTO vType)
        //{
        //    try
        //    {
        //        vType.vehicleTypeID = vehicleTypeID;

        //        VehicleTypeDTO updateVehicleType = logic.UpdateVehicleType(vType);

        //        if (updateVehicleType == null)
        //            return Request.CreateResponse(HttpStatusCode.NotFound);

        //        return Request.CreateResponse(HttpStatusCode.OK, updateVehicleType);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(
        //            HttpStatusCode.InternalServerError,
        //                ErrorsManager.GetInnerMessage(ex));
        //    }
        //}

        [HttpPost]
        [Route("newVehicleType")]

        //add new v.type - manager
        public HttpResponseMessage AddVehicleType(VehicleTypeDTO vType)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        ErrorsManager.GetErrors(ModelState));
                }

                VehicleTypeDTO addedVehicleType = logic.AddVehicleType(vType);
                return Request.CreateResponse(HttpStatusCode.Created, addedVehicleType);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                        ErrorsManager.GetInnerMessage(ex));
            }
        }

        //delete v.type - manager 
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteVehicleType(int id)
        {
            try
            {
                logic.DeleteVehicleType(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                        ErrorsManager.GetInnerMessage(ex));
            }
        }

        //search by dates
        [HttpGet]
        [Route("byDate/{start}/{end}")]
        public HttpResponseMessage CarByDate(DateTime start, DateTime end)
        {
            try
            {
                List<SearchVehicleDTO> searchVehicles = logic2.searchVehicles(start, end);
                return Request.CreateResponse(HttpStatusCode.OK, searchVehicles);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
