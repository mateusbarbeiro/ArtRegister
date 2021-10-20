using System.Threading.Tasks;
using ArtRegister.Application.Interfaces.Services.BaseServices;
using ArtRegister.Domain.Dtos;
using ArtRegister.Domain.Models;
using ArtRegister.Infrastructure.Dtos;

namespace ArtRegister.Application.Interfaces.Services
{
    /// <summary>
    /// Interface para serviço de produto. Declaração de métodos
    /// </summary>
    public interface IProductsService : IBaseService<Products>
    {
        /// <summary>
        /// Insere um novo produto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        ResponseMessages<object> Insert(CreateProductsModel product);

        /// <summary>
        /// Atualiza um registro de usuário
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        ResponseMessages<object> Update(UpdateProductsModel product);

        /// <summary>
        /// Busca um registro por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseMessages<object> GetById(long id);

        /// <summary>
        /// Deleta um registro de usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseMessages<object> DeleteById(long id);

        /// <summary>
        /// Busca lista de todos produtos levando em consideração parametros de filtragem e ordenação
        /// </summary>
        /// <param name="pagingParams"></param>
        /// <returns></returns
        Task<ResponseMessages<object>> Get(PaginatedInputModel pagingParams);
    }
}
