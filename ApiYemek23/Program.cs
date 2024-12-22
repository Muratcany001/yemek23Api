using ApiYemek23.Abstract;
using ApiYemek23.Concrete;
using ApiYemek23.Entities;
using ApiYemek23.Services;

//using ApiYemek23.JsonHandler;  // PostRestaurantData sýnýfýnýn namespace'ini ekleyin
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add your DbContext and other dependencies here
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection registration
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
//builder.Services.AddTransient<RunPostRestaurant>();
//builder.Services.AddTransient<PostRestaurantData>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddScoped<RepositoryService>();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//using (var scope = app.Services.CreateScope())
//{
//    var runPostRestaurant = scope.ServiceProvider.GetRequiredService<RunPostRestaurant>();
//    string filePath = @"C:\Users\murat\source\repos\jsonHandler\jsonHandler\bin\Debug\net8.0\formatted_data3.txt";

//    // Post iþlemini çalýþtýrýn
//    await runPostRestaurant.Run(filePath);
//}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
