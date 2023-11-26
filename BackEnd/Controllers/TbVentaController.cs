using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbVentaController : ControllerBase
    {
        ITbVentaDAL ventaDAL;

        #region Constructor
        public TbVentaController()
        {
            ventaDAL = new TbVentaDALImpl(new GeCrmContext());
        }
        #endregion

        #region Convert
        TbVenta Convertir(TbVentaModel venta)
        {
            return new TbVenta
            {
                IdVenta = venta.IdVenta,
                FechaVenta = venta.FechaVenta,
                MontoTotal = venta.MontoTotal,
                Estado = venta.Estado,
                IdClienteV = venta.IdClienteV
            };
        }

        TbVentaModel Convertir(TbVenta venta)
        {
            return new TbVentaModel
            {
                IdVenta = venta.IdVenta,
                FechaVenta = venta.FechaVenta,
                MontoTotal = venta.MontoTotal,
                Estado = venta.Estado,
                IdClienteV = venta.IdClienteV
            };
        }
        #endregion

        #region Read
        // GET: api/<TbVentaController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<TbVenta> ventas = new List<TbVenta>();
                venta = ventaDAL.GetAll().ToList();
                List<TbVentaModel> resultado = new List<TbVentaModel>();
                foreach (TbVenta venta in ventas)
                {
                    resultado.Add(Convertir(venta));
                }

                return new JsonResult(resultado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<TbVentaController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                TbVenta venta = ventaDAL.Get(id);
                return new JsonResult(Convertir(venta));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Create
        // POST api/<TbVentaController>
        [HttpPost]
        public JsonResult Post([FromBody] TbVentaModel venta)
        {
            try
            {
                TbVenta entity = Convertir(venta);
                ventaDAL.Add(entity);
                return new JsonResult(Convertir(entity));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        // PUT api/<TbVentaController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TbVentaModel venta)
        {
            try
            {
                TbVenta entity = Convertir(venta);
                ventaDAL.Update(entity);
                return new JsonResult(Convertir(entity));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        // DELETE api/<TbVentaController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                TbVenta venta = new TbVenta { IdVenta = id };
                ventaDAL.Remove(venta);
                return new JsonResult(venta);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
