using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DDACMaerskCMS.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserTokenCache> UserTokenCacheList { get; set; }

        public System.Data.Entity.DbSet<DDACMaerskCMS.Models.Ship> Ships { get; set; }

        public System.Data.Entity.DbSet<DDACMaerskCMS.Models.Container> Containers { get; set; }

        public System.Data.Entity.DbSet<DDACMaerskCMS.Models.YardLocation> YardLocations { get; set; }

        public System.Data.Entity.DbSet<DDACMaerskCMS.Models.ContainerShippingSchedule> ContainerShippingSchedules { get; set; }
    }

    public class UserTokenCache
    {
        [Key]
        public int UserTokenCacheId { get; set; }
        public string webUserUniqueId { get; set; }
        public byte[] cacheBits { get; set; }
        public DateTime LastWrite { get; set; }
    }
}