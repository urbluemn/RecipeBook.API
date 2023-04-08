using System;
using Microsoft.EntityFrameworkCore;
using Recipes.Domain;
using Recipes.Persistence;

namespace Recipes.Tests.Common
{
    public static class RecipesContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static string UserAName = "UserAName";
        public static string UserBName = "UserBName";

        public static Guid RecipeIdForDelete = Guid.NewGuid();
        public static Guid RecipeIdForUpdate = Guid.NewGuid();

        public static RecipeDbContext Create()
        {
            var options = new DbContextOptionsBuilder<RecipeDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new RecipeDbContext(options);
            context.Database.EnsureCreated();
            context.Recipes.AddRange(
                new Recipe{
                    Username = UserAName,
                    CreationDate = DateTime.Today,
                    Details = "Details1",
                    Description = "Description1",
                    EditDate = null,
                    Id = Guid.Parse("D04F5122-A17E-4202-AF6A-E11B7704AA7E"),
                    Name = "Name1",
                    UserId = UserAId
                },
                new Recipe{
                    Username = UserBName,
                    CreationDate = DateTime.Today,
                    Details = "Details2",
                    Description = "Description2",
                    EditDate = null,
                    Id = Guid.Parse("63EC94EF-8819-4F3B-91FE-BC12EC3ACD44"),
                    Name = "Name2",
                    UserId = UserBId
                },
                new Recipe{
                    Username = UserAName,
                    CreationDate = DateTime.Today,
                    Details = "Details3",
                    Description = "Description3",
                    EditDate = null,
                    Id = RecipeIdForDelete,
                    Name = "Name3",
                    UserId = UserAId
                },
                new Recipe{
                    Username = UserBName,
                    CreationDate = DateTime.Today,
                    Details = "Details4",
                    Description = "Description4",
                    EditDate = null,
                    Id = RecipeIdForUpdate,
                    Name = "Name4",
                    UserId = UserBId
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(RecipeDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}