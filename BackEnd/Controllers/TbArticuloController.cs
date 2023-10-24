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

        // GET: api/<TbArticuloController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<TbArticulo> articulos;
            articulos = tbArticuloDAL.GetAll();

            return new JsonResult(articulos);
        }

        // GET api/<TbArticuloController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TbArticuloController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TbArticuloController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TbArticuloController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
