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

        public ContestController(ILogger<ContestController> logger) {
            _logger = logger;
        }
    }
}
