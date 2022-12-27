using Application.Abstractions;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var cs = builder.Configuration["ConnectionString"];// ?? "Server=localhost,1433;Database=tempdb;User ID=sa;Password=<PlaceholderPassword>;Persist Security Info=False;TrustServerCertificate=true;";
builder.Services.AddDbContext<SocialDbContext>(opt =>
    opt.UseSqlServer(cs));
builder.Services.AddScoped<IPostRepository, PostRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();

