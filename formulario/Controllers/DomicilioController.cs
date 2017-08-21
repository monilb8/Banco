using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using formulario;
using formulario.Models;
using formulario.Servicios;
using System.Web.Http.Cors;

namespace formulario.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class DomicilioController : ApiController
    {
        private IDomicilioService domicilioService;

        public DomicilioController(IDomicilioService _domicilioService)
        {
            this.domicilioService = _domicilioService;
        }

        // GET: api/Domicilio
        public IQueryable<Domicilio> GetDomicilio()
        {
            return domicilioService.Get();
        }

        // GET: api/Domicilio/5
        [ResponseType(typeof(Domicilio))]
        public IHttpActionResult GetDomicilio(long id)
        {
            Domicilio domicilio = domicilioService.Get(id);
            if (domicilio == null)
            {
                return NotFound();
            }

            return Ok(domicilio);
        }

        // PUT: api/Domicilio/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDomicilio(long id, Domicilio domicilio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != domicilio.Id)
            {
                return BadRequest();
            }

            try
            {
                domicilioService.Put(domicilio);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Domicilio
        [ResponseType(typeof(Domicilio))]
        public IHttpActionResult PostDomicilio(Domicilio domicilio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            domicilio = domicilioService.Create(domicilio);

            return CreatedAtRoute("DefaultApi", new { id = domicilio.Id }, domicilio);
        }

        // DELETE: api/Domicilio/5
        [ResponseType(typeof(Domicilio))]
        public IHttpActionResult DeleteDomicilio(long id)
        {
            Domicilio domicilio;
            try
            {
                domicilio = domicilioService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(domicilio);
        }

    }
}