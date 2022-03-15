using System.Collections.Generic;
using System.Threading.Tasks;
using TruckManager.Repository.Models;

namespace TruckManager.Repository
{
    public interface ITruckModelRepository
    {
        public Task<int> Insert(TruckModel truckModel);
        public void Update(TruckModel truckModel);
        public Task Delete(int Id);
        public Task<TruckModel> Get(int Id);
        public IEnumerable<TruckModel> Get();

    }
}