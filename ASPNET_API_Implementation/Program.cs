using ASPNET_API_Implementation.Data;
using ASPNET_API_Implementation.Data.Interfaces;
using ASPNET_API_Implementation.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRepository, SalesRepository>();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


/*
namespace ASPNET_API_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Seed Data
            SalesDbContext.SeedDatabase();



            //rest of program...
            Console.WriteLine("End of Program");
        }
    }
}
*/