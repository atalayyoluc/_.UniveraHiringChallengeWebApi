using _.UniveraHiringChallengeData.Context;
using _.UniveraHiringChallengeEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeTest
{
    public class TestContext:AppDbContext
    {
            public TestContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId=Guid.Parse("5435d5f7-175c-4882-af32-1d860da215e7"),
                ProductDescription="deneme",
                ProductImgUrl="test",
                ProductName="Test",    
            },new Product()
            {
                ProductId=Guid.Parse("33075d65-058f-45d8-a584-36fe4533c0d8"),
                ProductDescription="deneme2",
                ProductImgUrl="test",
                ProductName="Test",    
            },new Product()
            {
                ProductId=Guid.Parse("43075d65-058f-45d8-a584-36fe4533d0d8"),
                ProductDescription="deneme23",
                ProductImgUrl="test",
                ProductName="Test",    
            });
            modelBuilder.Entity<Category>().HasData(
             new Category()
            {
                CategoryId = Guid.Parse("ce1034d9-bbc8-411e-bc11-4191935b8972"),
                CategoryName="Deneme kategorisi"
            }
            ,new Category()
            {
                CategoryId = Guid.Parse("3558ff65-3360-463b-a49c-5a360e147af8"),
                CategoryName="Deneme2 kategorisi"
            }
            ,new Category()
            {
                CategoryId = Guid.Parse("8af7c65f-8038-4adb-bcf1-a3c2f234878f"),
                CategoryName="Deneme3 kategorisi"
            }
            ,new Category()
            {
                CategoryId = Guid.Parse("caf5b809-03d9-4bc3-bb29-b4666bdb96a6"),
                CategoryName="Deneme4 kategorisi"
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory()
            {
                ProductCategoryId=Guid.Parse("219f7daf-d218-4b12-b949-0816fcc4f445"),
                ProductId = Guid.Parse("5435d5f7-175c-4882-af32-1d860da215e7"),
                CategoryId = Guid.Parse("ce1034d9-bbc8-411e-bc11-4191935b8972")
            },
            new ProductCategory()
            {
                ProductCategoryId = Guid.Parse("e41957f3-1028-4a92-943f-0eca1e5f1060"),
                ProductId = Guid.Parse("5435d5f7-175c-4882-af32-1d860da215e7"),
                CategoryId = Guid.Parse("3558ff65-3360-463b-a49c-5a360e147af8")
            },new ProductCategory()
            {
                ProductCategoryId = Guid.Parse("332d6600-fe55-4014-8178-1ac9225a4d26"),
                ProductId =Guid.Parse("33075d65-058f-45d8-a584-36fe4533c0d8"),
                CategoryId = Guid.Parse("caf5b809-03d9-4bc3-bb29-b4666bdb96a6")

            },new ProductCategory()
            {
                ProductCategoryId = Guid.Parse("4f092534-444c-4127-890c-3c19ad1905b1"),
                ProductId = Guid.Parse("33075d65-058f-45d8-a584-36fe4533c0d8"),
                CategoryId = Guid.Parse("8af7c65f-8038-4adb-bcf1-a3c2f234878f")
            });
            modelBuilder.Entity<Country>().HasData(
            new Country()
            {
                CountryImageUrl = "TürkiyeImg",
                CountryName = "Türkiye",
                CountryId = Guid.Parse("06df1ff9-7dc9-4bae-aff0-bc681292c882")
            }, 
            new Country()
            {
                CountryImageUrl = "FransaImg",
                CountryName = "Fransa",
                CountryId = Guid.Parse("4f7fd85a-df15-4b96-8ed3-96efef8931ed")

            },
            new Country()
            {
                CountryImageUrl = "BrezilyaImgUrl",
                CountryName = "Brezilya",
                CountryId = Guid.Parse("29e46575-5e92-408a-99e9-593226bc196b")
            },
            new Country()
            {
                CountryImageUrl = "AmerikaImg",
                CountryName = "Amerika",
                CountryId = Guid.Parse("7f1ba0d6-5c60-4556-8e5d-fc231ab4df18")

            });
            modelBuilder.Entity<Role>().HasData(new Role()
            {
                RoleId = Guid.Parse("233f4064-1f5d-4b71-9009-0a928a15669f"),
                RoleName = "User",
            }, new Role()
            {
                RoleName = "Admin",
                RoleId = Guid.Parse("638f4064-1f5d-4b71-9009-0a928a15669f")
            });
            modelBuilder.Entity<ShoppingListProduct>().HasData(
                new ShoppingListProduct()
                {
                    ShoppingListId = Guid.Parse("3f100ae0-9d4d-4637-abcb-9aa89435f090"),
                    ProductId = Guid.Parse("5435d5f7-175c-4882-af32-1d860da215e7")
                }, new ShoppingListProduct()
                {
                    ShoppingListId = Guid.Parse("342dbc84-8a47-4479-b78a-f3347cf733c6"),
                    ProductId = Guid.Parse("33075d65-058f-45d8-a584-36fe4533c0d8"),
                }, new ShoppingListProduct()
                {
                    ShoppingListId = Guid.Parse("342dbc84-8a47-4479-b78a-f3347cf733c6"),
                    ProductId = Guid.Parse("5435d5f7-175c-4882-af32-1d860da215e7")
                });
            modelBuilder.Entity<ShoppingList>().HasData(
                new ShoppingList()
                {
                    ShoppingId = Guid.Parse("3f100ae0-9d4d-4637-abcb-9aa89435f090"),
                    ShoppingName = "deneme",
                    ShoppingDate = DateTime.UtcNow,
                    ShoppingDescription="Açıklama",
                    IsShoppingComplate=false,
                    UserId=Guid.Parse("3783e42f-f753-4ae6-bfd4-c4ceb1cb8f26")

                },
                new ShoppingList()
                {
                    ShoppingId = Guid.Parse("342dbc84-8a47-4479-b78a-f3347cf733c6"),
                    ShoppingName = "deneme2",
                    ShoppingDate = DateTime.UtcNow,
                    ShoppingDescription = "Açıklama2",
                    IsShoppingComplate = false,
                    UserId=Guid.Parse("29699115-d314-4ed4-9894-3165e2f0fdbf")
                }) ;
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole()
                {
                    UserRoleId = Guid.Parse("16d25faf-5a07-49a4-9aba-37bc0411d5e6"),
                    UserId = Guid.Parse("29699115-d314-4ed4-9894-3165e2f0fdbf"),
                    RoleId = Guid.Parse("233f4064-1f5d-4b71-9009-0a928a15669f")
                },
                new UserRole()
                {
                    UserRoleId = Guid.Parse("16d25faf-5a07-49a4-9aba-37bc0453d5e6"),
                    RoleId = Guid.Parse("638f4064-1f5d-4b71-9009-0a928a15669f"),
                    UserId = Guid.Parse("3783e42f-f753-4ae6-bfd4-c4ceb1cb8f26")
                });
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserId = Guid.Parse("3783e42f-f753-4ae6-bfd4-c4ceb1cb8f26"),
                    Password="123456",
                    UserFirstName="Admin",
                    UserLastName="Admin",
                    UserName="Admin",
                    CountryId = Guid.Parse("06df1ff9-7dc9-4bae-aff0-bc681292c882"),
                    UserToken= "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYXRhbGF5eW9sdWMiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImF0YWxheXlvbHVjIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJleHAiOjE2Nzk2NjY3NjUsImlzcyI6ImxvY2FsaG9zdCIsImF1ZCI6ImxvY2FsaG9zdCJ9.0GxPOjxP0IVu-Cm3_o11gWeR3QMEhgm_FX0Oiv5LlB4"
                }
                ,
                new User()
                {
                    UserId = Guid.Parse("29699115-d314-4ed4-9894-3165e2f0fdbf"),
                    Password = "123456",
                    UserFirstName = "User",
                    UserLastName = "User",
                    UserName = "User",
                    CountryId = Guid.Parse("06df1ff9-7dc9-4bae-aff0-bc681292c882"),
                    UserToken= "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWxpdmVsaSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiYWxpdmVsaSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlVzZXIiLCJleHAiOjE2Nzk1MDYwNzMsImlzcyI6ImxvY2FsaG9zdCIsImF1ZCI6ImxvY2FsaG9zdCJ9.ptPSTEmPvzctR-an0pjU8HlUQ20naSHBL75VbPfkG7A"
                }
                );

            }

       
    }
    }

