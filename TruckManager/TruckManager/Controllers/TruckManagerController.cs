using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckManager.Core;

namespace TruckManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TruckManagerController : ControllerBase
    {
        private readonly ITruckManagerService _truckManagerService;

        public TruckManagerController(ITruckManagerService truckManagerService)
        {
            _truckManagerService = truckManagerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_truckManagerService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
