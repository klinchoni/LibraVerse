using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraVerse.Data
{
    public class LibraDbContext : DbContext
    {
        //Empty ctor to use it for tests
        public LibraDbContext()
        {
            
        }

        public LibraDbContext(DbContextOptions options)
            :base (options)
        {
            
        }
    }
}
