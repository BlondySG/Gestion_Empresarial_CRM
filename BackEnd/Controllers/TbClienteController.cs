using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbClienteController : ControllerBase
    {
        ITbClienteDAL clienteDAL;

        #region Constructor
        public TbClienteController()
        {
            clienteDAL = new TbClienteDALImpl(new GeCrmContext());
        }
        #endregion

        #region Convert
        TbCliente Convertir(TbClienteModel cliente)
        {
            return new TbCliente
            {
                IdCliente = cliente.IdCliente,
                NombreCliente = cliente.NombreCliente,
                CorreoCliente = cliente.CorreoCliente,
                PersonaContacto = cliente.PersonaContacto,
                DireccionCliente = cliente.DireccionCliente,
                TelefonoCliente = cliente.TelefonoCliente,
                Activo = cliente.Activo

            };
        }

        TbClienteModel Convertir(TbCliente cliente)
        {
            return new TbClienteModel
            {
                IdCliente = cliente.IdCliente,
                NombreCliente = cliente.NombreCliente,
                CorreoCliente = cliente.CorreoCliente,
                PersonaContacto = cliente.PersonaContacto,
                DireccionCliente = cliente.DireccionCliente,
                TelefonoCliente = cliente.TelefonoCliente,
                Activo = cliente.Activo

            };
        }
        #endregion

        #region Read
        // GET: api/<TbClienteController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<TbCliente> clientes = new List<TbCliente>();
                clientes = clienteDAL.GetAll().ToList();
                List<TbClienteModel> resultado = new List<TbClienteModel>();
                foreach (TbCliente cliente in clientes)
                {
                    resultado.Add(Convertir(cliente));
                }

                return new JsonResult(resultado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<TbClienteController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                TbCliente cliente = clienteDAL.Get(id);
                return new JsonResult(Convertir(cliente));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Create
        // POST api/<TbClienteController>
        [HttpPost]
        public JsonResult Post([FromBody] TbClienteModel cliente)
        {
            try
            {
                TbCliente entity = Convertir(cliente);
                clienteDAL.Add(entity);
                return new JsonResult(Convertir(entity));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        // PUT api/<TbClienteController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TbClienteModel cliente)
        {
            try
            {
                TbCliente entity = Convertir(cliente);
                clienteDAL.Update(entity);
                return new JsonResult(Convertir(entity));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        // DELETE api/<TbClienteController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                TbCliente cliente = new TbCliente { IdCliente = id };
                clienteDAL.Remove(cliente);
                return new JsonResult(cliente);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
