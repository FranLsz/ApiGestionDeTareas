using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiGestionDeTareas.Repository;
using DataModel.ViewModel;
using Microsoft.Practices.Unity;

namespace ApiGestionDeTareas.Controllers
{
    public class GrupoController : ApiController
    {
        [Dependency]
        public GrupoRepository GrupoRepositorio { get; set; }

        [ResponseType(typeof(GrupoModel))]
        public IHttpActionResult Get()
        {
            var data = GrupoRepositorio.Get();

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(GrupoModel))]
        public IHttpActionResult Get(int id)
        {
            var data = GrupoRepositorio.Get(id);

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(GrupoModel))]
        public IHttpActionResult GetByUsuario(int userId)
        {
            var data = GrupoRepositorio.Get(o=>o.IdUsuario == userId);

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(GrupoModel))]
        public IHttpActionResult Post(GrupoModel model)
        {
            var data = GrupoRepositorio.Add(model);

            if (data == null)
                return BadRequest();

            return Ok(data);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, GrupoModel model)
        {
            var d = GrupoRepositorio.Get(id);
            if (d == null || d.Id != model.Id)
                return NotFound();


            var data = GrupoRepositorio.Update(model);

            if (data < 1)
                return BadRequest();

            return Ok();
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            var data = GrupoRepositorio.Delete(id);

            if (data < 1)
                return BadRequest();

            return Ok();
        }
    }
}
