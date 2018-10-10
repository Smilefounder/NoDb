﻿// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:                  Joe Audette
// Created:                 2016-04-24
// Last Modified:           2018-10-10
// 

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace NoDb
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddNoDb<T>(this IServiceCollection services) where T : class
        {
            services.TryAddScoped<IBasicCommands<T>, BasicCommands<T>>();
            services.TryAddScoped<IBasicQueries<T>, BasicQueries<T>>();
            services.TryAddScoped<IStringSerializer<T>, StringSerializer<T>>();
            services.TryAddScoped<IStoragePathOptionsResolver, DefaultStoragePathOptionsResolver>();
            services.TryAddScoped<IStoragePathResolver<T>, DefaultStoragePathResolver<T>>();

            services.TryAddSingleton<IBasicCommandsSingleton<T>, BasicCommands<T>>();
            services.TryAddSingleton<IBasicQueriesSingleton<T>, BasicQueries<T>>();

            return services;
        }
    }
}
