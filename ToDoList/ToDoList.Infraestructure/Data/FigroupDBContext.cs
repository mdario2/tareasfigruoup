using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ToDoList.Core.Entities;
using ToDoList.Infraestructure.Data.Configurations;

#nullable disable

namespace ToDoList.Infraestructure.Data
{
    public partial class FigroupDBContext : DbContext
    {
        public FigroupDBContext()
        {
        }

        public FigroupDBContext(DbContextOptions<FigroupDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tarea> Tareas { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TareaConfiguration());
            
        }
        
    }
}
