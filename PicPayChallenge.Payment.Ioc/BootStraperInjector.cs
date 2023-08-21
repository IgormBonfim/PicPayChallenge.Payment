﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using PicPayChallenge.Payment.Application.Users.Profiles;
using PicPayChallenge.Payment.Application.Users.Services;
using PicPayChallenge.Payment.Common.Filters;
using PicPayChallenge.Payment.Domain.Users.Services;
using PicPayChallenge.Payment.Infra.Users.Mappings;
using PicPayChallenge.Payment.Infra.Users.Repositories;

namespace PicPayChallenge.Payment.Ioc
{
    public static class BootStraperInjector
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISessionFactory>(factory =>
            {
                string connectionString = configuration.GetConnectionString("MySql")!;
                return Fluently.Configure()
                                    .Database(MySQLConfiguration.Standard
                                                                    .ConnectionString(connectionString)
                                                                    .FormatSql()
                                                                    .ShowSql())
                                    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<UserMap>())
                                    .BuildSessionFactory();
            });

            services.AddSingleton<ISession>(factory => factory.GetService<ISessionFactory>()!.OpenSession());

            services.AddAutoMapper(typeof(UsersProfile));

            services.AddMvcCore(optios =>
            {
                optios.Filters.Add(typeof(ExceptionFilter));
            });

            services.Scan(scan => scan.FromAssemblyOf<UsersAppService>().AddClasses().AsImplementedInterfaces().WithScopedLifetime());
            services.Scan(scan => scan.FromAssemblyOf<UsersService>().AddClasses().AsImplementedInterfaces().WithScopedLifetime());
            services.Scan(scan => scan.FromAssemblyOf<UsersRepository>().AddClasses().AsImplementedInterfaces().WithScopedLifetime());
        }
    }
}