using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckManager.Controllers;
using TruckManager.Core;
using TruckManager.Core.DTO;
using TruckManager.Repository.Models;
using Xunit;

namespace TruckManager.Tests.Controllers
{
    public class TruckManagerControllerTests
    {
        private readonly Mock<ITruckManagerService> _truckManagerService;
        private readonly TruckManagerController truckManagerController;
        private readonly Fixture _fixture; 
        public TruckManagerControllerTests()
        {
            _truckManagerService = new Mock<ITruckManagerService>();
            truckManagerController = new TruckManagerController(_truckManagerService.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public void GetAll_ReturnOK()
        {
            var result = _fixture.CreateMany<TruckModel>();
            _truckManagerService.Setup((a) => a.Get())
                .Returns(result);

            var data = truckManagerController.Get();

            data.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async void Get_ReturnOK()
        {
            var result = _fixture.Create<TruckModel>();
            var id = _fixture.Create<int>();
            _truckManagerService.Setup((a) => a.Get(id))
                .ReturnsAsync(result);

            var data = await truckManagerController.GetId(id);

            data.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async void Post_ReturnOK()
        {
            var model = _fixture.Create<TruckModelDTO>();
            var id = _fixture.Create<int>();

            model.YearFactory = DateTime.Now.Year;
            model.YearModel = DateTime.Now.Year + 1;

            _truckManagerService.Setup((a) => a.Insert(model))
                .ReturnsAsync(id);

            var data = await truckManagerController.Post(model);

            data.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async void Delete_ReturnOK()
        {
            var model = _fixture.Create<TruckModelDTO>();
            var id = _fixture.Create<int>();

            _truckManagerService.Setup((a) => a.Delete(id));

            var data = await truckManagerController.Delete(id);

            data.Should().BeOfType<OkResult>();
        }
        [Fact]
        public void Update_ReturnOK()
        {
            var model = _fixture.Create<TruckModelDTO>();
            var id = _fixture.Create<int>();

            model.YearFactory = DateTime.Now.Year;
            model.YearModel = DateTime.Now.Year + 1;

            _truckManagerService.Setup((a) => a.Update(model,id));

            var data = truckManagerController.Put(model,id);

            data.Should().BeOfType<OkResult>();
        }
    }
}
