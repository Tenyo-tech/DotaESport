using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DotaESport.Web.ViewModels.Items;
using DotaESport.Web.ViewModels.Recipe;

namespace DotaESport.Services.Data
{
    public interface IRecipesService
    {
        Task AddItemAsync(AddRecipeInputModel model);

        IEnumerable<T> GetAllRecipes<T>(int? count = null);
    }
}
