using System.Threading.Tasks;
using ArtRegister.Application.Interfaces.Services.BaseServices;
using ArtRegister.Domain.Dtos;
using ArtRegister.Domain.Models;
using ArtRegister.Infrastructure.Dtos;

namespace ArtRegister.Application.Interfaces.Services
{
    /// <summary>
    /// Interface para serviço de seção. Declaração de métodos
    /// </summary>
    public interface ISectionsService : IBaseService<Sections>
    {
        /// <summary>
        /// Insere uma nova seção
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        ResponseMessages<object> Insert(CreateSectionsModel section);

        /// <summary>
        /// Atualiza um registro de seção
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        ResponseMessages<object> Update(UpdateSectionsModel section);

        /// <summary>
        /// Busca um registro por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseMessages<object> GetById(long id);

        /// <summary>
        /// Deleta um registro de seção
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseMessages<object> DeleteById(long id);

        /// <summary>
        /// Busca lista de todos seção levando em consideração parametros de filtragem e ordenação
        /// </summary>
        /// <param name="pagingParams"></param>
        /// <returns></returns>
        Task<ResponseMessages<object>> Get(PaginatedInputModel pagingParams);
    }
}
