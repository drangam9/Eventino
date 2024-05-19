using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "EntraOid", "Name" },
                values: new object[] { new Guid("c807e923-3b29-4f69-961c-b036904e7e6d"), "example@gmail.com", new Guid("9c9e35cd-5396-4bd2-be7e-502beb1747d0"), "John Doe" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "DateTime", "Description", "Duration", "Location", "OrganizerId", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("694f39d3-7b5f-40cf-b57d-73ff8aa4becf"), new DateTime(2024, 5, 21, 11, 59, 42, 652, DateTimeKind.Local).AddTicks(5380), "You have a glorious opportunity to get your message into the world.\r\n\r\nNever before has there been such an exciting time in communication.\r\n\r\nThe ability to transmit your words across the world has existed for decades.\r\n\r\nWhat has changed a result of COVID-19 is now people are LISTENING.\r\n\r\nVirtual communication has now been accepted as the norm.\r\n\r\nPeople know that they need to tune into the Facebook Lives and join the Zoom meetings otherwise they are going to be left out of the loop.\r\n\r\nThey are ready to hear your message.\r\n\r\nAre you ready to give it to them?\r\n\r\nYour phone and your computer are all you need to make a difference in the world.\r\n\r\nYou have a voice, it’s time to use it.\r\n\r\nYou have a story, it’s time to tell it.\r\n\r\nYou have a message, it’s time to share it.\r\n\r\nImagine being able to reach people in places you’ve never heard of and changing the lives of people you have never met.\r\n\r\nThat possibility is more real than ever thanks to virtual speaking.", new TimeSpan(0, 2, 0, 0, 0), "Yuri Gagarin Blvd 2001 Chişinău Moldova", new Guid("c807e923-3b29-4f69-961c-b036904e7e6d"), 0m, "Virtual Speaking Masterclass" },
                    { new Guid("fbf567f0-0a45-49dd-a698-ef917db245a2"), new DateTime(2024, 5, 19, 11, 59, 42, 652, DateTimeKind.Local).AddTicks(5311), "Want to learn how to grow your business on Instagram? Join Henry, BT's social media manager to learn how you can skyrocket your business on Instagram From content ideas, to hashtags, to new trends you should look out for, in this Masterclass, Henry will cover what you need to know in order to grow your business organically on Instagram ", new TimeSpan(0, 1, 30, 0, 0), "Online", new Guid("c807e923-3b29-4f69-961c-b036904e7e6d"), 20m, "Grow Your Small Business On Instagram" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "EventId", "Price", "Quantity", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("136c240b-6e9a-4803-8033-2b5aba4efd66"), new Guid("694f39d3-7b5f-40cf-b57d-73ff8aa4becf"), 0m, 1, "Regular", new Guid("c807e923-3b29-4f69-961c-b036904e7e6d") },
                    { new Guid("b43a0c0d-0c54-4cbb-9a41-2f834c493c26"), new Guid("fbf567f0-0a45-49dd-a698-ef917db245a2"), 20m, 3, "Premium", new Guid("c807e923-3b29-4f69-961c-b036904e7e6d") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("136c240b-6e9a-4803-8033-2b5aba4efd66"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("b43a0c0d-0c54-4cbb-9a41-2f834c493c26"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("694f39d3-7b5f-40cf-b57d-73ff8aa4becf"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("fbf567f0-0a45-49dd-a698-ef917db245a2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("c807e923-3b29-4f69-961c-b036904e7e6d"));
        }
    }
}
