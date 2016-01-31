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
    public class UsuarioController : ApiController
    {

        [Dependency]
        public UsuarioRepository UsuarioRepositorio { get; set; }

        [ResponseType(typeof(UsuarioModel))]
        public IHttpActionResult Get()
        {
            var data = UsuarioRepositorio.Get();

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(UsuarioModel))]
        public IHttpActionResult Get(int id)
        {
            var data = UsuarioRepositorio.Get(id);

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(UsuarioModel))]
        public IHttpActionResult GetValido(string email, string password)
        {
            var data = UsuarioRepositorio.Validar(email, password);

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(UsuarioModel))]
        public IHttpActionResult GetUnico(string email)
        {
            var data = UsuarioRepositorio.IsUnico(email);

            return Ok(data);
        }

        [ResponseType(typeof(UsuarioModel))]
        public IHttpActionResult Post(UsuarioModel model)
        {
            var data = UsuarioRepositorio.Add(model);

            if (data == null)
                return BadRequest();

            return Ok(data);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, UsuarioModel model)
        {
            var d = UsuarioRepositorio.Get(id);
            if (d == null || d.Id != model.Id)
                return NotFound();


            var data = UsuarioRepositorio.Update(model);

            if (data < 1)
                return BadRequest();

            return Ok();
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            var data = UsuarioRepositorio.Delete(id);

            if (data < 1)
                return BadRequest();

            return Ok();
        }

    }
}

