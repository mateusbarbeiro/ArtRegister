using ArtRegister.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtRegister.Infrastructure.Controllers
{
    /// <summary>
    /// Controlador para items de dropdown
    /// </summary>
    [Route("api/Select")]
    [ApiController]
    public class SelectController : ControllerBase
    {
        private readonly ISelectService _service;

        /// <summary>
        /// Construtor para controller de busca para items de dropdown
        /// </summary>
        /// <param name="service"></param>
        public SelectController(ISelectService service)
        {
            _service = service;
        }

        /// <summary>
        /// Select de seções
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("SelectSections")]
        public IActionResult SelectSections()
        {
            return Ok(_service.GetSelectSections());
        }
    }
}
