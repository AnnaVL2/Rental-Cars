using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MySpace.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/branches")]
    public class BranchesController: ApiController
    {
        private BranchesLogic logic = new BranchesLogic();

        //display all branches
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAllBranches()
        {
            try
            {
                List<BranchDTO> branches = logic.GetAllBranches();
                return Request.CreateResponse(HttpStatusCode.OK, branches);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                        ErrorsManager.GetInnerMessage(ex));
            }
        }

        //[HttpPost]
        //[Route("newBranch")]
        //public HttpResponseMessage AddBranch(BranchDTO branch)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.BadRequest,
        //                ErrorsManager.GetErrors(ModelState));
        //        }

        //        BranchDTO addedBranch = logic.AddBranch(branch);
        //        return Request.CreateResponse(HttpStatusCode.Created, addedBranch);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(
        //            HttpStatusCode.InternalServerError,
        //                ErrorsManager.GetInnerMessage(ex));
        //    }
        //}

        //[HttpDelete]
        //[Route("delete/{id}")]
        //public HttpResponseMessage DeleteBranch(int id)
        //{
        //    try
        //    {
        //        logic.DeleteBranch(id);
        //        return Request.CreateResponse(HttpStatusCode.NoContent);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(
        //            HttpStatusCode.InternalServerError,
        //                ErrorsManager.GetInnerMessage(ex));
        //    }
        //}

    }
}
