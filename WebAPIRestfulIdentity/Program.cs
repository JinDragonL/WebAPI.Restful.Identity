using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAPIRestfulIdentity.DataAccess;
using WebAPIRestfulIdentity.DataAccess.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var service = builder.Services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("SampleWebApiConnection"),
                b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));


var app = builder.Build();

// Ensure to database created
IdentityContext dbcontext = app.Services.GetRequiredService<IdentityContext>();
dbcontext.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
