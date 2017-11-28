using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public class FileStorageDbContext : IdentityDbContext<User>
    {
        public DbSet<UserFileInfo> FilesInfo { get; set; }
        public DbSet<UserFileContent> FilesContent { get; set; }
        //public DbSet<SharedFile> FilesShared { get; set; }

        public FileStorageDbContext(DbContextOptions<FileStorageDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
