using ArtRegister.Application.Interfaces.Repositories.BaseRepositories;
using ArtRegister.Domain.Models;

namespace ArtRegister.Application.Interfaces.Repository
{
    /// <summary>
    /// Interface repositório para produtos.
    /// </summary>
    public interface IProductsRepository : IBaseRepository<Products>
    {

    }
}