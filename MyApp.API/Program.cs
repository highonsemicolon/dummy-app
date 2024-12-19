using MongoDB.Driver;
using MyApp.DAL.Entities;
using MyApp.DAL.Repositories;
using MyApp.BLL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson.Serialization.Conventions;

var builder = WebApplication.CreateBuilder(args);


var mongoConnectionString = builder.Configuration["MongoDB:ConnectionString"];
var mongoDatabaseName = builder.Configuration["MongoDB:DatabaseName"];
var client = new MongoClient(mongoConnectionString);
var database = client.GetDatabase(mongoDatabaseName);

builder.Services.AddSingleton(database);

builder.Services.AddScoped<IRepository<Product>>(sp => 
    new MongoRepository<Product>(database, "Products"));
builder.Services.AddScoped<IProductService, ProductService>();

var conventionPack = new ConventionPack
{
    new IgnoreIfNullConvention(true)
};
ConventionRegistry.Register("Ignore null values", conventionPack, t => true);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
