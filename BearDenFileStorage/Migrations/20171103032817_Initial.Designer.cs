using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BearDenFileStorage;

namespace BearDenFileStorage.Migrations
{
    [DbContext(typeof(FileStorageDbContext))]
    [Migration("20171103032817_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BearDenFileStorage.UserFileContent", b =>
                {
                    b.Property<Guid>("FileId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentType");

                    b.Property<byte[]>("FileContent");

                    b.HasKey("FileId");

                    b.ToTable("FilesContent");
                });

            modelBuilder.Entity("BearDenFileStorage.UserFileInfo", b =>
                {
                    b.Property<Guid>("FileId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Filename");

                    b.Property<DateTime>("LastEdit");

                    b.Property<string>("Owner");

                    b.Property<long>("Size");

                    b.Property<DateTime>("UploadTime");

                    b.HasKey("FileId");

                    b.ToTable("FilesInfo");
                });
        }
    }
}
