using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using VandelayWebAPI.Entities;

namespace VandelayWebAPI.Migrations
{
    public class FactoryContextModelSnapshot
    {

        [DbContext(typeof(FactoryContext))]
        partial class LibraryContextModelSnapshot : ModelSnapshot
        {
            protected override void BuildModel(ModelBuilder modelBuilder)
            {
                modelBuilder
                    .HasAnnotation("ProductVersion", "1.0.1")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                modelBuilder.Entity("VandelayWebAPI.Entities.Factory", b =>
                {
                    b.Property<int>("FactoryId");

                    b.Property<string>("FactoryName")
                        .IsRequired();

                    b.Property<string>("FactoryDescription")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("FactoryId");

                    b.ToTable("Factories");
                });

                modelBuilder.Entity("VandelayWebAPI.Entities.Machine", b =>
                {
                    b.Property<int>("MachineId");

                    b.Property<int>("FactoryId");

                    b.Property<string>("MachineName").IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("MachineDescription")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("MachineId");

                    b.HasIndex("FactoryId");

                    b.ToTable("Machines");
                });

                modelBuilder.Entity("VandelayWebAPI.Entities.Machine", b =>
                {
                    b.HasOne("VandelayWebAPI.Entities.Factory", "Factory")
                        .WithMany("Machines")
                        .HasForeignKey("FactoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
            }
        }
    }
}
