using formulario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace formulario.Repository
{
    public class DomicilioRepository : IDomicilioRepository
    {
        public Domicilio Create(Domicilio domicilio)
        {
            return ApplicationDbContext.applicationDbContext.Domicilio.Add(domicilio);
        }

        public Domicilio Delete(long id)
        {
            Domicilio domicilio = ApplicationDbContext.applicationDbContext.Domicilio.Find(id);
            if (domicilio == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.Domicilio.Remove(domicilio);
            return domicilio;
        }

        public IQueryable<Domicilio> Get()
        {
            IList<Domicilio> lista = new List<Domicilio>(ApplicationDbContext.applicationDbContext.Domicilio);

            return lista.AsQueryable();
        }

        public Domicilio Get(long id)
        {
            return ApplicationDbContext.applicationDbContext.Domicilio.Find(id);
        }

        public void Put(Domicilio domicilio)
        {
            if (ApplicationDbContext.applicationDbContext.Domicilio.Count(e => e.Id == domicilio.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(domicilio).State = EntityState.Modified;
        }
    }
}