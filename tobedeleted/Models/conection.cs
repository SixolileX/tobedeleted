using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace tobedeleted.Models
{
    public class conection:DbContext
    {
        public conection(DbContextOptions<conection> options) : base(options)
        {

        }
        public DbSet<Grade> Grade { get; set; }
    }
}
