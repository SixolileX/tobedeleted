using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace tobedeleted.Models
{
    public class connection:DbContext
    {
    
        public connection(DbContextOptions<connection> options) : base(options)
        {

        }
        public DbSet<AssignSubject> AssignSubject { get; set; }
    }
}
