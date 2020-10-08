using System;
using Microsoft.EntityFrameworkCore;
using  LuisDavidGil_P1_AP2.Models;


namespace LuisDavidGil_P1_AP2.DAL
{
        public class Contexto : DbContext
    {
        public  DbSet<Productos> Productos{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = Data\\Parcial.db");


        }
    }
    
}
