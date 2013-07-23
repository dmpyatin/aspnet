using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using EfRepPatTest.Entity;

namespace EfRepPatTest.Data.Mapping
{
    class SpaceMap : EntityTypeConfiguration<Space>
    {
        public SpaceMap()
        {
            ToTable("Space");
            HasKey(c => c.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name).IsRequired().HasMaxLength(50);
        }
    }
}
