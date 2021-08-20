using Microsoft.Extensions.Logging;

using RGDialogsClientsApi.Infrastructure.Repositories;
using RGDialogsClientsApi.Model.Domain;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace RGDialogsClientsApi.Infrastructure.Services
{
    public interface IRGDialogsService
    {
        Task<Guid> Find(IDClients iDClients);
    }

    public class RGDialogsService : IRGDialogsService
    {
        private readonly RGDialogsRepository _rGDialogsRepository;
        private readonly ILogger<RGDialogsService> _logger;

        public RGDialogsService(RGDialogsRepository rGDialogsRepository, ILogger<RGDialogsService> logger)
        {
            _rGDialogsRepository = rGDialogsRepository;
            _logger = logger;
        }

        public Task<Guid> Find(IDClients iDClients)
        {
            var rGDialogsList = _rGDialogsRepository.RGDialogsClients;
            var result = rGDialogsList.FirstOrDefault(x => rGDialogsList.Where(y => y.IDRGDialog.Equals(x.IDRGDialog)).Select(y => y.IDClient).ToList().OrderBy(y => y).SequenceEqual(iDClients.Guids.OrderBy(g => g)))?.IDRGDialog ?? Guid.Empty;
            _logger.LogInformation($"Find Guid{result}");
            return Task.FromResult(result);
        }
    }
}