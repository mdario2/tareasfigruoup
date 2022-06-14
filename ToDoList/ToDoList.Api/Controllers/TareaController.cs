using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Core.Entities;
using ToDoList.Core.Interfaces;
using ToDoList.Core.QueryFilters;

namespace ToDoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ITareaRepository _tareaRepository;

        public TareaController(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]TareaQueryFilter filters)
        {
            var tareas = await _tareaRepository.GetTareas(filters);
            return Ok(tareas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTarea(int id)
        {
            var tarea = await _tareaRepository.GetTarea(id);
            return Ok(tarea);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Tarea tarea)
        {
            await _tareaRepository.InsertTarea(tarea);
            return Ok(tarea);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id,Tarea tarea)
        {
            tarea.IdTarea = id;
            await _tareaRepository.UpdateTarea(tarea);
            return Ok(tarea);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> CambiarEstado(int id, [FromQuery] string estado)
        {
            await _tareaRepository.CambiarEstado(id,estado);
            return Ok(estado);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tareaRepository.DeleteTarea(id);
            return Ok(result) ;
        }
    }
}
