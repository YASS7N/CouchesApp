using CouchesApp.Models;

namespace CouchesApp.Repositories
{
    public interface IProductRepository
    {
        Task<List<Produit>> GetAllAsync();
        Task<Produit> GetByIdAsync(int id);
        Task<Produit> AddAsync(Produit produit);
    }
}
