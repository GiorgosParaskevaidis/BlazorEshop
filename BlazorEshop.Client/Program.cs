global using BlazorEshop.Shared;
global using BlazorEshop.Client.Services.CategoryService;
global using BlazorEshop.Client.Services.ProductService;
global using BlazorEshop.Client.Services.AuthService;
global using Microsoft.AspNetCore.Components.Authorization;
global using BlazorEshop.Client.Services.CartService;
global using BlazorEshop.Client.Services.OrderService;
global using BlazorEshop.Client.Services.ProductTypeService;
using Microsoft.AspNetCore.Components.Web;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorEshop.Client.Services.AddressService;
using MudBlazor.Services;


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
            builder.Services.AddMudServices();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(/*builder.HostEnvironment.BaseAddress*/ "https://localhost:7115") });
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IAddressService, AddressService>();
            builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

            await builder.Build().RunAsync();
        }
    }
}
