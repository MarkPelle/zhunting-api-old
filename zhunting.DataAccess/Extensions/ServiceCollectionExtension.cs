using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using zhunting.DataAccess.Repositories;
using zhunting.DataAccess.Repositories.Interfaces;

namespace zhunting.DataAccess.Extensions
{
    public static class ServiceCollectionExtension 
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IGalleryRepository, GalleryRepository>();
            services.AddTransient<IAnimalRepository, AnimalRepository>();

        }
    }
}
