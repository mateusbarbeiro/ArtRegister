using ArtRegister.Application.Interfaces.Repository;
using ArtRegister.Domain.Models;
using ArtRegister.Infrastructure.Context;

namespace ArtRegister.Infrastructure.Repository
{
    /// <summary>
    /// Repositório para seções
    /// </summary>
    public class SectionsRepository : BaseRepository<Sections>, ISectionsRepository
    {
        public SectionsRepository(ApiContext context) : base (context)
        {

        }
    }
}