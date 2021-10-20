namespace ArtRegister.Domain.Dtos
{
    /// <summary>
    /// Modelo para criação de produto
    /// </summary>
    public class CreateProductsModel
    {
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
        /// Id da seção
        /// </summary>
        public long SectionId { get; set; }
    }

    /// <summary>
    /// Dto para atualizar um produto
    /// </summary>
    public class UpdateProductsModel : CreateProductsModel
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Está ativo?
        /// </summary>
        public bool Active { get; set; }
    }

    /// <summary>
    /// Dto com informações do produto
    /// </summary>
    public class ProductsModel : UpdateProductsModel
    {

    }
}
