using Microsoft.EntityFrameworkCore;
using TKBlogSolution.Data.EF;
using TKBlogSolution.Data.Entities;
using TKBlogSolution.Repo.Repositories;
using TKBlogSolution.Repo.UnitOfWork;
using TKBlogSolution.Service.Services.Category;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TKBlogSolutionContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(TKBlogSolution.Service.Configuration.AutoMapperConfig).Assembly);
// Register UnitOfWork and Repository
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Register other services
builder.Services.AddScoped<ICategoryService, CategoryService>();



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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
