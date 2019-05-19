using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_Web_App.Models
{
        public class MoviesDbContext : DbContext
        {

            public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
            {
            }

            // DbSet = Repository

            public DbSet<Movie> Movies { get; set; }
            public DbSet<Comment> Coments { get; set; }




        }

    }

