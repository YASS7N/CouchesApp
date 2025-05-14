using CouchesApp.DTOs;
using CouchesApp.Models;

namespace CouchesApp.Services
{
    public interface IProduitService
    {
        Task<List<ProduitDto>> GetProduitsAsync();
        Task AjouterProduitAsync(ProduitDto dto);
        Task<List<ProduitDto>> GetExpensiveProductsAsync();
    }
}
