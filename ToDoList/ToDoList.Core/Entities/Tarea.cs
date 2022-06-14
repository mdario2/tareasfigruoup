using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ToDoList.Core.Entities
{
    public partial class Tarea
    {
        public int IdTarea { get; set; }
        [StringLength(maximumLength :40)]
        public string Nombre { get; set; }
        public string Estado { get; set; }
    }
}
