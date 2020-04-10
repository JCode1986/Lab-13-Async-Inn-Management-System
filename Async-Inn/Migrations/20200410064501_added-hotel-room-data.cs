using Microsoft.EntityFrameworkCore.Migrations;

namespace Async_Inn.Migrations
{
    public partial class addedhotelroomdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "HotelID", "RoomNumber", "PetFriendly", "Rate", "RoomID" },
                values: new object[,]
                {
                    { 1, 123, true, 120m, 1 },
                    { 2, 220, false, 150m, 1 },
                    { 1, 101, false, 75m, 2 },
                    { 2, 111, true, 175m, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelID", "RoomNumber" },
                keyValues: new object[] { 1, 101 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelID", "RoomNumber" },
                keyValues: new object[] { 1, 123 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelID", "RoomNumber" },
                keyValues: new object[] { 2, 111 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelID", "RoomNumber" },
                keyValues: new object[] { 2, 220 });
        }
    }
}
