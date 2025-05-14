using CouchesApp.DTOs;
using CouchesApp.Models;
using CouchesApp.Repositories;

namespace CouchesApp.Services
{
    public class ProduitService : IProduitService
    {
        private readonly IProductRepository _productRepository;
        public ProduitService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        Task IProduitService.AjouterProduitAsync(ProduitDto dto)
        {
            var produit = new Produit
            {
                Nom = dto.Nom,
                Prix = dto.Prix
            };
            _productRepository.AddAsync(produit);
            return Task.CompletedTask;
        }

        Task<List<ProduitDto>> IProduitService.GetExpensiveProductsAsync()
        {
            var produit = _productRepository.GetAllAsync();
            var expensiveProducts = produit.Result.Where(p => p.Prix > 3).Select(p => new ProduitDto
            {
                Nom = p.Nom,
                Prix = p.Prix
            }).ToList();
            return Task.FromResult(expensiveProducts);
        }

        Task<List<ProduitDto>> IProduitService.GetProduitsAsync()
        {
            var produits = _productRepository.GetAllAsync();
            var produitsDto = produits.Result.Select(p => new ProduitDto
            {
                Nom = p.Nom,
                Prix = p.Prix
            }).ToList();
            return Task.FromResult(produitsDto);
        }
    }
}
