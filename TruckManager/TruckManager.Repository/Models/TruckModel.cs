using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckManager.Repository.Models
{
    public class TruckModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int YearFactory { get; set; }
        public int YearModel { get; set; }
    }
}
