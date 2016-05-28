using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace FletNix.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
//            migrationBuilder.CreateTable(
//                name: "Customer",
//                columns: table => new
//                {
//                    customer_mail_address = table.Column<string>(type: "varchar", nullable: false),
//                    name = table.Column<string>(type: "varchar", nullable: false),
//                    password = table.Column<string>(type: "varchar", nullable: false),
//                    paypal_account = table.Column<string>(type: "varchar", nullable: false),
//                    subscription_end = table.Column<DateTime>(type: "date", nullable: true),
//                    subscription_start = table.Column<DateTime>(type: "date", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Customer", x => x.customer_mail_address);
//                });
//            migrationBuilder.CreateTable(
//                name: "AspNetUsers",
//                columns: table => new
//                {
//                    Id = table.Column<string>(nullable: false),
//                    AccessFailedCount = table.Column<int>(nullable: false),
//                    ConcurrencyStamp = table.Column<string>(nullable: true),
//                    Email = table.Column<string>(nullable: true),
//                    EmailConfirmed = table.Column<bool>(nullable: false),
//                    LastOnline = table.Column<DateTime>(nullable: false),
//                    LockoutEnabled = table.Column<bool>(nullable: false),
//                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
//                    NormalizedEmail = table.Column<string>(nullable: true),
//                    NormalizedUserName = table.Column<string>(nullable: true),
//                    PasswordHash = table.Column<string>(nullable: true),
//                    PhoneNumber = table.Column<string>(nullable: true),
//                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
//                    SecurityStamp = table.Column<string>(nullable: true),
//                    TwoFactorEnabled = table.Column<bool>(nullable: false),
//                    UserName = table.Column<string>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_FletNixUser", x => x.Id);
//                });
//            migrationBuilder.CreateTable(
//                name: "Genre",
//                columns: table => new
//                {
//                    genre_name = table.Column<string>(type: "varchar", nullable: false),
//                    description = table.Column<string>(type: "varchar", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Genre", x => x.genre_name);
//                });
//            migrationBuilder.CreateTable(
//                name: "Movie",
//                columns: table => new
//                {
//                    movie_id = table.Column<int>(nullable: false),
//                    URL = table.Column<string>(type: "varchar", nullable: true),
//                    cover_image = table.Column<byte[]>(type: "image", nullable: true),
//                    description = table.Column<string>(type: "varchar", nullable: true),
//                    duration = table.Column<int>(nullable: true),
//                    minimum_age = table.Column<int>(nullable: true),
//                    previous_part = table.Column<int>(nullable: true),
//                    price = table.Column<decimal>(type: "numeric", nullable: false),
//                    publication_year = table.Column<int>(nullable: true),
//                    title = table.Column<string>(type: "varchar", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Movie", x => x.movie_id);
//                    table.ForeignKey(
//                        name: "FK_Movie_Movie_previous_part",
//                        column: x => x.previous_part,
//                        principalTable: "Movie",
//                        principalColumn: "movie_id",
//                        onDelete: ReferentialAction.Restrict);
//                });
//            migrationBuilder.CreateTable(
//                name: "Person",
//                columns: table => new
//                {
//                    person_id = table.Column<int>(nullable: false),
//                    firstname = table.Column<string>(type: "varchar", nullable: false),
//                    gender = table.Column<string>(type: "char", nullable: true),
//                    lastname = table.Column<string>(type: "varchar", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Person", x => x.person_id);
//                });
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserClaim<string>_FletNixUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin<string>", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_IdentityUserLogin<string>_FletNixUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
//            migrationBuilder.CreateTable(
//                name: "CustomerFeedback",
//                columns: table => new
//                {
//                    movie_id = table.Column<int>(nullable: false),
//                    customer_mail_address = table.Column<string>(type: "varchar", nullable: false),
//                    comments = table.Column<string>(type: "varchar", nullable: false),
//                    feedback_date = table.Column<DateTime>(type: "date", nullable: false),
//                    rating = table.Column<int>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_CustomerFeedback", x => new { x.movie_id, x.customer_mail_address });
//                    table.ForeignKey(
//                        name: "FK_CustomerFeedback_Customer_customer_mail_address",
//                        column: x => x.customer_mail_address,
//                        principalTable: "Customer",
//                        principalColumn: "customer_mail_address",
//                        onDelete: ReferentialAction.Restrict);
//                    table.ForeignKey(
//                        name: "FK_CustomerFeedback_Movie_movie_id",
//                        column: x => x.movie_id,
//                        principalTable: "Movie",
//                        principalColumn: "movie_id",
//                        onDelete: ReferentialAction.Restrict);
//                });
//            migrationBuilder.CreateTable(
//                name: "Movie_Genre",
//                columns: table => new
//                {
//                    movie_id = table.Column<int>(nullable: false),
//                    genre_name = table.Column<string>(type: "varchar", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Movie_Genre", x => new { x.movie_id, x.genre_name });
//                    table.ForeignKey(
//                        name: "FK_Movie_Genre_Genre_genre_name",
//                        column: x => x.genre_name,
//                        principalTable: "Genre",
//                        principalColumn: "genre_name",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_Movie_Genre_Movie_movie_id",
//                        column: x => x.movie_id,
//                        principalTable: "Movie",
//                        principalColumn: "movie_id",
//                        onDelete: ReferentialAction.Cascade);
//                });
//            migrationBuilder.CreateTable(
//                name: "MovieAwards",
//                columns: table => new
//                {
//                    movie_id = table.Column<int>(nullable: false),
//                    award = table.Column<string>(type: "varchar", nullable: false),
//                    result = table.Column<string>(type: "varchar", nullable: false),
//                    number_of_awards = table.Column<string>(type: "varchar", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_MovieAwards", x => new { x.movie_id, x.award, x.result });
//                    table.ForeignKey(
//                        name: "FK_MovieAwards_Movie_movie_id",
//                        column: x => x.movie_id,
//                        principalTable: "Movie",
//                        principalColumn: "movie_id",
//                        onDelete: ReferentialAction.Restrict);
//                });
//            migrationBuilder.CreateTable(
//                name: "Watchhistory",
//                columns: table => new
//                {
//                    movie_id = table.Column<int>(nullable: false),
//                    customer_mail_address = table.Column<string>(type: "varchar", nullable: false),
//                    watch_date = table.Column<DateTime>(type: "date", nullable: false),
//                    invoiced = table.Column<bool>(nullable: false),
//                    price = table.Column<decimal>(type: "numeric", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Watchhistory", x => new { x.movie_id, x.customer_mail_address, x.watch_date });
//                    table.ForeignKey(
//                        name: "FK_Watchhistory_Customer_customer_mail_address",
//                        column: x => x.customer_mail_address,
//                        principalTable: "Customer",
//                        principalColumn: "customer_mail_address",
//                        onDelete: ReferentialAction.Restrict);
//                    table.ForeignKey(
//                        name: "FK_Watchhistory_Movie_movie_id",
//                        column: x => x.movie_id,
//                        principalTable: "Movie",
//                        principalColumn: "movie_id",
//                        onDelete: ReferentialAction.Restrict);
//                });
//            migrationBuilder.CreateTable(
//                name: "Movie_Cast",
//                columns: table => new
//                {
//                    movie_id = table.Column<int>(nullable: false),
//                    person_id = table.Column<int>(nullable: false),
//                    role = table.Column<string>(type: "varchar", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Movie_Cast", x => new { x.movie_id, x.person_id, x.role });
//                    table.ForeignKey(
//                        name: "FK_Movie_Cast_Movie_movie_id",
//                        column: x => x.movie_id,
//                        principalTable: "Movie",
//                        principalColumn: "movie_id",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_Movie_Cast_Person_person_id",
//                        column: x => x.person_id,
//                        principalTable: "Person",
//                        principalColumn: "person_id",
//                        onDelete: ReferentialAction.Cascade);
//                });
//            migrationBuilder.CreateTable(
//                name: "Movie_Director",
//                columns: table => new
//                {
//                    movie_id = table.Column<int>(nullable: false),
//                    person_id = table.Column<int>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Movie_Director", x => new { x.movie_id, x.person_id });
//                    table.ForeignKey(
//                        name: "FK_Movie_Director_Movie_movie_id",
//                        column: x => x.movie_id,
//                        principalTable: "Movie",
//                        principalColumn: "movie_id",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_Movie_Director_Person_person_id",
//                        column: x => x.person_id,
//                        principalTable: "Person",
//                        principalColumn: "person_id",
//                        onDelete: ReferentialAction.Cascade);
//                });
//            migrationBuilder.CreateTable(
//                name: "AspNetRoleClaims",
//                columns: table => new
//                {
//                    Id = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    ClaimType = table.Column<string>(nullable: true),
//                    ClaimValue = table.Column<string>(nullable: true),
//                    RoleId = table.Column<string>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_IdentityRoleClaim<string>", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
//                        column: x => x.RoleId,
//                        principalTable: "AspNetRoles",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });
//            migrationBuilder.CreateTable(
//                name: "AspNetUserRoles",
//                columns: table => new
//                {
//                    UserId = table.Column<string>(nullable: false),
//                    RoleId = table.Column<string>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_IdentityUserRole<string>", x => new { x.UserId, x.RoleId });
//                    table.ForeignKey(
//                        name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
//                        column: x => x.RoleId,
//                        principalTable: "AspNetRoles",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_IdentityUserRole<string>_FletNixUser_UserId",
//                        column: x => x.UserId,
//                        principalTable: "AspNetUsers",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });
//            migrationBuilder.CreateIndex(
//                name: "AK_Customer_Paypal",
//                table: "Customer",
//                column: "paypal_account",
//                unique: true);
//            migrationBuilder.CreateIndex(
//                name: "EmailIndex",
//                table: "AspNetUsers",
//                column: "NormalizedEmail");
//            migrationBuilder.CreateIndex(
//                name: "UserNameIndex",
//                table: "AspNetUsers",
//                column: "NormalizedUserName");
//            migrationBuilder.CreateIndex(
//                name: "RoleNameIndex",
//                table: "AspNetRoles",
//                column: "NormalizedName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
//            migrationBuilder.DropTable("CustomerFeedback");
//            migrationBuilder.DropTable("Movie_Cast");
//            migrationBuilder.DropTable("Movie_Director");
//            migrationBuilder.DropTable("Movie_Genre");
//            migrationBuilder.DropTable("MovieAwards");
//            migrationBuilder.DropTable("Watchhistory");
//            migrationBuilder.DropTable("AspNetRoleClaims");
//            migrationBuilder.DropTable("AspNetUserClaims");
//            migrationBuilder.DropTable("AspNetUserLogins");
//            migrationBuilder.DropTable("AspNetUserRoles");
//            migrationBuilder.DropTable("Person");
//            migrationBuilder.DropTable("Genre");
//            migrationBuilder.DropTable("Customer");
//            migrationBuilder.DropTable("Movie");
//            migrationBuilder.DropTable("AspNetRoles");
//            migrationBuilder.DropTable("AspNetUsers");
        }
    }
}
