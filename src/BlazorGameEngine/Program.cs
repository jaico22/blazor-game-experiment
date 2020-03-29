using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BlazoreGameEngine.GraphicsEngine.Implementation;
using BlazorGameEngine.Core.Interfaces;
using BlazorGameEngine.Core.Implementation;
using BlazoreGameEngine.GraphicsEngine.Interfaces;

namespace BlazorGameEngine
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddBaseAddressHttpClient();

            // Game Client Stuff
            builder.Services.AddSingleton<IGraphicsDriver, GraphicsDriver>();
            builder.Services.AddSingleton<IGameDriver, GameDriver>();

            await builder.Build().RunAsync();
        }
    }
}
