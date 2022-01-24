﻿using System;
using Autofac;
using News.ViewModels.Helpers;

namespace News
{
    public static class Bootstrapper
    {
        public static void Initialize()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAssemblyTypes(typeof(App).Assembly)
                .Where(x => x.IsSubclassOf(typeof(ViewModel)));

            var container = containerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}
