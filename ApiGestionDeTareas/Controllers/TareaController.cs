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
    public class TareaController : ApiController
    {
        [Dependency]
        public TareaRepository TareaRepositorio { get; set; }

        [ResponseType(typeof(TareaModel))]
        public IHttpActionResult Get()
        {
            var data = TareaRepositorio.Get();

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(TareaModel))]
        public IHttpActionResult Get(int id)
        {
            var data = TareaRepositorio.Get(id);

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(TareaModel))]
        public IHttpActionResult GetByGrupo(int grupoId)
        {
            var data = TareaRepositorio.Get(o => o.IdGrupo == grupoId);

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(TareaModel))]
        public IHttpActionResult Post(TareaModel model)
        {
            var data = TareaRepositorio.Add(model);

            if (data == null)
                return BadRequest();

            return Ok(data);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, TareaModel model)
        {
            //var d = TareaRepositorio.Get(id);
            if (/*d == null ||*/ id != model.Id)
                return BadRequest();


            var data = TareaRepositorio.Update(model);

            if (data < 1)
                return BadRequest();

            return Ok();
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            var data = TareaRepositorio.Delete(id);

            if (data < 1)
                return BadRequest();

            return Ok();
        }
    }
}
