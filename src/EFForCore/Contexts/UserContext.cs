using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EFForCore.Contexts
{
    public class User
    {
        [Required]
        public int? id { get; set; }
        public string nickname { get; set; }
        public List<Item> items { get; set; }
    }

    public class Item
    {
        [Key]
        public int? item_dbid { get; set; }
        public int item_type { get; set; }
    }

    public class UserContext : DbContext
    {
        public DbSet<User> tb_user { get; set; }
        public DbSet<Item> tb_item { get; set; }

        public UserContext(DbContextOptions options) : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // implement when you need it.
        }
    }
}
