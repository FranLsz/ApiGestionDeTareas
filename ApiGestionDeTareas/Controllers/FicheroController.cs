using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiGestionDeTareas.Repository;
using ApiGestionDeTareas.Utils;
using DataModel.ViewModel;
using Microsoft.Practices.Unity;

namespace ApiGestionDeTareas.Controllers
{
    public class FicheroController : ApiController
    {
        [Dependency]
        public FicheroRepository FicheroRepositorio { get; set; }

        [ResponseType(typeof(FicheroModel))]
        public IHttpActionResult Get()
        {
            var data = FicheroRepositorio.Get();

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(FicheroModel))]
        public IHttpActionResult Get(int id)
        {
            var data = FicheroRepositorio.Get(id);

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(FicheroModel))]
        public IHttpActionResult Post(FicheroModel model)
        {
            /*var data = FicheroRepositorio.Add(model);

            if (data == null)
                return BadRequest();

            return Ok(data);*/


            var cuenta = ConfigurationManager.AppSettings["cuenta"];
            var clave =
            ConfigurationManager.AppSettings["clave"];
            var contenedor = ConfigurationManager.AppSettings["contenedor"];

            var sto = new AzureStorageUtils(cuenta, clave, contenedor);
            var nombre = Guid.NewGuid() + ".png";

            sto.SubirFichero(Convert.FromBase64String(model.Nombre), nombre);

            return Ok(nombre);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, FicheroModel model)
        {
            var d = FicheroRepositorio.Get(id);
            if (d == null || d.Id != model.Id)
                return NotFound();


            var data = FicheroRepositorio.Update(model);

            if (data < 1)
                return BadRequest();

            return Ok();
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            var data = FicheroRepositorio.Delete(id);

            if (data < 1)
                return BadRequest();

            return Ok();
        }
    }
}
