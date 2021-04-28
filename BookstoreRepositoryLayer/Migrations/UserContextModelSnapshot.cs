﻿// <auto-generated />
using BookstoreRepositoryLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookstoreRepositoryLayer.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BookstoreModelLayer.AdminRegistration", b =>
                {
                    b.Property<int>("adminId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("firstName");

                    b.Property<string>("lastName");

                    b.Property<string>("password");

                    b.Property<string>("phone");

                    b.HasKey("adminId");

                    b.ToTable("AdminDB");
                });

            modelBuilder.Entity("BookstoreModelLayer.BookCart", b =>
                {
                    b.Property<int>("BookCartId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<int>("BookQuantity");

                    b.Property<long>("UserId");

                    b.HasKey("BookCartId");

                    b.ToTable("CartDB");
                });

            modelBuilder.Entity("BookstoreModelLayer.BookModel", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorName");

                    b.Property<string>("BookImage");

                    b.Property<string>("BookName");

                    b.Property<string>("Description");

                    b.Property<long>("Price");

                    b.Property<int>("Quantity");

                    b.Property<long>("UserId");

                    b.Property<int>("addedTocard");

                    b.HasKey("BookId");

                    b.ToTable("BookDB");
                });

            modelBuilder.Entity("BookstoreModelLayer.UserRegistration", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("firstName");

                    b.Property<string>("lastName");

                    b.Property<string>("password");

                    b.Property<string>("phone");

                    b.Property<string>("role");

                    b.HasKey("UserId");

                    b.ToTable("CustomerRegister");
                });
#pragma warning restore 612, 618
        }
    }
}
