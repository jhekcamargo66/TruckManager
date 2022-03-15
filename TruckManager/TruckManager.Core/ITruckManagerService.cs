using System.Collections.Generic;
using System.Threading.Tasks;
using TruckManager.Core.DTO;
using TruckManager.Repository.Models;

namespace TruckManager.Core
{
    public interface ITruckManagerService
    {
        public Task<int> Insert(TruckModelDTO truckModel);
        public void Update(TruckModelDTO truckModel,int Id);
        public Task Delete(int Id);
        public Task<TruckModel> Get(int Id);
        public IEnumerable<TruckModel> Get();
    }
}