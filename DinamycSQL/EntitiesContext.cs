using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinamycSQL
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext() : base("FXDbContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("FXUSER");

            base.OnModelCreating(modelBuilder);
        }
    }
}
