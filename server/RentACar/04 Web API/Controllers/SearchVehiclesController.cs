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
    [RoutePrefix("api/search")]
    public class SearchVehiclesController : ApiController
    {
        private SearchVehiclesLogic logic = new SearchVehiclesLogic();

        [HttpGet]
        [Route("byDate/{pickupDate}/{estimatedReturnDate}")]
        public HttpResponseMessage GetAllVacant(DateTime pickupDate, DateTime estimatedReturnDate)
        {
            try
            {
                List<SearchVehicleDTO> searchVehicles = logic.searchVehicles(pickupDate, estimatedReturnDate);
                return Request.CreateResponse(HttpStatusCode.OK, searchVehicles);
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
