using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DotaESport.Web.ViewModels.Items;

namespace DotaESport.Services.Data
{
    public interface IItemsService
    {
        Task AddItemAsync(AddItemInputModel model);

        IEnumerable<T> GetAllItems<T>(int? count = null);
    }
}
