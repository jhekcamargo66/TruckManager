using AutoFixture;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckManager.Core;
using TruckManager.Core.DTO;
using TruckManager.Repository;
using TruckManager.Repository.Models;
using Xunit;

namespace TruckManager.Tests.Services
{
    public class TruckManagerServiceTest
    {
        private readonly Mock<ITruckModelRepository> _truckModelRepository;
        private readonly TruckManagerService truckManagerService;
        private readonly Fixture _fixture;
        public TruckManagerServiceTest()
        {
            _truckModelRepository = new Mock<ITruckModelRepository>();
            truckManagerService = new TruckManagerService(_truckModelRepository.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public void GetAll_ReturnOK()
        {
            var result = _fixture.CreateMany<TruckModel>();
            _truckModelRepository.Setup((a) => a.Get())
                .Returns(result);

            var data = truckManagerService.Get();

            data.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async void Get_ReturnOK()
        {
            var result = _fixture.Create<TruckModel>();
            var id = _fixture.Create<int>();
            _truckModelRepository.Setup((a) => a.Get(id))
                .ReturnsAsync(result);

            var data = await truckManagerService.Get(id);

            data.Should().BeOfType<TruckModel>();
        }

        [Fact]
        public async void Post_ReturnOK()
        {
            var model = _fixture.Create<TruckModelDTO>();
            var id = _fixture.Create<int>();

            model.YearFactory = DateTime.Now.Year;
            model.YearModel = DateTime.Now.Year + 1;
            model.Description = "FM";

            _truckModelRepository.Setup((a) => a.Insert(new TruckModel
            {
                Description = model.Description,
                YearModel = model.YearModel,
                YearFactory = model.YearFactory
            }))
                .ReturnsAsync(id);

            var data = await truckManagerService.Insert(model);
        }

        [Fact]
        public async void Delete_ReturnOK()
        {
            var model = _fixture.Create<TruckModelDTO>();
            var id = _fixture.Create<int>();

            _truckModelRepository.Setup((a) => a.Delete(id));

            await truckManagerService.Delete(id);
        }
        [Fact]
        public void Update_ReturnOK()
        {
            var model = _fixture.Create<TruckModelDTO>();
            var id = _fixture.Create<int>();

            model.YearFactory = DateTime.Now.Year;
            model.YearModel = DateTime.Now.Year + 1;
            model.Description = "FM";
            _truckModelRepository.Setup((a) => a.Update(new TruckModel
            {
                Description = model.Description,
                YearFactory = model.YearFactory,
                YearModel = model.YearModel,
                Id = id
            }));

            truckManagerService.Update(model, id);
        }
    }
}
