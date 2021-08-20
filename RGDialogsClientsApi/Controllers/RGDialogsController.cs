using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RGDialogsClientsApi.Infrastructure.Services;
using RGDialogsClientsApi.Model.Domain;

using System.Net;
using System.Threading.Tasks;

namespace RGDialogsClientsApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RGDialogsController : ControllerBase
    {
        private readonly ILogger<RGDialogsController> _logger;
        private readonly IRGDialogsService _rGDialogsService;

        public RGDialogsController(IRGDialogsService rGDialogsService, ILogger<RGDialogsController> logger)
        {
            _rGDialogsService = rGDialogsService;
            _logger = logger;
        }

        // Post api/v1/[controller]/
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="iDClients"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        [Route("Get")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Get(IDClients iDClients)
        {
            try
            {
                var res = await _rGDialogsService.Find(iDClients);
                return Ok(res);
            }
            catch (System.Exception e)
            {
                _logger.LogError($"Get has error:{e.Message}", e);
                throw;
            }
        }
    }
}