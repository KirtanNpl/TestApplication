using Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.Entity.Employee;

namespace Infrastructure.Context
{
   public class AppDbContext: DbContext
     {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<QualificationList> QualificationList { get; set; }
        //public DbSet<EmployeeQualification> EmployeeQualification { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<EmployeeQualification>(
            //        eb => {
            //            eb.HasNoKey();
            //        });
            base.OnModelCreating(modelBuilder);

        }



    }
}
