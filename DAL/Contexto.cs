using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;
using Usuario.Entidades;

namespace Usuario.DAL
{
    //Crea Una herencia de DbContext para eso vas a donde dice Class Contexto  y 
    //le pones al lado DbContext asi  : DbContext

    //paso2
    //ahora presiona (Contro + punto) dentro de la clase , le das a generate Override y 
    //seleccionas solo el que diice OnConfiguring
    //ahora borra donde dice base.OnConfiguring() 
    //en la linea que borraste escribe "optionBuilder.UseSqLite(@""); si aparece automatico mejor"

    //En las comillas despues del arroba pon "Data Source= DATA/Database.db"
    //En la consola de abajo Escribe: add-mirgation migracion dale enter todo enter xd toy jalta
    //Escribe update-database
    class Contexto:DbContext 
    {
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA/Database.db"); //Ahi se guardara la base de datos
        }
    }
}
