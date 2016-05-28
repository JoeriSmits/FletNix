using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace FletNix.Migrations
{
    public partial class IdentityEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "Movie_Cast_Movie_movie_id_fk", table: "Movie_Cast");
            migrationBuilder.DropForeignKey(name: "FK2_person_id", table: "Movie_Cast");
            migrationBuilder.DropForeignKey(name: "FK_movie_id", table: "Movie_Director");
            migrationBuilder.DropForeignKey(name: "FK_person_id", table: "Movie_Director");
            migrationBuilder.DropForeignKey(name: "FK3_movie_id", table: "Movie_Genre");
            migrationBuilder.DropForeignKey(name: "FK_genre", table: "Movie_Genre");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_FletNixUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_FletNixUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_FletNixUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Cast_Movie_movie_id",
                table: "Movie_Cast",
                column: "movie_id",
                principalTable: "Movie",
                principalColumn: "movie_id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Cast_Person_person_id",
                table: "Movie_Cast",
                column: "person_id",
                principalTable: "Person",
                principalColumn: "person_id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Director_Movie_movie_id",
                table: "Movie_Director",
                column: "movie_id",
                principalTable: "Movie",
                principalColumn: "movie_id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Director_Person_person_id",
                table: "Movie_Director",
                column: "person_id",
                principalTable: "Person",
                principalColumn: "person_id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Genre_Genre_genre_name",
                table: "Movie_Genre",
                column: "genre_name",
                principalTable: "Genre",
                principalColumn: "genre_name",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Genre_Movie_movie_id",
                table: "Movie_Genre",
                column: "movie_id",
                principalTable: "Movie",
                principalColumn: "movie_id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_FletNixUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_FletNixUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_FletNixUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Movie_Cast_Movie_movie_id", table: "Movie_Cast");
            migrationBuilder.DropForeignKey(name: "FK_Movie_Cast_Person_person_id", table: "Movie_Cast");
            migrationBuilder.DropForeignKey(name: "FK_Movie_Director_Movie_movie_id", table: "Movie_Director");
            migrationBuilder.DropForeignKey(name: "FK_Movie_Director_Person_person_id", table: "Movie_Director");
            migrationBuilder.DropForeignKey(name: "FK_Movie_Genre_Genre_genre_name", table: "Movie_Genre");
            migrationBuilder.DropForeignKey(name: "FK_Movie_Genre_Movie_movie_id", table: "Movie_Genre");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_FletNixUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_FletNixUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_FletNixUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Cast_Movie_movie_id",
                table: "Movie_Cast",
                column: "movie_id",
                principalTable: "Movie",
                principalColumn: "movie_id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Cast_Person_person_id",
                table: "Movie_Cast",
                column: "person_id",
                principalTable: "Person",
                principalColumn: "person_id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Director_Movie_movie_id",
                table: "Movie_Director",
                column: "movie_id",
                principalTable: "Movie",
                principalColumn: "movie_id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Director_Person_person_id",
                table: "Movie_Director",
                column: "person_id",
                principalTable: "Person",
                principalColumn: "person_id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Genre_Genre_genre_name",
                table: "Movie_Genre",
                column: "genre_name",
                principalTable: "Genre",
                principalColumn: "genre_name",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Genre_Movie_movie_id",
                table: "Movie_Genre",
                column: "movie_id",
                principalTable: "Movie",
                principalColumn: "movie_id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_FletNixUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_FletNixUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_FletNixUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
