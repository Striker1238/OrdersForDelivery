using AcceptingOrdersForDeliveryMVC.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        builder.Services.AddHttpClient();
        builder.Services.AddScoped<OrderService>();

        var app = builder.Build();
        app.UseStaticFiles();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Orders}/{action=Index}/{id?}");

        app.Run();
    }
}