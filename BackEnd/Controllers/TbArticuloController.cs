using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbArticuloController : ControllerBase
    {
        private ITbArticuloDAL tbArticuloDAL;

        public TbArticuloController()
        {
            tbArticuloDAL = new TbArticuloDALImpl(new Entities.GeCrmContext());
        }

        #region Obtener artículo
        // GET: api/<TbArticuloController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<TbArticulo> articulos;
                articulos = tbArticuloDAL.GetAll();

                return new JsonResult(articulos);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Obtener artículo ID
        // GET api/<TbArticuloController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                TbArticulo articulo = tbArticuloDAL.Get(id);
                return new JsonResult(articulo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Agregar artículo
        // POST api/<TbArticuloController>
        [HttpPost]
        public JsonResult Post([FromBody] TbArticulo articulo)
        {
            try
            {
                tbArticuloDAL.Add(articulo);
                return new JsonResult(articulo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Actualizar artículo
        // PUT api/<TbArticuloController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TbArticulo articulo)
        {
            try
            {
                tbArticuloDAL.Update(articulo);
                return new JsonResult(articulo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Eliminar artículo
        // DELETE api/<TbArticuloController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                TbArticulo articulo = new TbArticulo
                {
                    IdArticulo = id,
                };
                tbArticuloDAL.Remove(articulo);
                return "Exito";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        #endregion
    }
}
