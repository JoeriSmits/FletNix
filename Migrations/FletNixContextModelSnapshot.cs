using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using FletNix.Models;

namespace FletNix.Migrations
{
    [DbContext(typeof(FletNixContext))]
    partial class FletNixContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FletNix.Models.Customer", b =>
                {
                    b.Property<string>("customer_mail_address")
                        .HasAnnotation("MaxLength", 255)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.Property<string>("paypal_account")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.Property<DateTime?>("subscription_end")
                        .HasAnnotation("Relational:ColumnType", "date");

                    b.Property<DateTime>("subscription_start")
                        .HasAnnotation("Relational:ColumnType", "date");

                    b.HasKey("customer_mail_address");

                    b.HasIndex("paypal_account")
                        .IsUnique()
                        .HasAnnotation("Relational:Name", "AK_Customer_Paypal");
                });

            modelBuilder.Entity("FletNix.Models.CustomerFeedback", b =>
                {
                    b.Property<int>("movie_id");

                    b.Property<string>("customer_mail_address")
                        .HasAnnotation("MaxLength", 255)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.Property<string>("comments")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.Property<DateTime>("feedback_date")
                        .HasAnnotation("Relational:ColumnType", "date");

                    b.Property<int>("rating");

                    b.HasKey("movie_id", "customer_mail_address");
                });

            modelBuilder.Entity("FletNix.Models.FletNixUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<DateTime>("LastOnline");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("FletNix.Models.Genre", b =>
                {
                    b.Property<string>("genre_name")
                        .HasAnnotation("MaxLength", 50)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.Property<string>("description")
                        .HasAnnotation("MaxLength", 255)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.HasKey("genre_name");
                });

            modelBuilder.Entity("FletNix.Models.Movie", b =>
                {
                    b.Property<int>("movie_id");

                    b.Property<string>("URL")
                        .HasAnnotation("MaxLength", 255)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.Property<byte[]>("cover_image")
                        .HasAnnotation("Relational:ColumnType", "image");

                    b.Property<string>("description")
                        .HasAnnotation("MaxLength", 255)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.Property<int?>("duration");

                    b.Property<int?>("minimum_age");

                    b.Property<int?>("previous_part");

                    b.Property<decimal>("price")
                        .HasAnnotation("Relational:ColumnType", "numeric");

                    b.Property<int?>("publication_year");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.HasKey("movie_id");
                });

            modelBuilder.Entity("FletNix.Models.Movie_Cast", b =>
                {
                    b.Property<int>("movie_id");

                    b.Property<int>("person_id");

                    b.Property<string>("role")
                        .HasAnnotation("MaxLength", 255)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.HasKey("movie_id", "person_id", "role");
                });

            modelBuilder.Entity("FletNix.Models.Movie_Director", b =>
                {
                    b.Property<int>("movie_id");

                    b.Property<int>("person_id");

                    b.HasKey("movie_id", "person_id");
                });

            modelBuilder.Entity("FletNix.Models.Movie_Genre", b =>
                {
                    b.Property<int>("movie_id");

                    b.Property<string>("genre_name")
                        .HasAnnotation("MaxLength", 50)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.HasKey("movie_id", "genre_name");
                });

            modelBuilder.Entity("FletNix.Models.MovieAwards", b =>
                {
                    b.Property<int>("movie_id");

                    b.Property<string>("award")
                        .HasAnnotation("MaxLength", 255)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.Property<string>("result")
                        .HasAnnotation("MaxLength", 10)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.Property<string>("number_of_awards")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.HasKey("movie_id", "award", "result");
                });

            modelBuilder.Entity("FletNix.Models.Person", b =>
                {
                    b.Property<int>("person_id");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.Property<string>("gender")
                        .HasAnnotation("MaxLength", 1)
                        .HasAnnotation("Relational:ColumnType", "char");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.HasKey("person_id");
                });

            modelBuilder.Entity("FletNix.Models.Watchhistory", b =>
                {
                    b.Property<int>("movie_id");

                    b.Property<string>("customer_mail_address")
                        .HasAnnotation("MaxLength", 255)
                        .HasAnnotation("Relational:ColumnType", "varchar");

                    b.Property<DateTime>("watch_date")
                        .HasAnnotation("Relational:ColumnType", "date");

                    b.Property<bool>("invoiced");

                    b.Property<decimal>("price")
                        .HasAnnotation("Relational:ColumnType", "numeric");

                    b.HasKey("movie_id", "customer_mail_address", "watch_date");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("FletNix.Models.CustomerFeedback", b =>
                {
                    b.HasOne("FletNix.Models.Customer")
                        .WithMany()
                        .HasForeignKey("customer_mail_address");

                    b.HasOne("FletNix.Models.Movie")
                        .WithMany()
                        .HasForeignKey("movie_id");
                });

            modelBuilder.Entity("FletNix.Models.Movie", b =>
                {
                    b.HasOne("FletNix.Models.Movie")
                        .WithMany()
                        .HasForeignKey("previous_part");
                });

            modelBuilder.Entity("FletNix.Models.Movie_Cast", b =>
                {
                    b.HasOne("FletNix.Models.Movie")
                        .WithMany()
                        .HasForeignKey("movie_id");

                    b.HasOne("FletNix.Models.Person")
                        .WithMany()
                        .HasForeignKey("person_id");
                });

            modelBuilder.Entity("FletNix.Models.Movie_Director", b =>
                {
                    b.HasOne("FletNix.Models.Movie")
                        .WithMany()
                        .HasForeignKey("movie_id");

                    b.HasOne("FletNix.Models.Person")
                        .WithMany()
                        .HasForeignKey("person_id");
                });

            modelBuilder.Entity("FletNix.Models.Movie_Genre", b =>
                {
                    b.HasOne("FletNix.Models.Genre")
                        .WithMany()
                        .HasForeignKey("genre_name");

                    b.HasOne("FletNix.Models.Movie")
                        .WithMany()
                        .HasForeignKey("movie_id");
                });

            modelBuilder.Entity("FletNix.Models.MovieAwards", b =>
                {
                    b.HasOne("FletNix.Models.Movie")
                        .WithMany()
                        .HasForeignKey("movie_id");
                });

            modelBuilder.Entity("FletNix.Models.Watchhistory", b =>
                {
                    b.HasOne("FletNix.Models.Customer")
                        .WithMany()
                        .HasForeignKey("customer_mail_address");

                    b.HasOne("FletNix.Models.Movie")
                        .WithMany()
                        .HasForeignKey("movie_id");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FletNix.Models.FletNixUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FletNix.Models.FletNixUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("FletNix.Models.FletNixUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
