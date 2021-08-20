using RGDialogsClientsApi.Models;

using System.Collections.Generic;

namespace RGDialogsClientsApi.Infrastructure.Repositories
{
    public class RGDialogsRepository
    {
        private readonly List<RGDialogsClients> _rGDialogsClients;

        public RGDialogsRepository()
        {
            _rGDialogsClients = new RGDialogsClients().Init();
        }
        virtual public List<RGDialogsClients> RGDialogsClients { get => _rGDialogsClients; }
    }
}