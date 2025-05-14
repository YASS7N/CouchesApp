using CouchesApp.Data;
using CouchesApp.Repositories;
using CouchesApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProduitService, ProduitService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
using CouchesApp.Data;
using CouchesApp.Models;

namespace CouchesApp.Repositories
{
    public class ProductRepository : IProductRepository

    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        async Task<Produit> IProductRepository.AddAsync(Produit produit)
        {
            _context.Produits.Add(produit);
            await _context.SaveChangesAsync();
            return produit;
        }

        Task<List<Produit>> IProductRepository.GetAllAsync()
        {
            return Task.FromResult(_context.Produits.ToList());
        }

        Task<Produit> IProductRepository.GetByIdAsync(int id)
        {
            return Task.FromResult(_context.Produits.FirstOrDefault(p => p.Id == id));
        }
    }
}
