using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaESport.Data.Common.Repositories;
using DotaESport.Data.Models;
using DotaESport.Services.Mapping;
using DotaESport.Web.ViewModels.Recipe;

namespace DotaESport.Services.Data
{
    public class RecipesService : IRecipesService
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;

        public RecipesService(IDeletableEntityRepository<Recipe> recipesRepository)
        {
            this.recipesRepository = recipesRepository;
        }

        public Task AddItemAsync(AddRecipeInputModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllRecipes<T>(int? count = null)
        {
            IQueryable<Recipe> query =
                this.recipesRepository.All().OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }
    }
}
