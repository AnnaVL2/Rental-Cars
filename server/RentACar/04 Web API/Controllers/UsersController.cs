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
    [RoutePrefix("api/users")]

    public class UsersController : ApiController
    {
        private UsersLogic userLogic = new UsersLogic();
        private RentalsLogic rentalLogic = new RentalsLogic();


        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAllUsers()
        {
            try
            {
                List<UserDTO> users = userLogic.GetAllUsers();
                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(
                HttpStatusCode.InternalServerError,
                ErrorsManager.GetInnerMessage(ex));
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage UpdateUser(int userID, UserDTO user)
        {
            //try
            {
                // Route-עדכון קוד משתמש לפי מה שנשלח ב
                user.userID = userID;

                // עדכון המוצר במסד הנתונים
                UserDTO updatedUser = userLogic.UpdateUser(user);

                // 404 אם לא קיים משתמש כזה - החזרת
                if (updatedUser == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);

                // משתמש קיים - החזר 200
                return Request.CreateResponse(HttpStatusCode.OK, updatedUser);
            }
            //catch (Exception ex)
            //{
            //    return Request.CreateErrorResponse(
            //        HttpStatusCode.InternalServerError,
            //            ErrorsManager.GetInnerMessage(ex));
            //}
        }

        [HttpPost]
        [Route("newUser")]
        public HttpResponseMessage AddUser(UserDTO user)
        {
            //try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        ErrorsManager.GetErrors(ModelState));
                }

                UserDTO addedUser = userLogic.AddUser(user);
                return Request.CreateResponse(HttpStatusCode.Created, addedUser);
            }
            //catch (Exception ex)
            //{
            //    return Request.CreateErrorResponse(
            //        HttpStatusCode.InternalServerError,
            //            ErrorsManager.GetInnerMessage(ex));
            //}
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            try
            {
                userLogic.DeleteUser(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
        }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                        ErrorsManager.GetInnerMessage(ex));
            }
}

        [HttpGet]
        [Route("allRoles")]
        public HttpResponseMessage GetAllRoles()
        {
            try
            {
                List<RoleDTO> roles = userLogic.GetAllRoles();
                return Request.CreateResponse(HttpStatusCode.OK, roles);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ErrorsManager.GetInnerMessage(ex));
            }
        }

        [HttpPost]
        [Route("login")]
        public HttpResponseMessage login(CredentialsDTO credentials)
        {
            try
            {
                UserDTO userLogin = userLogic.Login(credentials.userName, credentials.password);
                return Request.CreateResponse(HttpStatusCode.OK, userLogin);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ErrorsManager.GetInnerMessage(ex));
            }
        }
    }
}
