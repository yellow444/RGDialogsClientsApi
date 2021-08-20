using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using RGDialogsClientsApi.Infrastructure.Repositories;
using RGDialogsClientsApi.Model.Domain;
using RGDialogsClientsApi.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RGDialogsClientsApi.Infrastructure.Services.Tests
{
    [TestClass()]
    public class RGDialogsServiceTests
    {
        private readonly Mock<RGDialogsRepository> _rGDialogsRepository;
        private readonly RGDialogsService _rGDialogsService;
        private readonly Mock<ILogger<RGDialogsService>> _logger;

        public RGDialogsServiceTests()
        {
            
            _rGDialogsRepository = new Mock<RGDialogsRepository>();
            _logger = new Mock<ILogger<RGDialogsService>>();
            _rGDialogsService = new RGDialogsService(_rGDialogsRepository.Object, _logger.Object) ;
        }

        [TestMethod()]
        public  void FindTest()
        {
            var fakeUser = Guid.Parse("4b6a6b9a-2303-402a-9970-6e71f4a47151");
            var fakeDialog = Guid.Parse("fcd6b112-1834-4420-bee6-70c9776f6378");
            var client = new IDClients() { Guids = new List<Guid>() { {  fakeUser } } };
            _rGDialogsRepository.SetupGet(x=>x.RGDialogsClients).Returns( new List<RGDialogsClients>() { { new RGDialogsClients() { IDClient= fakeUser, IDRGDialog= fakeDialog, IDUnique = new Guid() } } });
           var res = _rGDialogsService.Find(client).Result;
            Assert.AreEqual(res,fakeDialog);
            res = _rGDialogsService.Find(new IDClients() { Guids = new List<Guid>() { { new Guid() } } }).Result;
            Assert.AreEqual(res,Guid.Empty);
        }
    }
}