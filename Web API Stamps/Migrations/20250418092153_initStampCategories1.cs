using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_API_Stamps.Migrations
{
    /// <inheritdoc />
    public partial class initStampCategories1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImagesData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    StampId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThumbnailsData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    StampId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThumbnailsData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stamps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StampName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfIssue = table.Column<int>(type: "int", nullable: true),
                    CatalogNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Watermark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaceValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrintMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rarity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StampSeries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoricalSignificance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provenance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailDataBase64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StampCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stamps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stamps_Categories_StampCategoryId",
                        column: x => x.StampCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stamps_StampCategoryId",
                table: "Stamps",
                column: "StampCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagesData");

            migrationBuilder.DropTable(
                name: "Stamps");

            migrationBuilder.DropTable(
                name: "ThumbnailsData");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
