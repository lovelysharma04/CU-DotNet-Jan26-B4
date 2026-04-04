using SmartBank.WebService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

builder.Services.AddHttpContextAccessor();

var gatewayBase = builder.Configuration["ApiSettings:GatewayBaseUrl"]
    ?? throw new Exception("GatewayBaseUrl is not configured");

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddHttpClient("GatewayClient", client =>
    {
        client.BaseAddress = new Uri(gatewayBase);
    })
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    });
}
else
{
    builder.Services.AddHttpClient("GatewayClient", client =>
    {
        client.BaseAddress = new Uri(gatewayBase);
    });
}

builder.Services.AddScoped<FeedbackService>(); // ✅ safer
builder.Services.AddScoped<WebApplicationMVC.Services.APIService>();
builder.Services.AddScoped<WebApplicationMVC.Filters.AuthFilter>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();          // ✅ must come before auth
app.UseAuthentication();   // ✅ ADD THIS
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();