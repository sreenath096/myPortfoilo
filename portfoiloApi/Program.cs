using System.Text.Json.Serialization;
using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.FeatureManagement;
using portfoiloApi.Helpers;
using portfoiloApi.Middlewares;
using portfoiloApi.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Host.ConfigureAppConfiguration(config =>
{
    var connnectionString = config.Build().GetConnectionString("AppConfiguration");
    config.AddAzureAppConfiguration(options =>
    {
        options.Connect(connnectionString).UseFeatureFlags();
    });

    // .Connect(new Uri("https://develop-config.azconfig.io"), new DefaultAzureCredential())
    // .UseFeatureFlags();
});


// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    //options.UseInMemoryDatabase("Default");
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddCors();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddFeatureManagement();
builder.Services.AddAzureAppConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAzureAppConfiguration();

app.UseAuthorization();

app.MapControllers();

app.Run();
