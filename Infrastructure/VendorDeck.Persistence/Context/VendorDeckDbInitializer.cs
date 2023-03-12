using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Persistence.Context
{
    public class VendorDeckDbInitializer 
    {
        public static IEnumerable<Product> GetSeedProducts()
        {
            return new List<Product> {
                new Product
                {
                    Id = 1,
                    Name = "Angular Speedster Board 2000",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    ImageUrl = "/images/products/sb-ang1.png",
                    Brand = "Angular",
                    Type = "Boards",
                    Stock = 100
                },
                new Product
                {
                    Id =2,
                    Name = "Green Angular Board 3000",
                    Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                    Price = 15000,
                    ImageUrl = "/images/products/sb-ang2.png",
                    Brand = "Angular",
                    Type = "Boards",
                    Stock = 100
                },
                new Product
                {

                    Id =3,
                    Name = "Core Board Speed Rush 3",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    ImageUrl = "/images/products/sb-core1.png",
                    Brand = "NetCore",
                    Type = "Boards",
                    Stock = 100
                },
                new Product
                {
                    Id =4,
                    Name = "Net Core Super Board",
                    Description =
                        "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                    Price = 30000,
                    ImageUrl = "/images/products/sb-core2.png",
                    Brand = "NetCore",
                    Type = "Boards",
                    Stock = 100
                },
                new Product
                {
                    Id =5,
                    Name = "React Board Super Whizzy Fast",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 25000,
                    ImageUrl = "/images/products/sb-react1.png",
                    Brand = "React",
                    Type = "Boards",
                    Stock = 100
                },
                new Product
                {
                    Id =6,
                    Name = "Typescript Entry Board",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 12000,
                    ImageUrl = "/images/products/sb-ts1.png",
                    Brand = "TypeScript",
                    Type = "Boards",
                    Stock = 100
                },
                new Product
                {
                    Id =7,
                    Name = "Core Blue Hat",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 1000,
                    ImageUrl = "/images/products/hat-core1.png",
                    Brand = "NetCore",
                    Type = "Hats",
                    Stock = 100
                },
                new Product
                {
                    Id =8,
                    Name = "Green React Woolen Hat",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 8000,
                    ImageUrl = "/images/products/hat-react1.png",
                    Brand = "React",
                    Type = "Hats",
                    Stock = 100
                },
                new Product
                {
                    Id =9,
                    Name = "Purple React Woolen Hat",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 1500,
                    ImageUrl = "/images/products/hat-react2.png",
                    Brand = "React",
                    Type = "Hats",
                    Stock = 100
                },
                new Product
                {
                    Id =10,
                    Name = "Blue Code Gloves",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 1800,
                    ImageUrl = "/images/products/glove-code1.png",
                    Brand = "VS Code",
                    Type = "Gloves",
                    Stock = 100
                },
                new Product
                {
                    Id =11,
                    Name = "Green Code Gloves",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 1500,
                    ImageUrl = "/images/products/glove-code2.png",
                    Brand = "VS Code",
                    Type = "Gloves",
                    Stock = 100
                },
                new Product
                {
                    Id =12,
                    Name = "Purple React Gloves",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 1600,
                    ImageUrl = "/images/products/glove-react1.png",
                    Brand = "React",
                    Type = "Gloves",
                    Stock = 100
                },
                new Product
                {
                    Id =13,
                    Name = "Green React Gloves",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 1400,
                    ImageUrl = "/images/products/glove-react2.png",
                    Brand = "React",
                    Type = "Gloves",
                    Stock = 100
                },
                new Product
                {
                    Id =14,
                    Name = "Redis Red Boots",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 25000,
                    ImageUrl = "/images/products/boot-redis1.png",
                    Brand = "Redis",
                    Type = "Boots",
                    Stock = 100
                },
                new Product
                {
                    Id =15,
                    Name = "Core Red Boots",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 18999,
                    ImageUrl = "/images/products/boot-core2.png",
                    Brand = "NetCore",
                    Type = "Boots",
                    Stock = 100
                },
                new Product
                {
                    Id =16,
                    Name = "Core Purple Boots",
                    Description =
                        "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                    Price = 19999,
                    ImageUrl = "/images/products/boot-core1.png",
                    Brand = "NetCore",
                    Type = "Boots",
                    Stock = 100
                },
                new Product
                {
                    Id =17,
                    Name = "Angular Purple Boots",
                    Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                    Price = 15000,
                    ImageUrl = "/images/products/boot-ang2.png",
                    Brand = "Angular",
                    Type = "Boots",
                    Stock = 100
                },
                new Product
                {
                    Id =18,
                    Name = "Angular Blue Boots",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    ImageUrl = "/images/products/boot-ang1.png",
                    Brand = "Angular",
                    Type = "Boots",
                    Stock = 100
                },
            };
        }
    }
}
