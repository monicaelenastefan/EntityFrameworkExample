using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Infrastructure.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name);
            builder.Property(e => e.Surname);

            //builder.HasMany(x => x.Books)
            //    .WithOne(x => x.Student)
            //    .OnDelete(DeleteBehavior.ClientCascade);


            builder.ToTable("Students");
        }
    }
}