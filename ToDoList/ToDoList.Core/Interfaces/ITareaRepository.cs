using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Entities;
using ToDoList.Core.QueryFilters;

namespace ToDoList.Core.Interfaces
{
    public interface ITareaRepository
    {
        Task<IEnumerable<Tarea>> GetTareas(TareaQueryFilter filters);
        Task<Tarea> GetTarea(int id);
        Task InsertTarea(Tarea tarea);

        Task<bool> UpdateTarea(Tarea tarea);

        Task<bool> CambiarEstado(int id, string estado);

        Task<bool> DeleteTarea(int id);
    }
}
