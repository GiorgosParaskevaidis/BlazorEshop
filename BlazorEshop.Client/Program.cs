global using BlazorEshop.Shared;
using BlazorEshop.Client.Services.CategoryService;
using BlazorEshop.Client.Services.ProductService;
using Microsoft.AspNetCore.Components.Web;
using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorEshop.Client.Services.CartService;

namespace BlazorEshop.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICartService, CartService>();

            await builder.Build().RunAsync();
        }
    }
}
