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

    }
}
