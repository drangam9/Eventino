using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
	/// <inheritdoc />
	public partial class tickets : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "TestModels");

			migrationBuilder.CreateTable(
				name: "Tickets",
				columns: table => new
				{
					TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Quantity = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Tickets", x => x.TicketId);
					table.ForeignKey(
						name: "FK_Tickets_Events_EventId",
						column: x => x.EventId,
						principalTable: "Events",
						principalColumn: "EventId",
						onDelete: ReferentialAction.NoAction);
					table.ForeignKey(
						name: "FK_Tickets_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "UserId",
						onDelete: ReferentialAction.NoAction);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Tickets_EventId",
				table: "Tickets",
				column: "EventId");

			migrationBuilder.CreateIndex(
				name: "IX_Tickets_UserId",
				table: "Tickets",
				column: "UserId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Tickets");

			migrationBuilder.CreateTable(
				name: "TestModels",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TestModels", x => x.Id);
				});
		}
	}
}
