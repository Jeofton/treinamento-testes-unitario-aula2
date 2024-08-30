namespace GestaoEstoque.Data
    {
    using GestaoEstoque.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class AppDbContext : DbContext
        {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }
        }

    }
