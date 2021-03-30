using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Context : DbContext
    {
        public DbSet<CadastroAlunos> CadastroAlunos { get; set; }

        public DbSet<CadastroLivros> CadastroLivros { get; set; }

        public DbSet<CadastroEmprestimoLivros> CadastroEmprestimoLivros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WIN01\\SQLEXPRESS;Database=Libary;Trusted_Connection=True");
        }
    }
}
