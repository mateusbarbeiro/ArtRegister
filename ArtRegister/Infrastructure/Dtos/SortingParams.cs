using ArtRegister.Infrastructure.Enums;

namespace ArtRegister.Infrastructure.Dtos
{
    public class SortingParams
    {
        /// <summary>
        /// Tipo de ordenação
        /// </summary>
        public SortEnum SortOrder { get; set; } = SortEnum.Asc;

        /// <summary>
        /// Nome da coluna
        /// </summary>
        public string ColumnName { get; set; }
    }
}
