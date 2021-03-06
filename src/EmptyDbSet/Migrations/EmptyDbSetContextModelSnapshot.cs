﻿// <auto-generated />
using EmptyDbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmptyDbSet.Migrations
{
    [DbContext(typeof(EmptyDbSetContext))]
    partial class EmptyDbSetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DummyModels.DummyModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("DummyModel");
                });

            modelBuilder.Entity("DummyModels.DummyModel", b =>
                {
                    b.OwnsOne("DummyModels.OwnedModel", "OwnedModel", b1 =>
                        {
                            b1.Property<long>("DummyModelId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("RequiredField")
                                .IsRequired();

                            b1.HasKey("DummyModelId");

                            b1.ToTable("DummyModel");

                            b1.HasOne("DummyModels.DummyModel")
                                .WithOne("OwnedModel")
                                .HasForeignKey("DummyModels.OwnedModel", "DummyModelId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
