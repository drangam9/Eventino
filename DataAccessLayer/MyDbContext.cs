using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class MyDbContext : DbContext
    {
        private readonly string _windowsConnectionString = @"Data Source=DESKTOP-9JJKNRC;Database=TapDatabase;Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False";

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_windowsConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var userId = Guid.NewGuid();
            var event1Id = Guid.NewGuid();
            var event2Id = Guid.NewGuid();
            base.OnModelCreating(builder);

            builder.Entity<User>().HasData(
            new User
            {
                UserId = userId,
                EntraOid = Guid.NewGuid(),
                Email = "example@gmail.com",
                Name = "John Doe"
            });

            builder.Entity<Event>().HasData(new List<Event>()
            {

                                new Event
                                {
                    EventId = event1Id,
                    Title = "Grow Your Small Business On Instagram",
                    Description = "Want to learn how to grow your business on Instagram? Join Henry, BT's social media manager to learn how you can skyrocket your business on Instagram From content ideas, to hashtags, to new trends you should look out for, in this Masterclass, Henry will cover what you need to know in order to grow your business organically on Instagram ",
                    Location = "Online",
                    DateTime = DateTime.Now,
                    Duration = new TimeSpan(1, 30, 0),
                    OrganizerId = userId,
                    Price = 20
            },
                                new Event
                                {
                    EventId = event2Id,
                    Title = "Virtual Speaking Masterclass",
                    Description = "You have a glorious opportunity to get your message into the world.\r\n\r\nNever before has there been such an exciting time in communication.\r\n\r\nThe ability to transmit your words across the world has existed for decades.\r\n\r\nWhat has changed a result of COVID-19 is now people are LISTENING.\r\n\r\nVirtual communication has now been accepted as the norm.\r\n\r\nPeople know that they need to tune into the Facebook Lives and join the Zoom meetings otherwise they are going to be left out of the loop.\r\n\r\nThey are ready to hear your message.\r\n\r\nAre you ready to give it to them?\r\n\r\nYour phone and your computer are all you need to make a difference in the world.\r\n\r\nYou have a voice, it’s time to use it.\r\n\r\nYou have a story, it’s time to tell it.\r\n\r\nYou have a message, it’s time to share it.\r\n\r\nImagine being able to reach people in places you’ve never heard of and changing the lives of people you have never met.\r\n\r\nThat possibility is more real than ever thanks to virtual speaking.",
                    Location = "Yuri Gagarin Blvd 2001 Chişinău Moldova",
                    DateTime = DateTime.Now.AddDays(2),
                    Duration = new TimeSpan(2, 0, 0),
                    OrganizerId = userId,
                    Price = 0
                                }
                });

            builder.Entity<Ticket>().HasData(new List<Ticket>()
            {
                new Ticket
                {
                    TicketId = Guid.NewGuid(),
                    EventId = event1Id,
                    UserId = userId,
                    Type = "Premium",
                    Price = 20,
                    Quantity = 3
                },
                new Ticket
                {
                    TicketId = Guid.NewGuid(),
                    EventId = event2Id,
                    UserId = userId,
                    Type = "Regular",
                    Price = 0,
                    Quantity = 1
                }
            });



        }
    }
}
