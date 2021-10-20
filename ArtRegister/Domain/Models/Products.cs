using ArtRegister.Domain.Models.CommonModels;
using System.Collections.Generic;

namespace ArtRegister.Domain.Models
{
    /// <summary>
    /// Entidade produtos
    /// </summary>
    public partial class Products : BaseEntity
    {
        public Products()
        {
            
        }

        /// <summary>
        /// Nome
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Preço
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Id da seção vinculada
        /// </summary>
        public long SectionId { get; set; }

        /// <summary>
        /// Seção
        /// </summary>
        public Sections Section { get; set; }
    }
}
