using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using SystemResourcesDemonstrator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SystemResourcesDemonstrator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemResourcesController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetResources()
        {
            SystemResource resources = new SystemResource();
            return new JsonResult(resources);
        }
    }
}
