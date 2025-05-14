using CouchesApp.DTOs;
using CouchesApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CouchesApp.Controllers
{
    public class ProduitController : ControllerBase
    {
        private readonly IProduitService _produitService;

        public ProduitController(IProduitService produitService)
        {
            _produitService = produitService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduits()
        {
            var produits = await _produitService.GetProduitsAsync();
            return Ok(produits);
        }

        [HttpPost]
        public async Task<IActionResult> AjouterProduit([FromBody] ProduitDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Produit cannot be null");
            }

            await _produitService.AjouterProduitAsync(dto);
            return Ok();
        }
        public async Task<IActionResult> GetExpensiveProducts()
        {
            var produits = await _produitService.GetExpensiveProductsAsync();
            return Ok(produits);
        }
    }
}

