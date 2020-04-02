using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Data
{
    public class Async_InnDbContext : DbContext
    {
        public Async_InnDbContext(DbContextOptions<Async_InnDbContext> options) : 
            base(options)
        {

        }
    }
}
