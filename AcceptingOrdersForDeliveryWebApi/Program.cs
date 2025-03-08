using Microsoft.EntityFrameworkCore;
using AcceptingOrdersForDeliveryWebApi.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.WebHost.ConfigureKestrel(options =>
        {
            options.ListenAnyIP(7210, listenOptions =>
            {
                listenOptions.UseHttps();
            });
        });
        
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();
        app.UseCors("AllowAll");
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}