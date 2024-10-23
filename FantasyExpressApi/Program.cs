using FantasyExpressApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FantasyExpressApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<FantasyExpressDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("FantasyExpressDbContext") ?? throw new InvalidOperationException("Connection string 'FantasyExpressDbContext' not found.")));

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(
                options => {
                    options.IdleTimeout = TimeSpan.FromSeconds(69);
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                }
                );

            // Add services to the container.
            builder.Services.AddDbContext<FantasyExpressDbContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("FantasyExpressDbContext") ?? throw new InvalidOperationException("Connection string 'FantasyExpressDbContext' not found.")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}