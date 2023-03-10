// <auto-generated />
using System;
using DirectoryExplorer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DirectoryExplorer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230307194909_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DirectoryExplorer.Models.DirectoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentDirectoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentDirectoryId");

                    b.ToTable("Directories");
                });

            modelBuilder.Entity("DirectoryExplorer.Models.DirectoryModel", b =>
                {
                    b.HasOne("DirectoryExplorer.Models.DirectoryModel", "ParentDirectory")
                        .WithMany("ChildDirectories")
                        .HasForeignKey("ParentDirectoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParentDirectory");
                });

            modelBuilder.Entity("DirectoryExplorer.Models.DirectoryModel", b =>
                {
                    b.Navigation("ChildDirectories");
                });
#pragma warning restore 612, 618
        }
    }
}
