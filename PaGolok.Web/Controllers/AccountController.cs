using System;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using PaGolok.Web.Models;
using PaGolok.Web.Infrastructure.Core;
using PaGolok.Services.Contracts;
using PaGolok.Data.Repositories;
using PaGolok.Data.Infrastructure;
using PaGolok.Entities.DB_Entity;
using System.Net.Http;
using PaGolok.Services.Utilities;
using System.Net;

namespace PaGolok.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiControllerBase
    {
        private readonly IMembershipService _membershipService;

        public AccountController(IMembershipService membershipService,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _membershipService = membershipService;
        }

        [AllowAnonymous]
        [Route("authenticate")]
         [System.Web.Http.AcceptVerbs("POST")]
        public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
                {
                    MembershipContext _userContext = _membershipService.ValidateUser(user.Username, user.Password);

                    if (_userContext.User != null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }
                }
                else
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = false });

                return response;
            });
        }

        [AllowAnonymous]
        [Route("register")]
        [System.Web.Http.AcceptVerbs("POST")]
        public HttpResponseMessage register(HttpRequestMessage request, RegistrationViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
                }
                else
                {
                    Entities.DB_Entity.User _user = _membershipService.CreateUser(user.Username, user.Email, user.Password, new int[] { 1 });

                    if (_user != null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }
                }

                return response;
            });
        }
    }
}