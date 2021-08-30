using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OneToOneRelation.Models
{
    
    public class DataContext : DbContext
    {
            public DataContext(DbContextOptions<DataContext> options) : base(options)
            {
            }
             public DbSet<Employee> employee { get; set; }
              public DbSet<Department> departments { get; set; }

               public override int SaveChanges()
               {

                   foreach (var entry in ChangeTracker.Entries())
                   {
                          var entity = entry.Entity;

                         if (entry.State == EntityState.Deleted)
                         {
                               entry.State = EntityState.Modified;

                               entity.GetType().GetProperty("DelStatus").SetValue(entity, 'D');
                         }
                   }

                  return base.SaveChanges();
               }

    }
}

