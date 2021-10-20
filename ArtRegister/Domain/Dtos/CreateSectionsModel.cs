namespace ArtRegister.Domain.Dtos
{
    /// <summary>
    /// Dto para cadastro de seção
    /// </summary>
    public class CreateSectionsModel
    {
        /// <summary>
        /// Nome
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// Dto para atualizar uma seção
    /// </summary>
    public class UpdateSectionsModel : CreateSectionsModel
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
    /// Dto com informações da seção
    /// </summary>
    public class SectionsModel : UpdateSectionsModel
    {

    }
}
