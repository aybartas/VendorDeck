﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VendorDeck.Persistence.Context;

#nullable disable

namespace VendorDeck.Persistence.Migrations
{
    [DbContext(typeof(VendorDeckContext))]
    partial class VendorDeckContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VendorDeck.Domain.Entities.Concrete.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BuyerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("VendorDeck.Domain.Entities.Concrete.BasketItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BasketId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("ProductId");

                    b.ToTable("BasketItems", (string)null);
                });

            modelBuilder.Entity("VendorDeck.Domain.Entities.Concrete.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Angular",
                            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            ImageUrl = "/images/products/sb-ang1.png",
                            Name = "Angular Speedster Board 2000",
                            Price = 20000L,
                            Stock = 100,
                            Type = "Boards"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Angular",
                            Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                            ImageUrl = "/images/products/sb-ang2.png",
                            Name = "Green Angular Board 3000",
                            Price = 15000L,
                            Stock = 100,
                            Type = "Boards"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "NetCore",
                            Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                            ImageUrl = "/images/products/sb-core1.png",
                            Name = "Core Board Speed Rush 3",
                            Price = 18000L,
                            Stock = 100,
                            Type = "Boards"
                        },
                        new
                        {
                            Id = 4,
                            Brand = "NetCore",
                            Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                            ImageUrl = "/images/products/sb-core2.png",
                            Name = "Net Core Super Board",
                            Price = 30000L,
                            Stock = 100,
                            Type = "Boards"
                        },
                        new
                        {
                            Id = 5,
                            Brand = "React",
                            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            ImageUrl = "/images/products/sb-react1.png",
                            Name = "React Board Super Whizzy Fast",
                            Price = 25000L,
                            Stock = 100,
                            Type = "Boards"
                        },
                        new
                        {
                            Id = 6,
                            Brand = "TypeScript",
                            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            ImageUrl = "/images/products/sb-ts1.png",
                            Name = "Typescript Entry Board",
                            Price = 12000L,
                            Stock = 100,
                            Type = "Boards"
                        },
                        new
                        {
                            Id = 7,
                            Brand = "NetCore",
                            Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            ImageUrl = "/images/products/hat-core1.png",
                            Name = "Core Blue Hat",
                            Price = 1000L,
                            Stock = 100,
                            Type = "Hats"
                        },
                        new
                        {
                            Id = 8,
                            Brand = "React",
                            Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            ImageUrl = "/images/products/hat-react1.png",
                            Name = "Green React Woolen Hat",
                            Price = 8000L,
                            Stock = 100,
                            Type = "Hats"
                        },
                        new
                        {
                            Id = 9,
                            Brand = "React",
                            Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            ImageUrl = "/images/products/hat-react2.png",
                            Name = "Purple React Woolen Hat",
                            Price = 1500L,
                            Stock = 100,
                            Type = "Hats"
                        },
                        new
                        {
                            Id = 10,
                            Brand = "VS Code",
                            Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            ImageUrl = "/images/products/glove-code1.png",
                            Name = "Blue Code Gloves",
                            Price = 1800L,
                            Stock = 100,
                            Type = "Gloves"
                        },
                        new
                        {
                            Id = 11,
                            Brand = "VS Code",
                            Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            ImageUrl = "/images/products/glove-code2.png",
                            Name = "Green Code Gloves",
                            Price = 1500L,
                            Stock = 100,
                            Type = "Gloves"
                        },
                        new
                        {
                            Id = 12,
                            Brand = "React",
                            Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            ImageUrl = "/images/products/glove-react1.png",
                            Name = "Purple React Gloves",
                            Price = 1600L,
                            Stock = 100,
                            Type = "Gloves"
                        },
                        new
                        {
                            Id = 13,
                            Brand = "React",
                            Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            ImageUrl = "/images/products/glove-react2.png",
                            Name = "Green React Gloves",
                            Price = 1400L,
                            Stock = 100,
                            Type = "Gloves"
                        },
                        new
                        {
                            Id = 14,
                            Brand = "Redis",
                            Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                            ImageUrl = "/images/products/boot-redis1.png",
                            Name = "Redis Red Boots",
                            Price = 25000L,
                            Stock = 100,
                            Type = "Boots"
                        },
                        new
                        {
                            Id = 15,
                            Brand = "NetCore",
                            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            ImageUrl = "/images/products/boot-core2.png",
                            Name = "Core Red Boots",
                            Price = 18999L,
                            Stock = 100,
                            Type = "Boots"
                        },
                        new
                        {
                            Id = 16,
                            Brand = "NetCore",
                            Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                            ImageUrl = "/images/products/boot-core1.png",
                            Name = "Core Purple Boots",
                            Price = 19999L,
                            Stock = 100,
                            Type = "Boots"
                        },
                        new
                        {
                            Id = 17,
                            Brand = "Angular",
                            Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                            ImageUrl = "/images/products/boot-ang2.png",
                            Name = "Angular Purple Boots",
                            Price = 15000L,
                            Stock = 100,
                            Type = "Boots"
                        },
                        new
                        {
                            Id = 18,
                            Brand = "Angular",
                            Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                            ImageUrl = "/images/products/boot-ang1.png",
                            Name = "Angular Blue Boots",
                            Price = 18000L,
                            Stock = 100,
                            Type = "Boots"
                        });
                });

            modelBuilder.Entity("VendorDeck.Domain.Entities.Concrete.BasketItem", b =>
                {
                    b.HasOne("VendorDeck.Domain.Entities.Concrete.Basket", "Basket")
                        .WithMany("BasketItems")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VendorDeck.Domain.Entities.Concrete.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("VendorDeck.Domain.Entities.Concrete.Basket", b =>
                {
                    b.Navigation("BasketItems");
                });
#pragma warning restore 612, 618
        }
    }
}
