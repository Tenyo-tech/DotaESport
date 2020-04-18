using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using DotaESport.Data.Models;
using DotaESport.Services.Mapping;
using DotaESport.Web.ViewModels.Articles;

namespace DotaESport.Services.Data.Tests.Common
{
    public class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(ArticleViewModel).GetTypeInfo().Assembly,
                typeof(Article).GetTypeInfo().Assembly);

            AutoMapperConfig.RegisterMappings(
                typeof(ArticleViewModel).GetTypeInfo().Assembly,
                typeof(Article).GetTypeInfo().Assembly);
        }
    }
}
