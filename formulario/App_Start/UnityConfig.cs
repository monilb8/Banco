using formulario.Repository;
using formulario.Servicios;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System.Web.Http;
using Unity.WebApi;
using System;
using System.Collections.Generic;
using formulario.Models;

namespace formulario
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.AddNewExtension<Interception>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUsuariosService, UsuariosService>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<DBInterceptor>());
            container.RegisterType<IUsuariosRepository, UsuariosRepository>();

            container.RegisterType<ICuentaBancariaService, CuentaBancariaService>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<DBInterceptor>());
            container.RegisterType<ICuentaBancariaRepository, CuentaBancariaRepository>();

            container.RegisterType<IDomicilioService, DomicilioService>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<DBInterceptor>());
            container.RegisterType<IDomicilioRepository, DomicilioRepository>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }

    public class DBInterceptor : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input,
          GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn result;
            if (ApplicationDbContext.applicationDbContext == null)
            {
                using (var context = new ApplicationDbContext())
                {
                    ApplicationDbContext.applicationDbContext = context;
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {

                            result = getNext()(input, getNext);


                            if (result.Exception != null)
                            {
                                throw result.Exception;
                            }
                            context.SaveChanges();

                            dbContextTransaction.Commit();
                        }
                        catch (Exception e)
                        {
                            dbContextTransaction.Rollback();
                            throw new Exception("He hecho rollback de la transacci�n", e);
                            ApplicationDbContext.applicationDbContext = null;
                        }
                    }
                }
                ApplicationDbContext.applicationDbContext = null;
            }
            else
            {

                result = getNext()(input, getNext);


                if (result.Exception != null)
                {
                    throw result.Exception;
                }
            }
            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }

        private void WriteLog(string message)
        {

        }
    }
}