using System.Data.Entity;
using Microsoft.Practices.Unity;
using System.Web.Http;
using ApiGestionDeTareas.Repository;
using Repository.Model;
using Unity.WebApi;

namespace ApiGestionDeTareas
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<DbContext, GestionDeTareas15Entities>();
            container.RegisterType<UsuarioRepository>();
            container.RegisterType<GrupoRepository>();
            container.RegisterType<TareaRepository>();
            container.RegisterType<FicheroRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}