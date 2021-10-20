using ArtRegister.Domain.Models.CommonModels;
using System.Collections.Generic;

namespace ArtRegister.Domain.Models
{
    /// <summary>
    /// Entidade seções
    /// </summary>
    public partial class Sections : BaseEntity
    {
        /// <summary>
        /// Construção de seção
        /// </summary>
        public Sections()
        {
            Products = new HashSet<Products>();
        }
        /// <summary>
        /// Nome
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Produtos de uma seção
        /// </summary>
        public ICollection<Products> Products { get; set; }
    }
}
