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
    /// Produtos
    /// </summary>
    public class ProductsService : BaseService<Products>, IProductsService
    {
        private IProductsRepository _baseRepository;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="baseRepository"></param>
        /// <param name="mapper"></param>
        public ProductsService(
            /*IHttpContextAccessor httpContextAccessor,*/
            IProductsRepository baseRepository, 
            IMapper mapper
        ) : base(
            (IBaseRepository<Products>)baseRepository,
            /*httpContextAccessor,*/
            mapper
        )
        {
            _baseRepository = baseRepository;
        }

        /// <summary>
        /// Insere um novo produto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ResponseMessages<object> Insert(CreateProductsModel product)
        {
            try
            {
                var data = Add<CreateProductsModel, ProductsModel, ProductsValidator>(product);
                return new ResponseMessages<object>(
                    status: true, 
                    data: data, 
                    message: "Produto cadastrado com sucesso."
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
        /// Atualiza um registro de produto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ResponseMessages<object> Update(UpdateProductsModel product)
        {
            try
            {
                var data = Update<UpdateProductsModel, ProductsModel, ProductsValidator>(product);
                // ToDo: persistir alterações em uma tabela para logs
                return new ResponseMessages<object>(
                    status: true,
                    message: "Produto alterado com sucesso."
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
                        s.Description,
                        s.Price,
                        s.PhotoUrl,
                        s.SectionId,
                        s.Active,
                        s.CreatedDate,
                    })
                    .FirstOrDefault();

                return new ResponseMessages<object>(
                    status: true,
                    message: "Produto encontrado.",
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
                    message: "Produto deletado com sucesso."
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
        /// Busca lista de todos produtos levando em consideração parametros de filtragem e ordenação
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

        /// <summary>
        /// Busca todos registros
        /// </summary>
        /// <returns></returns>
        public ResponseMessages<object> GetAll()
        {
            try
            {
                if (!_baseRepository.Any(x =>!x.Deleted))
                    throw new Exception("Registro não encontrado.");

                var data = _baseRepository
                    .Query(x => !x.Deleted)
                    .Select(s => new
                    {
                        Id = s.Id.ToString(),
                        Nome = s.Name,
                        Foto = isUrl(s.PhotoUrl)
                           ? s.PhotoUrl
                           : null,
                        SecaoId = s.SectionId,
                        SecaoNome = s.Section.Name,
                        Preco = s.Price
                    })
                    .ToList();

                return new ResponseMessages<object>(
                    status: true,
                    message: "Produto encontrado.",
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
        /// Verifica se url é uma url de fato
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static bool isUrl(string url)
        {
            Uri uriResult;

            return Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
