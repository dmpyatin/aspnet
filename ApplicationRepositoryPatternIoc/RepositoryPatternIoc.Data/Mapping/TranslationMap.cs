using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using EfRepPatTest.Entity;

namespace EfRepPatTest.Data.Mapping
{
    class TranslationMap : EntityTypeConfiguration<Translation>
    {
        public TranslationMap()
        {
            ToTable("Translation");
            HasKey(p => p.Id).Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //CategoryId as foreign key
            HasRequired(p => p.Culture)
                .WithMany(c=>c.Translations)
                .HasForeignKey(p => p.CultureId);
            Property(p => p.Name).IsRequired().HasMaxLength(100);
            Property(p => p.Text);

            HasMany(c => c.Spaces).
                WithMany(p => p.Translations).
                Map(m =>
                {
                    m.MapLeftKey("Translation_Id");
                    m.MapRightKey("Space_Id");
                    m.ToTable("TranslationsToSpaces");
                });
      
        }
    }
}
