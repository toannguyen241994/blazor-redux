﻿using BlazorRedux;
using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorStandalone
{
    internal class Program
    {
        private static void Main()
        {
            var serviceProvider = new BrowserServiceProvider(configure =>
            {
                configure.AddSingleton(new Store<MyModel, IAction>(
                    Reducers.MainReducer, 
                    Reducers.LocationReducer, 
                    (state) => state.Location,
                    new MyModel()));
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}