using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HBSIS.SpaUserControl.Application.Interfaces;
using HBSIS.SpaUserControl.Application.ViewModels;

namespace HBSIS.SpaUserControl.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/v1/clients")]
    public class ClientsController : ApiController
    {
        private readonly IClientAppService _clientAppService;

        public ClientsController(IClientAppService clientAppService)
        {
            _clientAppService = clientAppService;
        }


        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            try
            {
                var clients = _clientAppService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, clients);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(string id)
        {
            try
            {
                var client = _clientAppService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, client);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(ClientViewModel model)
        {
            try
            {
                _clientAppService.Register(model);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage Update(ClientViewModel model)
        {
            try
            {
                _clientAppService.Update(model);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        
        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                _clientAppService.Remove(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
