using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ESHClouds.ApiCenter.StoreHouse.Model
{
    public class BulletineContext : DbContext
    {
        public BulletineContext(DbContextOptions<BulletineContext> options)
            : base(options)
        {

        }
        public DbSet<Bulletine> Bulletines { get; set; }
    }
}
