using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Data.Repos;

internal class Program
{
    private static void Main(string[] args)
    {
        
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemoryDB"));
        builder.Services.AddScoped<IPlatformRepo, PlatfromRepo>();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        app.DbPreparor();
        app.Run();
    }
}