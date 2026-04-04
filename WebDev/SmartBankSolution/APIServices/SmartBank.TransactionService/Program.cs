using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartBank.TransactionService.Data;
using SmartBank.TransactionService.Mappings;
using SmartBank.TransactionService.Repositories;
using SmartBank.TransactionService.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// ✅ 1. DATABASE CONFIGURATION
builder.Services.AddDbContext<TransactionDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


// ✅ 2. DEPENDENCY INJECTION
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<AccountApiClient>();


// ✅ 3. AUTOMAPPER
builder.Services.AddAutoMapper(typeof(MappingProfile));


// ✅ 4. HTTP CLIENT (ACCOUNT SERVICE)
var accountServiceUrl = builder.Configuration["ServiceUrls:AccountService"]
    ?? throw new InvalidOperationException("ServiceUrls:AccountService is not configured.");

builder.Services.AddHttpClient("AccountService", client =>
{
    client.BaseAddress = new Uri(accountServiceUrl);
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});


// ✅ 5. JWT AUTHENTICATION
var jwtKey = builder.Configuration["Jwt:Key"]
    ?? throw new InvalidOperationException("Jwt:Key is not configured.");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey))
        };
    });


// ✅ 6. CONTROLLERS
builder.Services.AddControllers();


// ✅ 7. SWAGGER + JWT SUPPORT
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter 'Bearer <token>'"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


// ================= PIPELINE =================

var app = builder.Build();


// ✅ 8. DEV TOOLS
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// ✅ 9. MIDDLEWARE (ORDER MATTERS)
app.UseHttpsRedirection();

app.UseAuthentication();   // 🔥 MUST BE BEFORE Authorization
app.UseAuthorization();


// ✅ 10. MAP CONTROLLERS
app.MapControllers();


// ✅ 11. RUN
app.Run();