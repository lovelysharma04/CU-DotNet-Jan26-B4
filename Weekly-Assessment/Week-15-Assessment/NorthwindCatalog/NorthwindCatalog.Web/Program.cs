namespace NorthwindCatalog.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            // Name matches controllers
            builder.Services.AddHttpClient("NorthwindApi", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7273/");
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Categories}/{action=Index}/{id?}");
            //         Changed default to Categories instead of Home

            app.Run();
        }
    }
}