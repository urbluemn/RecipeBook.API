using Recipes.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.Application.Interfaces
{
    public interface IRecipeDbContext
    {
        DbSet<Recipe> Recipes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
