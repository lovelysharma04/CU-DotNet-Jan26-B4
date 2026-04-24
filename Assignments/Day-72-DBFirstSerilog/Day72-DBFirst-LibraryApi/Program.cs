using Day72_DBFirst_LibraryApi.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Serilog
builder.Host.UseSerilog((context, services, config) => config
    .ReadFrom.Configuration(context.Configuration)
    .Enrich.WithMachineName()
    .Enrich.WithThreadId()
    .WriteTo.Console()
    .WriteTo.File("logs/library-log-.txt", rollingInterval: RollingInterval.Day)
);

// DbContext
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddControllers();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
app.UseMiddleware<ExceptionMiddleware>();
app.UseSerilogRequestLogging();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

// ⚠️ Disable HTTPS to avoid your error
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();