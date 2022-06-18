using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProConfitec.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProConfitec.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScholaritiesController : ControllerBase
    {
        private readonly IScholarityService _service;
        public ScholaritiesController(IScholarityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var scolarities = await _service.GetAsync();
            return Ok(scolarities);
        }
    }
}
