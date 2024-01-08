using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.Migrations
{
    /// <inheritdoc />
    public partial class Amine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "1",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    text = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "AIusers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp", nullable: false, defaultValueSql: "current_timestamp()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp", nullable: false, defaultValueSql: "current_timestamp()")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cartier",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    libelle = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "pcs",
                columns: table => new
                {
                    pcid = table.Column<int>(name: "pc_id", type: "int(11)", nullable: false),
                    status = table.Column<string>(type: "enum('available','in_use','out_use')", nullable: false, defaultValueSql: "'available'", collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    starttime = table.Column<DateTime>(name: "start_time", type: "datetime", nullable: true),
                    endtime = table.Column<DateTime>(name: "end_time", type: "datetime", nullable: true),
                    price = table.Column<int>(type: "int(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.pcid);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "point_de_recherche",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    neighborhood = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lattitude = table.Column<double>(type: "double", nullable: false),
                    longitude = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "ps4s",
                columns: table => new
                {
                    ps4id = table.Column<int>(name: "ps4_id", type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<string>(type: "enum('available','in_use','out_use')", nullable: false, defaultValueSql: "'available'", collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    starttime = table.Column<DateTime>(name: "start_time", type: "datetime", nullable: true),
                    endtime = table.Column<DateTime>(name: "end_time", type: "datetime", nullable: true),
                    price = table.Column<int>(type: "int(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ps4id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "audio_data",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    text = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    audio = table.Column<byte[]>(type: "blob", nullable: true),
                    AIuserId = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "fk_AIuserId",
                        column: x => x.AIuserId,
                        principalTable: "AIusers",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "BannedUsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userid = table.Column<int>(name: "user_id", type: "int(11)", nullable: false),
                    reason = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bannedat = table.Column<DateTime>(name: "banned_at", type: "timestamp", nullable: false, defaultValueSql: "current_timestamp()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "BannedUsers_ibfk_1",
                        column: x => x.userid,
                        principalTable: "AIusers",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "border_cartier",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    lattitude = table.Column<double>(type: "double", nullable: false),
                    longitude = table.Column<double>(type: "double", nullable: false),
                    idcartier = table.Column<int>(name: "id_cartier", type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "border_cartier_ibfk_1",
                        column: x => x.idcartier,
                        principalTable: "cartier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    Idstudent = table.Column<int>(name: "Id_student", type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prenom = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cen = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cin = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tel = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adresse = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Etat = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cartier = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Idstudent);
                    table.ForeignKey(
                        name: "student_ibfk_1",
                        column: x => x.cartier,
                        principalTable: "cartier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "point_cartier",
                columns: table => new
                {
                    IdCartier = table.Column<int>(type: "int(11)", nullable: false),
                    PointDeRecherche = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.IdCartier, x.PointDeRecherche })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "point_cartier_ibfk_1",
                        column: x => x.IdCartier,
                        principalTable: "cartier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "point_cartier_ibfk_2",
                        column: x => x.PointDeRecherche,
                        principalTable: "point_de_recherche",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "abonnement",
                columns: table => new
                {
                    Idabonnement = table.Column<int>(name: "Id_abonnement", type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Typeabonnement = table.Column<string>(name: "Type_abonnement", type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Datedecreation = table.Column<DateOnly>(name: "Date_de_creation", type: "date", nullable: false),
                    Solde = table.Column<double>(type: "double", nullable: false),
                    StudentId = table.Column<int>(name: "Student_Id", type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Idabonnement);
                    table.ForeignKey(
                        name: "abonnement_ibfk_1",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "Id_student");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "historique",
                columns: table => new
                {
                    Idhistorique = table.Column<int>(name: "Id_historique", type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Heuremonter = table.Column<TimeOnly>(name: "Heure_monter", type: "time", nullable: false),
                    Studentid = table.Column<int>(name: "Student_id", type: "int(11)", nullable: false),
                    Busid = table.Column<int>(name: "Bus_id", type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Idhistorique);
                    table.ForeignKey(
                        name: "historique_ibfk_1",
                        column: x => x.Studentid,
                        principalTable: "student",
                        principalColumn: "Id_student");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "abonnement/ligne",
                columns: table => new
                {
                    Idabnligne = table.Column<int>(name: "Id_abn_ligne", type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Abonnementid = table.Column<int>(name: "Abonnement_id", type: "int(11)", nullable: false),
                    Ligneid = table.Column<int>(name: "Ligne_id", type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Idabnligne);
                    table.ForeignKey(
                        name: "abonnement/ligne_ibfk_2",
                        column: x => x.Abonnementid,
                        principalTable: "abonnement",
                        principalColumn: "Id_abonnement");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "student_Id",
                table: "abonnement",
                column: "Student_Id");

            migrationBuilder.CreateIndex(
                name: "abonnement_id",
                table: "abonnement/ligne",
                column: "Abonnement_id");

            migrationBuilder.CreateIndex(
                name: "username",
                table: "AIusers",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_AIuserId",
                table: "audio_data",
                column: "AIuserId");

            migrationBuilder.CreateIndex(
                name: "user_id",
                table: "BannedUsers",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "id_cartier1",
                table: "border_cartier",
                column: "id_cartier");

            migrationBuilder.CreateIndex(
                name: "Student_id",
                table: "historique",
                column: "Student_id");

            migrationBuilder.CreateIndex(
                name: "id_cartier",
                table: "point_cartier",
                column: "IdCartier");

            migrationBuilder.CreateIndex(
                name: "point_de_recherche",
                table: "point_cartier",
                column: "PointDeRecherche");

            migrationBuilder.CreateIndex(
                name: "cartier",
                table: "student",
                column: "cartier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "1");

            migrationBuilder.DropTable(
                name: "abonnement/ligne");

            migrationBuilder.DropTable(
                name: "audio_data");

            migrationBuilder.DropTable(
                name: "BannedUsers");

            migrationBuilder.DropTable(
                name: "border_cartier");

            migrationBuilder.DropTable(
                name: "historique");

            migrationBuilder.DropTable(
                name: "pcs");

            migrationBuilder.DropTable(
                name: "point_cartier");

            migrationBuilder.DropTable(
                name: "ps4s");

            migrationBuilder.DropTable(
                name: "abonnement");

            migrationBuilder.DropTable(
                name: "AIusers");

            migrationBuilder.DropTable(
                name: "point_de_recherche");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "cartier");
        }
    }
}
