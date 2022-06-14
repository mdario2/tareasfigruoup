using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Entities;
using ToDoList.Core.Interfaces;
using ToDoList.Core.QueryFilters;
using ToDoList.Infraestructure.Data;

namespace ToDoList.Infraestructure.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        private readonly FigroupDBContext _context;
        public TareaRepository(FigroupDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Tarea>> GetTareas(TareaQueryFilter filters)
        {
            var tareas = await _context.Tareas.ToListAsync();
            
            if (filters.IdTarea != null)
            {
                tareas = (List<Tarea>)tareas.Where(x => x.IdTarea == filters.IdTarea);
            }
            if (filters.NombreTarea != null)
            {
                tareas = (List<Tarea>)tareas.Where(x => x.Nombre.Contains(filters.NombreTarea));
            }
            if (filters.Estado != null)
            {
                tareas = (List<Tarea>)tareas.Where(x => x.Estado.ToLower().Contains(filters.Estado.ToLower()));
            }

            return tareas;
        }

        public async Task<Tarea> GetTarea(int id)
        {
            var tarea = await _context.Tareas.FirstOrDefaultAsync(x => x.IdTarea == id);
            return tarea;
        }

        public async Task InsertTarea(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> UpdateTarea(Tarea tarea)
        {
            var currentTarea = await GetTarea(tarea.IdTarea);
            currentTarea.Nombre = tarea.Nombre;
            currentTarea.Estado = tarea.Estado;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> CambiarEstado(int id, string estado)
        {
            var currentTarea = await GetTarea(id);            
            currentTarea.Estado = estado;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteTarea(int id)
        {
            var currentTarea = await GetTarea(id);
            _context.Tareas.Remove(currentTarea);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;

        }

       
    }
}
