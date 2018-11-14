using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _14112018.Contexts.Extensions
{
    public class _11142018DbContextFactory : IDesignTimeDbContextFactory<_14112018DbContext>
    {
        public _14112018DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<_14112018DbContext>();

            builder.UseSqlServer(@"Server=THINH\SQLEXPRESS;Database=11142018;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new _14112018DbContext(builder.Options);
        }
    }
}
