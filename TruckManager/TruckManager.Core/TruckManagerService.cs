using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruckManager.Core.DTO;
using TruckManager.Repository;
using TruckManager.Repository.Models;

namespace TruckManager.Core
{
    public class TruckManagerService : ITruckManagerService
    {
        private readonly ITruckModelRepository _truckModelRepository;

        public TruckManagerService(ITruckModelRepository truckManagerRepository)
        {
            _truckModelRepository = truckManagerRepository;
        }
        public async Task Delete(int Id)
        {
            await _truckModelRepository.Delete(Id);
        }

        public async Task<TruckModel> Get(int Id)
        {
            var value = await _truckModelRepository.Get(Id);
            return value;
        }

        public IEnumerable<TruckModel> Get()
        {
            return _truckModelRepository.Get();
        }

        public async Task<int> Insert(TruckModelDTO truckModel)
        {
            if (truckModel.YearModel < DateTime.Now.Year)
            {
                throw new Exception($"The model year must be at least {DateTime.Now.Year}");
            }

            if (truckModel.YearFactory < DateTime.Now.Year)
            {
                throw new Exception($"The factory year must be {DateTime.Now.Year}");
            }

            if (truckModel.Description  != "FH" && truckModel.Description != "FM")
            {
                throw new Exception($"The model Model must be FH or FM");
            }

            var id = await _truckModelRepository.Insert(new TruckModel
            {
                Description = truckModel.Description,
                YearFactory = truckModel.YearFactory,
                YearModel = truckModel.YearModel
            });

            return id;
        }

        public void Update(TruckModelDTO truckModel,int Id)
        {
            if (truckModel.YearModel < DateTime.Now.Year)
            {
                throw new Exception($"The model year must be at least {DateTime.Now.Year}");
            }

            if (truckModel.YearFactory < DateTime.Now.Year)
            {
                throw new Exception($"The factory year must be {DateTime.Now.Year}");
            }

            if (truckModel.Description != "FH" && truckModel.Description != "FM")
            {
                throw new Exception($"The model Model must be FH or FM");
            }

            _truckModelRepository.Update(new TruckModel
            {
                Id = Id,
                Description = truckModel.Description,
                YearFactory = truckModel.YearFactory,
                YearModel = truckModel.YearModel
            });
        }
    }
}
