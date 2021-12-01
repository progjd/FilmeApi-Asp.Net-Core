using FilmeApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmeApi.Data
{
    public class FilmeDBContext : DbContext
    {
        public FilmeDBContext(DbContextOptions<FilmeDBContext> options) : base (options)
        {

        }

        public DbSet<Filme> Filme { get; set; }
    }
}
