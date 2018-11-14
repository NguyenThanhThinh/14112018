using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _14112018.Contexts
{
    using _14112018.Domains;
    using _14112018.Contexts.Extensions;
    public class _14112018DbContext : DbContext
    {
        public _14112018DbContext(DbContextOptions<_14112018DbContext> options)
           : base(options)
        {

        }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
            builder.Entity<Topic>(b=>{
                b.ToTable("Topic");
                b.HasKey(p => p.Id);
            });
        }
    }
}
