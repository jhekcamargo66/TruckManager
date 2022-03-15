using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckManager.Repository.Models;

namespace TruckManager.Repository
{
    public class TruckModelRepository : ITruckModelRepository
    {
        private readonly Context _context;

        public TruckModelRepository(Context context)
        {
            _context = context;
        }
        public async Task Delete(int Id)
        {
            var data = await _context.TruckModel.FindAsync(Id);
            _context.TruckModel.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<TruckModel> Get(int Id)
        {
            var data = await _context.TruckModel.FindAsync(Id);
            return data;
        }

        public IEnumerable<TruckModel> Get()
        {
            return _context.TruckModel;
        }

        public async Task<int> Insert(TruckModel truckModel)
        {
            var result =await _context.TruckModel.AddAsync(truckModel);
            _context.SaveChanges();

            return result.Entity.Id;
        }

        public void Update(TruckModel truckModel)
        {
            var entity = _context.TruckModel.Find(truckModel.Id);

            if (entity == null)
            {
                return;
            }

            _context.Entry(entity).CurrentValues.SetValues(truckModel);

            _context.SaveChanges();
        }
    }
}
