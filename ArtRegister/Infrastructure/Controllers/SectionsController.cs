using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ArtRegister.Application.Interfaces.Services;
using ArtRegister.Infrastructure.Dtos;
using ArtRegister.Domain.Dtos;

namespace ArtRegister.Infrastructure.Controllers
{
    /// <summary>
    /// Controlador para CRUD de seções
    /// </summary>
    [Route("api/Sections")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private readonly ISectionsService _service;
        
        /// <summary>
        /// Endpoints para entidade seção
        /// </summary>
        /// <param name="service"></param>
        public SectionsController(ISectionsService service)
        {
            _service = service;
        }

        /// <summary>
        /// Inserir uma nova seção
        /// </summary>
        /// <param name="sentSection"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] CreateSectionsModel sentSection)
        {
            return Ok(_service.Insert(sentSection));
        }

        /// <summary>
        /// Atualizar uma seção
        /// </summary>
        /// <param name="sentSection"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] UpdateSectionsModel sentSection)
        {
            return Ok(_service.Update(sentSection));
        }

        /// <summary>
        /// Buscar uma seção por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById([FromHeader] long id)
        {
            return Ok(_service.GetById(id));
        }

        /// <summary>
        /// Busca todas as seções
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetPaged")]
        public async Task<IActionResult> GetPaged([FromBody] PaginatedInputModel pagingParams)
        {
            return Ok(await _service.Get(pagingParams));
        }

        /// <summary>
        /// Excluir uma seção por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete([FromHeader] long id)
        {
            return Ok(_service.DeleteById(id));
        }
    }
}
