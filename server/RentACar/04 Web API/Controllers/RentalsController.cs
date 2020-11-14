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
    [RoutePrefix("api/rentals")]
    public class RentalsController : ApiController
    {
        private RentalsLogic rentalLogic = new RentalsLogic();
        private SearchVehiclesLogic searchLogic = new SearchVehiclesLogic();


        //display all rentals
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAllRentals()
        {
            try
            {
                List<RentalDTO> rentals = rentalLogic.GetAllRentals();
                return Request.CreateResponse(HttpStatusCode.OK, rentals);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(
                HttpStatusCode.InternalServerError,
                ErrorsManager.GetInnerMessage(ex));
            }
        }

        //modify rental
        [HttpPut]
        [Route("{id}")]
        public HttpResponseMessage UpdateRental(int rentalCode, RentalDTO rental)
        {
            try
            {
                rental.rentalCode = rentalCode;
                RentalDTO updatedRental = rentalLogic.UpdateRental(rental);

                if (updatedRental == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);

                return Request.CreateResponse(HttpStatusCode.OK, updatedRental);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                        ErrorsManager.GetInnerMessage(ex));
            }
        }

        //add new rental
        [HttpPost]
        [Route("newRental")]
        public HttpResponseMessage AddRental(RentalDTO rental)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        ErrorsManager.GetErrors(ModelState));
                }

                RentalDTO addedRental = rentalLogic.AddRental(rental);
                return Request.CreateResponse(HttpStatusCode.Created, addedRental);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                        ErrorsManager.GetInnerMessage(ex));
            }
        }

        //delete rental
        //[HttpDelete]
        //[Route("delete/{id}")]
        //public HttpResponseMessage DeleteRental(int id)
        //{
        //    try
        //    {
        //        rentalLogic.DeleteRental(id);
        //        return Request.CreateResponse(HttpStatusCode.NoContent);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(
        //            HttpStatusCode.InternalServerError,
        //                ErrorsManager.GetInnerMessage(ex));
        //    }
        //}

        // search by dates

        [HttpGet]
        [Route("byDate/{pickupDate}/{estimatedReturnDate}")]
        public HttpResponseMessage VehicleByDate(DateTime pickupDate, DateTime estimatedReturnDate)
        {
            try
            {
                List<SearchVehicleDTO> searchVehicles = searchLogic.searchVehicles(pickupDate, estimatedReturnDate);
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
