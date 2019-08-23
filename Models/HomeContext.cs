using System;
using Microsoft.EntityFrameworkCore;

namespace gorillatree.Models
{
    public class HomeContext : DbContext //homecontext extended from dbcontext
    {
        public HomeContext(DbContextOptions options) : base(options) {} //allows our options to work
        
        public DbSet<User> Users { get; set; } //squiggly goes away when you create a user model
        public DbSet<Tree> Trees {get;set;}

        
    }
}