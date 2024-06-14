using InventoryControl.API.Mappers;
using InventoryControl.API.Persistence;
using InventoryControl.API.Services.Interfaces;
using InventoryControl.API.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "InventoryControl.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Joselito Machado",
            Email = "opaguelosantos@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/joselitomachado/")
        }
    });

    var xmlFile = "InventoryControl.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddScoped<IMedicationInterface, MedicationRepository>();

builder.Services.AddAutoMapper(typeof(MedicationProfile).Assembly);

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddDbContext<InventoryControlDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryControlCs"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
