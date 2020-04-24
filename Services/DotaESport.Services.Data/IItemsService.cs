namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DotaESport.Web.ViewModels.Items;

    public interface IItemsService
    {
        Task AddItemAsync(AddItemInputModel model);

        IEnumerable<T> GetAllItems<T>(int? count = null);

        T GetById<T>(int id);

    }
}
