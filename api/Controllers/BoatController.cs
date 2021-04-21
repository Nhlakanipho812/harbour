using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using harbour.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoatController : ControllerBase
    {
        private readonly IBoatService _boatService;
        private readonly ILogger<BoatController> _logger;

        public BoatController(ILogger<BoatController> logger, IBoatService boatService)
        {
            _logger = logger;
            _boatService = boatService;
        }

        [HttpGet("generate-boats")]
        public IActionResult Get()
        {
            var res = _boatService.SchedulingEngine();
            return StatusCode(res.Code, res);
        } 
        [HttpGet("get-boats-transaction")]
        public IActionResult GetAllTransactions()
        {
            var res = _boatService.GetAllTransactions();
            return StatusCode(res.Code, res);
        }
        
        
    }
}