using ArtRegister.Application.Interfaces.Repository;
using ArtRegister.Application.Interfaces.Services;
using ArtRegister.Infrastructure.Dtos;
using System;
using System.Linq;

namespace ArtRegister.Application.Services
{
    /// <summary>
    /// Serviço para busca de itens de dropdown
    /// </summary>
    public class SelectService : ISelectService
    {
        private ISectionsRepository _baseRepository;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="baseRepository"></param>
        public SelectService(ISectionsRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        /// <summary>
        /// Busca seções
        /// </summary>
        /// <returns></returns>
        public ResponseMessages<object> GetSelectSections()
        {
            try
            {
                var data = _baseRepository
                .Query(x => x.Active && !x.Deleted)
                .Select(s => new
                {
                    Value = s.Id,
                    Label = s.Name
                })
                .ToList();

                return new ResponseMessages<object>(
                    status: true,
                    data: data,
                    message: "Seções buscadas com sucesso."
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
