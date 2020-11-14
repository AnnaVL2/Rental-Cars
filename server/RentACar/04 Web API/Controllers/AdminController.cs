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
    [RoutePrefix("api/admin")]

    public class AdminController : ApiController
    {
        private VehiclesLogic vehiclesLogic = new VehiclesLogic();
        private VehicleTypesLogic vehicleTypesLogic = new VehicleTypesLogic();
        private UsersLogic usersLogic = new UsersLogic();
        private RentalsLogic rentalsLogic = new RentalsLogic();

        // add vehicle
        [HttpPost]
        [Route("addVehicle")]
        public HttpResponseMessage AddVehicle(VehicleDTO vehicle)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorsManager.GetErrors(ModelState));
                }

                VehicleDTO addedVehicle = vehiclesLogic.AddVehicle(vehicle);
                return Request.CreateResponse(HttpStatusCode.Created, addedVehicle);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ErrorsManager.GetInnerMessage(ex));
            }
        }


        // delete vehicle
        [HttpDelete]
        [Route("deleteVehicle/{id}")]
        public HttpResponseMessage DeleteVehicle(int id)
        {
            try
            {
                vehiclesLogic.DeleteVehicle(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ErrorsManager.GetInnerMessage(ex));
            }
        }


        // add vehicle type
        [HttpPost]
        [Route("addVehicleType")]
        public HttpResponseMessage AddVehicleType(VehicleTypeDTO vehicleType)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, 
                        ErrorsManager.GetErrors(ModelState));
                }

                VehicleTypeDTO addedVehicleType = vehicleTypesLogic.AddVehicleType(vehicleType);
                return Request.CreateResponse(HttpStatusCode.Created, addedVehicleType);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ErrorsManager.GetInnerMessage(ex));
            }
        }


        // delete vehicle type
        [HttpDelete]
        [Route("deleteVehicleType/{id}")]
        public HttpResponseMessage DeleteVehicleType(int id)
        {
            try
            {
                vehicleTypesLogic.DeleteVehicleType(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ErrorsManager.GetInnerMessage(ex));
            }
        }

        // add user
        [HttpPost]
        [Route("addUser")]
        public HttpResponseMessage AddUser(UserDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorsManager.GetErrors(ModelState));
                }

                UserDTO addedUser = usersLogic.AddUser(user);
                return Request.CreateResponse(HttpStatusCode.Created, addedUser);
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ErrorsManager.GetInnerMessage(ex));
            }
        }


        // delete user
        [HttpDelete]
        [Route("deleteUser/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            try
            {
                usersLogic.DeleteUser(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ErrorsManager.GetInnerMessage(ex));
            }
        }

        // delete rental
        [HttpDelete]
        [Route("deleteRental/{id}")]
        public HttpResponseMessage DeleteRental(int id)
        {
            try
            {
                rentalsLogic.DeleteRental(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ErrorsManager.GetInnerMessage(ex));
            }
        }

    }
}
