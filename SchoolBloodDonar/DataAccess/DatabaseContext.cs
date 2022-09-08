using Microsoft.EntityFrameworkCore;
using SchoolBloodDonar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBloodDonar.DataAccess
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<SchoolModel> SchoolDonars { get; set; }
    }
}
