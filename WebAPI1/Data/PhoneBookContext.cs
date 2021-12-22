using WebAPI1.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace WebAPI1.Data
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> opt) : base(opt)
        {

        }
        public DbSet<Contact> Contacts  { get; set; }
        public DbSet<Address> Addresses  { get; set; }
        public DbSet<Phone> Phones  { get; set; }
        public DbSet<Group> Groups  { get; set; }
        public DbSet<GroupToPerson> GroupToPersons  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string server = "", dbName = "", pass = "";
            //StreamReader sr = new StreamReader("config.txt");

            //string line;
            //while ((line = sr.ReadLine()) != null)
            //{
            //    string[] data = line.Split(',');
            //    server = data[0];
            //    dbName = data[1];
            //    pass = data[2];
            //}
            optionsBuilder.UseSqlServer(@$"Server=LDJORDJEVI-L340;Initial Catalog=PhoneBookDB;User ID=sa;Password=1sInforce3512;");
              
            }
        }
    }

