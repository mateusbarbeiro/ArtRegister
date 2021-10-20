using AutoMapper;
/*using Microsoft.AspNetCore.Http;*/
using System;
using System.Linq;
using System.Threading.Tasks;
using ArtRegister.Application.Interfaces.Repository;
using ArtRegister.Application.Interfaces.Services;
using ArtRegister.Application.Validators;
using ArtRegister.Domain.Models;
using ArtRegister.Infrastructure.Dtos;
using ArtRegister.Application.Interfaces.Repositories.BaseRepositories;
using ArtRegister.Domain.Dtos;

namespace ArtRegister.Application.Services
{
    /// <summary>
    /// Seções
    /// </summary>
    public class SectionsService : BaseService<Sections>, ISectionsService
    {
        private ISectionsRepository _baseRepository;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="baseRepository"></param>
        /// <param name="mapper"></param>
        public SectionsService(
            /*IHttpContextAccessor httpContextAccessor,*/
            ISectionsRepository baseRepository, 
            IMapper mapper
        ) : base(
            (IBaseRepository<Sections>)baseRepository,
            /*httpContextAccessor,*/
            mapper
        )
        {
            _baseRepository = baseRepository;
        }

        /// <summary>
        /// Insere um novo seção
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public ResponseMessages<object> Insert(CreateSectionsModel section)
        {
            try
            {
                var data = Add<CreateSectionsModel, SectionsModel, SectionsValidator>(section);
                return new ResponseMessages<object>(
                    status: true, 
                    data: data, 
                    message: "Seção cadastrada com sucesso."
                );
            }
            catch (Exception ex)
            {
                return new ResponseMessages<object>(
                    status: false, 
                    message: $"Ocorreu um erro: {ex}"
                );
            }
        }

        /// <summary>
        /// Atualiza um registro de seção
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public ResponseMessages<object> Update(UpdateSectionsModel section)
        {
            try
            {
                var data = Update<UpdateSectionsModel, SectionsModel, SectionsValidator>(section);
                // ToDo: persistir alterações em uma tabela para logs
                return new ResponseMessages<object>(
                    status: true,
                    message: "Seção alterada com sucesso."
                );
            }
            catch (Exception ex)
            {
                return new ResponseMessages<object>(
                    status: false,
                    message: $"Ocorreu um erro: { ex.Message }"
                );  
            }
        }

        /// <summary>
        /// Busca registro por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseMessages<object> GetById(long id)
        {
            try
            {
                if (!_baseRepository.Any(x => 
                    x.Id == id &&
                    !x.Deleted
                ))
                    throw new Exception("Registro não encontrado.");
                
                var data = _baseRepository
                    .Query(x => x.Id == id)
                    .Select(s => new
                    {
                        s.Id,
                        s.Name,
                        s.Active,
                        s.CreatedDate,
                    })
                    .FirstOrDefault();

                return new ResponseMessages<object>(
                    status: true,
                    message: "Seção encontrada.",
                    data: data
                );
            }
            catch (Exception ex)
            {
                return new ResponseMessages<object>(
                    status: false,
                    message: $"Erro: { ex.Message }"
                );
            }
        }

        /// <summary>
        /// Deleta um registro de produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseMessages<object> DeleteById(long id)
        {
            try
            {
                LogicalDelete(id);

                return new ResponseMessages<object>(
                    status: true,
                    message: "Seção deletada com sucesso."
                );
            }
            catch (Exception ex)
            {
                return new ResponseMessages<object>(
                    status: false,
                    message: $"Erro: { ex.Message }"
                );
            }
        }

        /// <summary>
        /// Busca lista de todas as seções levando em consideração parametros de filtragem e ordenação
        /// </summary>
        /// <param name="pagingParams"></param>
        /// <returns></returns>
        public async Task<ResponseMessages<object>> Get(PaginatedInputModel pagingParams)
        {
            try
            {
                var products = await GetPaged(pagingParams);

                return new ResponseMessages<object>(
                    status: true,
                    message: "Busca realizada com sucesso.",
                    data: products
                );
            }
            catch (Exception ex)
            {
                return new ResponseMessages<object>(
                    status: false,
                    message: $"Erro: { ex.Message }"
                );
            }
        }
    }
}
