using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pro.MYS.Application.IRepository;
using Pro.MYS.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.MYS.DataAccess
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddIOC(this IServiceCollection services, IConfiguration configuration)
        {

            var con = configuration.GetConnectionString("DefaultConnection");


            services.AddDbContext<DatabaseContext>(options =>
          options.UseSqlServer(con));


            #region AddDependencyInjections
            services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));

            services.AddScoped<IHintRepository, HintRepository>();
            #endregion

            return services;
        }


    }
}
