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
