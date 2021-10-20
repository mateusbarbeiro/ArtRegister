using ArtRegister.Application.Interfaces.Repository;
using ArtRegister.Domain.Models;
using ArtRegister.Infrastructure.Context;

namespace ArtRegister.Infrastructure.Repository
{
    /// <summary>
    /// Repositório para produtos
    /// </summary>
    public class ProductsRepository : BaseRepository<Products>, IProductsRepository
    {
        public ProductsRepository(ApiContext context) : base (context)
        {

        }
    }
}