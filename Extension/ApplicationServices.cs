using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using mongotest.Interfaces;
using mongotest.Repositories.Base;

namespace mongotest.Extension
{
    public static class ApplicationServices
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryUser, UserRepository>();
            services.AddTransient<IRepositoryAuthor, AuthorRepository>();
            services.AddControllers();

            services.AddSingleton<IMongoClient>(c =>
            {
                var login = "root";
                var password = Uri.EscapeDataString("root");
                var server = "mongotest.vy8ktcm.mongodb.net";

                return new MongoClient($"mongodb+srv://{login}:{password}@{server}/test?retryWrites=true&w=majority");
            });

            services.AddScoped(c =>
                c.GetService<IMongoClient>().StartSession());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "MongoDB",
                        Version = "v1"
                    });
            });
        }
    }
}