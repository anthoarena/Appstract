using AcmeInfrastructure.DTO;
using AcmeInfrastructure.DTO.Wrapper;
using AcmeInfrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ContestController : ControllerBase {

        private readonly ILogger<ContestController> _logger;
        private readonly IContest _repo;

        public ContestController(ILogger<ContestController> logger, IContest repo) {
            _logger = logger;
            _repo = repo;
        }



        /// <summary>
        /// Create new contestant 
        /// </summary>
        /// <param name="contestant"></param>
        /// <returns>
        /// Success or Error message
        /// </returns>
        [Route("contestant")]
        [HttpPost]
        public IActionResult NewContestant([FromBody] ContestantRequestDTO contestant) {
            try {             
                bool created = _repo.NewContestant(contestant);
                if (!created) 
                    return BadRequest("Contestant not created");
                               
                return Ok();
            }
            catch (Exception) {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Return all contest's participants with their info 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Route("contestant")]
        [HttpGet]
        public IActionResult GetAllContestants([FromQuery] PaginationFilter filter) {
            try {
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var pagedData = _repo.AllContestant()?
                   .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                   .Take(validFilter.PageSize).ToList();

                return Ok(pagedData);
            }
            catch(Exception) {
                _logger.Log(LogLevel.Error, "GetAllContestant");
                return BadRequest("An error has occured please try again");
            }
       
        }

    }
}
