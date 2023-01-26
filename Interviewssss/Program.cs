using Interviewssss.Context;
using Interviewssss.Extation;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

StartUp(builder.Services, builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.Run();

static void StartUp(IServiceCollection services, ConfigurationManager manager)
{
    services.AddControllers();
    services.AddDbContext<AppDbContext>(p => p.UseNpgsql(manager.GetConnectionString("DefoultConection")));
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddAuthentication();
    services.AddConfigureIdentity();
    services.AddConfigureJwt(manager);
    services.AddEndpointsApiExplorer();
    services.AddSwager();
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.AddServise();
    services.AddRepostory();
    services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
    
    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin().
        AllowAnyMethod().
        AllowAnyHeader());
    });



}

