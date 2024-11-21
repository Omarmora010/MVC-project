using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.DAL.Models.Department;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.CompilerServices;

namespace Route.DAL.Persistance.Data.Configrations.Departments
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Id).UseIdentityColumn(10, 10);
            builder.Property(D => D.Name).HasColumnType("varchar(50)").IsRequired();
            builder.Property(D => D.Code).HasColumnType("varchar(20)").IsRequired();
            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql(" GETDATE()");
        }
    }
}
 