using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckManager.Core;
using TruckManager.Core.DTO;
using TruckManager.Repository.Models;

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
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetId(int Id)
        {
            try
            {
                return Ok(await _truckManagerService.Get(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(TruckModelDTO truckModel)
        {
            try
            {
                var result =await _truckManagerService.Insert(truckModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("{Id}")]
        public IActionResult Put(TruckModelDTO truckModel,int Id)
        {
            try
            {
                _truckManagerService.Update(truckModel,Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                 await _truckManagerService.Delete(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
