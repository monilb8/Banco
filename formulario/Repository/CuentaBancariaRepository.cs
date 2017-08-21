using formulario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace formulario.Repository
{
    public class CuentaBancariaRepository : ICuentaBancariaRepository
    {
        public CuentaBancaria Create(CuentaBancaria cuentaBancaria)
        {
            return ApplicationDbContext.applicationDbContext.CuentaBancaria.Add(cuentaBancaria);
        }

        public CuentaBancaria Get(long id)
        {
            return ApplicationDbContext.applicationDbContext.CuentaBancaria.Find(id);
        }

        public IQueryable<CuentaBancaria> Get()
        {
            IList<CuentaBancaria> lista = new List<CuentaBancaria>(ApplicationDbContext.applicationDbContext.CuentaBancaria);

            return lista.AsQueryable();
        }


        public void Put(CuentaBancaria cuentaBancaria)
        {
            if (ApplicationDbContext.applicationDbContext.CuentaBancaria.Count(e => e.Id == cuentaBancaria.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(cuentaBancaria).State = EntityState.Modified;
        }

        public CuentaBancaria Delete(long id)
        {
            CuentaBancaria cuentaBancaria = ApplicationDbContext.applicationDbContext.CuentaBancaria.Find(id);
            if (cuentaBancaria == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.CuentaBancaria.Remove(cuentaBancaria);
            return cuentaBancaria;
        }
    }
}