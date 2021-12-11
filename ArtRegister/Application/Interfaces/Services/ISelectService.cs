using ArtRegister.Infrastructure.Dtos;

namespace ArtRegister.Application.Interfaces.Services
{
    /// <summary>
    /// Interface para serviço busca de itens de dropdown
    /// </summary>
    public interface ISelectService
    {
        /// <summary>
        /// Select de seções
        /// </summary>
        /// <returns></returns>
        ResponseMessages<object> GetSelectSections();
    }
}
