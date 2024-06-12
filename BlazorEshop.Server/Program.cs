global using BlazorEshop.Shared;
global using Microsoft.EntityFrameworkCore;
global using BlazorEshop.Server.Data;
namespace BlazorEshop.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<BlazoreshopDbContex> (options =>
            {
                options.UseSqlServer (builder.Configuration.GetConnectionString ("DefaultConnection"));
            });

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddEndpointsApiExplorer ();
            builder.Services.AddSwaggerGen ();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseSwaggerUI ();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseWebAssemblyDebugging();
            }

            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}
