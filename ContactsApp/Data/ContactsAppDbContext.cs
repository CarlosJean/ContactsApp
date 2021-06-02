using ContactsApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp.Data {
    public class ContactsAppDbContext : DbContext{
        public ContactsAppDbContext(DbContextOptions<ContactsAppDbContext> options) : base(options) {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ContactContactType> ContactContactTypes { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            //Data seeding

                //Group
                modelBuilder.Entity<Group>().HasData(new Group { ID = 1, Name = "Familia" });
                modelBuilder.Entity<Group>().HasData(new Group { ID = 2, Name = "Amigos" });

                //Contact
                modelBuilder.Entity<Contact>().HasData(new Contact { ID = 1, Name = "Jean Carlos Holguin Berihuete", Email = "holguinjean1@gmail.com", GroupID = 1});
                modelBuilder.Entity<Contact>().HasData(new Contact { ID = 2, Name = "Jhanssel Holguin Berihuete", Email = "jhanssel@gmail.com", GroupID = 1 });

                //Contact types
                modelBuilder.Entity<ContactType>().HasData(new ContactType { ID = 1, Name = "Móvil"});
                modelBuilder.Entity<ContactType>().HasData(new ContactType { ID = 2, Name = "Trabajo"});

            //Contact - contact type
            modelBuilder.Entity<ContactContactType>().HasData(new ContactContactType { ID = 1, Number="8098854086", ContactID=1,ContactTypeID=1});
            modelBuilder.Entity<ContactContactType>().HasData(new ContactContactType { ID = 2, Number="8098854085", ContactID=1,ContactTypeID=2});
            modelBuilder.Entity<ContactContactType>().HasData(new ContactContactType { ID = 3, Number="8098854186", ContactID=2,ContactTypeID=1});
            modelBuilder.Entity<ContactContactType>().HasData(new ContactContactType { ID = 4, Number="8098854185", ContactID=2,ContactTypeID=2});

            //End Dataseeding2
        }
    }
}
