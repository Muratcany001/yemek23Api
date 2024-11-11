using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiYemek23.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Restaurant_EmployeeCount",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "Restaurant_Score",
                table: "Restaurants",
                newName: "Restaurant_Rating");

            migrationBuilder.AddColumn<string>(
                name: "Restaurant_Coordinates",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Restaurant_Location",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Restaurant_Phone_Number",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Restaurant_Coordinates",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Restaurant_Location",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Restaurant_Phone_Number",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "Restaurant_Rating",
                table: "Restaurants",
                newName: "Restaurant_Score");

            migrationBuilder.AddColumn<int>(
                name: "Restaurant_EmployeeCount",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
