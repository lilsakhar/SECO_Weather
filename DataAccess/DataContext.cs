using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SECO_Weather.Models;

namespace SECO_Weather.DataAccess
{
    public class CityDbContext : DbContext
    {
        public CityDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<DAO> City { get; set; }
    }

}
