﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechOil.Models;
using TechOil.Models.DTO;
using TechOil.Services;

namespace TechOil.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicioController : ControllerBase
    {
        private readonly ServicioService _servicioService;

        public ServicioController(ServicioService servicioService)
        {
            _servicioService = servicioService;
        }
        //Método para listar todos los servicios existentes en la base de datos.
        [HttpGet]
        [Authorize(Roles = "admin,consultor")]
        public async Task<IActionResult> Get()
        {
            var servicios = await _servicioService.ObtenerTodosLosServicios();

            if (servicios == null)
            {
                return NotFound();
            }
            return Ok(servicios);
        }

        //Método para obtener un servicio mediante su código de identificación.
        [HttpGet]
        [Authorize(Roles = "admin,consultor")]
        [Route("{codServicio}")]
        public async Task<IActionResult> GetByCod(int codServicio)
        {
            var servicio = await _servicioService.ObtenerServicio(codServicio);

            if (servicio == null)
            {
                return NotFound();
            }
            return Ok(servicio);
        }

        //Método para listar todos los servicios activos en la base de datos.
        [HttpGet]
        [Authorize(Roles = "admin,consultor")]
        [Route("filtrar/ServiciosActivos")]
        public async Task<IActionResult> GetActive()
        {
            var serviciosActivos = await _servicioService.ObtenerServiciosActivos();

            if (serviciosActivos.Any())
            {
                return Ok(serviciosActivos);
            }

            return NotFound();
        }

        //Método para agregar un servicio en la base de datos.
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post(Servicio servicio)
        {
            await _servicioService.AñadirServicio(servicio);

            return CreatedAtAction("Get", new { id = servicio.codServicio }, servicio);
        }

        //Método para actualizar un servicio en la base de datos.
        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("{codServicio}")]
        public async Task<IActionResult> Put(int codServicio, ServicioDTO servicio)
        {
            var _servicio = await _servicioService.ObtenerServicio(codServicio);

            if (_servicio == null)
            {
                return NotFound();
            }

            _servicio.descr = servicio.descr;
            _servicio.estado = servicio.estado;
            _servicio.valorHora = servicio.valorHora;
            await _servicioService.ActualizarServicio(_servicio);

            return Ok();
        }

        //Método para eliminar un servicio en la base de datos.
        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("{codServicio}")]
        public async Task<IActionResult> Delete(int codServicio)
        {
            var servicio = await _servicioService.ObtenerServicio(codServicio);

            if (servicio == null)
            {
                return NotFound();
            }

            await _servicioService.EliminarServicio(codServicio);

            return Ok();
        }
    }
}
