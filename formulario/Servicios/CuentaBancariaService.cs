using formulario.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario.Servicios
{
    public class CuentaBancariaService : ICuentaBancariaService
    {
        private ICuentaBancariaRepository cuentaBancariaRepository;

        public CuentaBancariaService(ICuentaBancariaRepository _cuentaBancariaRepository)
        {
            this.cuentaBancariaRepository = _cuentaBancariaRepository;
        }

        public CuentaBancaria Get(long id)
        {
            return cuentaBancariaRepository.Get(id);
        }

        public IQueryable<CuentaBancaria> Get()
        {
            return cuentaBancariaRepository.Get();
        }

        public CuentaBancaria Create(CuentaBancaria cuentaBancaria)
        {
            return cuentaBancariaRepository.Create(cuentaBancaria);
        }

        public void Put(CuentaBancaria cuentaBancaria)
        {
            cuentaBancariaRepository.Put(cuentaBancaria);
        }

        public CuentaBancaria Delete(long id)
        {
            return cuentaBancariaRepository.Delete(id);
        }
    }
}