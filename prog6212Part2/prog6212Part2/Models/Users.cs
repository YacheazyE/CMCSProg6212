using System.Data.Entity;
using System.Xml;

namespace prog6212Part2.Models
{
    public class Users : DbContext
    {

        public Users(DbContextOptions<User> options) : base(options) { }

        public DbSet<Users> Users { get; set; }

    }

    public class Users { 
        public UniqueId UserID
    }








}
