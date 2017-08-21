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

    public class CuentaBancariaController : ApiController
    {
        private ICuentaBancariaService cuentaBancariaService;

        public CuentaBancariaController(ICuentaBancariaService _cuentaBancariaService)
        {
            this.cuentaBancariaService = _cuentaBancariaService;
        }

        // GET: api/CuentaBancaria
        public IQueryable<CuentaBancaria> GetCuentaBancaria()
        {
            return cuentaBancariaService.Get();
        }

        // GET: api/CuentaBancaria/5
        [ResponseType(typeof(CuentaBancaria))]
        public IHttpActionResult GetCuentaBancaria(long id)
        {
            CuentaBancaria cuentaBancaria = cuentaBancariaService.Get(id);
            if (cuentaBancaria == null)
            {
                return NotFound();
            }

            return Ok(cuentaBancaria);
        }

        // PUT: api/CuentaBancaria/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCuentaBancaria(long id, CuentaBancaria cuentaBancaria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cuentaBancaria.Id)
            {
                return BadRequest();
            }

            try
            {
                cuentaBancariaService.Put(cuentaBancaria);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CuentaBancaria
        [ResponseType(typeof(CuentaBancaria))]
        public IHttpActionResult PostCuentaBancaria(CuentaBancaria cuentaBancaria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            cuentaBancaria = cuentaBancariaService.Create(cuentaBancaria);

            return CreatedAtRoute("DefaultApi", new { id = cuentaBancaria.Id }, cuentaBancaria);
        }

        // DELETE: api/CuentaBancaria/5
        [ResponseType(typeof(CuentaBancaria))]
        public IHttpActionResult DeleteCuentaBancaria(long id)
        {
            CuentaBancaria cuentaBancaria;
            try
            {
                cuentaBancaria = cuentaBancariaService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(cuentaBancaria);
        }
    }
}