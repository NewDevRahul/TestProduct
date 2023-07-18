using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using TestProduct.DbContexts;
using TestProduct.Migrations;
using TestProduct.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Database connection string
builder.Services.AddDbContext<MyDbContext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//All Repository injection in program.cs file
builder.Services.AddScoped<IUserRepository,UserRepository>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options =>{
        options.AddPolicy(name: "AllowOrigin", builder =>{
                builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure FluentMigrator
builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddSqlServer()
        .WithGlobalConnectionString(builder.Configuration.GetConnectionString("DefaultConnection"))
        .ScanIn(typeof(InitialMigration).Assembly).For.Migrations())
    .AddLogging(lb => lb.AddFluentMigratorConsole());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>{
        c.SwaggerEndpoint("/swagger/v1/swagger.json","TestProduct");
        c.RoutePrefix = "swagger";
    });

    app.Use(async(context,next) =>
    {
        if(context.Request.Path == "/")
        {
            context.Response.Redirect("/swagger");
            return;
        }
        await next();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

using(var scope = app.Services.CreateScope())
{
    var migrator = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    migrator.MigrateUp();
}

app.MapControllers();

app.Run();
