using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class AesFoodSupplyContext : DbContext
    {
        public DbSet<Dishes> Dishes { get; set; }
        public DbSet<Menus> Menus { get; set; }
        public DbSet<MenuDishes> MenuDishes { get; set; }
        public DbSet<WorkerDishViews> WorkerDishViews { get; set; }
        public DbSet<Workers> Workers { get; set; }

        public AesFoodSupplyContext(DbContextOptions<AesFoodSupplyContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Встановлення первинних ключів
            modelBuilder.Entity<Dishes>().HasKey(d => d.DishID);
            modelBuilder.Entity<Menus>().HasKey(m => m.MenuID);
            modelBuilder.Entity<MenuDishes>().HasKey(md => md.MenuDishID);
            modelBuilder.Entity<WorkerDishViews>().HasKey(wdv => wdv.ViewID);
            modelBuilder.Entity<Workers>().HasKey(w => w.WorkerID);

            // Встановлення зв’язків (наприклад, Foreign Key)
            modelBuilder.Entity<MenuDishes>()
                .HasOne<Menus>()
                .WithMany()
                .HasForeignKey(md => md.MenuID);

            modelBuilder.Entity<MenuDishes>()
                .HasOne<Dishes>()
                .WithMany()
                .HasForeignKey(md => md.DishID);

            modelBuilder.Entity<WorkerDishViews>()
                .HasOne<Workers>()
                .WithMany()
                .HasForeignKey(wdv => wdv.WorkerID);

            modelBuilder.Entity<WorkerDishViews>()
                .HasOne<Dishes>()
                .WithMany()
                .HasForeignKey(wdv => wdv.DishID);
        }
    }
}

