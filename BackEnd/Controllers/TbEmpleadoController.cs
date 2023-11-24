using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbEmpleadoController : ControllerBase
    {
        ITbEmpleadoDAL empleadoDAL;

        #region Constructor
        public TbEmpleadoController()
        {
            empleadoDAL = new TbEmpleadoDALImpl(new GeCrmContext());
        }
        #endregion

        #region Convert
        TbEmpleado Convertir(TbEmpleadoModel empleado)
        {
            return new TbEmpleado
            {
                IdEmpleado = empleado.IdEmpleado,
                Cedula = empleado.Cedula,
                RutaFoto = empleado.RutaFoto,
                Nombre = empleado.Nombre,
                Apellido1 = empleado.Apellido1,
                Apellido2 = empleado.Apellido2,
                TelefonoEmpleado = empleado.TelefonoEmpleado,
                CorreoEmpleado = empleado.CorreoEmpleado,
                Direccion = empleado.Direccion,
                NombreContacto = empleado.NombreContacto,
                TelefonoContacto = empleado.TelefonoContacto,
                Activo = empleado.Activo,
                IdRol = empleado.IdRol

            };
        }

        TbEmpleadoModel Convertir(TbEmpleado empleado)
        {
            return new TbEmpleadoModel
            {
                IdEmpleado = empleado.IdEmpleado,
                Cedula = empleado.Cedula,
                RutaFoto = empleado.RutaFoto,
                Nombre = empleado.Nombre,
                Apellido1 = empleado.Apellido1,
                Apellido2 = empleado.Apellido2,
                TelefonoEmpleado = empleado.TelefonoEmpleado,
                CorreoEmpleado = empleado.CorreoEmpleado,
                Direccion = empleado.Direccion,
                NombreContacto = empleado.NombreContacto,
                TelefonoContacto = empleado.TelefonoContacto,
                Activo = empleado.Activo,
                IdRol = empleado.IdRol

            };
        }
        #endregion

        #region Read
        // GET: api/<TbEmpleadoController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<TbEmpleado> empleados = new List<TbEmpleado>();
                empleados = empleadoDAL.GetAll().ToList();
                List<TbEmpleadoModel> resultado = new List<TbEmpleadoModel>();
                foreach (TbEmpleado empleado in empleados)
                {
                    resultado.Add(Convertir(empleado));
                }

                return new JsonResult(resultado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<TbEmpleadoController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                TbEmpleado empleado = empleadoDAL.Get(id);
                return new JsonResult(Convertir(empleado));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Create
        // POST api/<TbEmpleadoController>
        [HttpPost]
        public JsonResult Post([FromBody] TbEmpleadoModel empleado)
        {
            try
            {
                TbEmpleado entity = Convertir(empleado);
                empleadoDAL.Add(entity);
                return new JsonResult(Convertir(entity));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        // PUT api/<TbEmpleadoController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TbEmpleadoModel empleado)
        {
            try
            {
                TbEmpleado entity = Convertir(empleado);
                empleadoDAL.Update(entity);
                return new JsonResult(Convertir(entity));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        // DELETE api/<TbEmpleadoController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                TbEmpleado empleado = new TbEmpleado { IdEmpleado = id };
                empleadoDAL.Remove(empleado);
                return new JsonResult(empleado);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
