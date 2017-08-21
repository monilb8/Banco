using formulario.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario.Servicios
{
    public class DomicilioService : IDomicilioService
    {
        private IDomicilioRepository domicilioRepository;
        public DomicilioService(IDomicilioRepository _domicilioRepository)
        {
            this.domicilioRepository = _domicilioRepository;
        }

        public Domicilio Create(Domicilio domicilio)
        {
            return domicilioRepository.Create(domicilio);
        }

        public Domicilio Delete(long id)
        {
            return domicilioRepository.Delete(id);
        }

        public IQueryable<Domicilio> Get()
        {
            return domicilioRepository.Get();
        }

        public Domicilio Get(long id)
        {
            return domicilioRepository.Get(id);
        }

        public void Put(Domicilio domicilio)
        {
            domicilioRepository.Put(domicilio);
        }
    }
}