using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using MimeKit;
using ProConfitec.Application.DTOs;
using ProConfitec.Application.Services;
using ProConfitec.Application.Services.Interfaces;
using ProConfitec.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProConfitec.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IFileRepository _file;
        private IWebHostEnvironment _environment;

        public UsersController(IUserService service, IFileRepository file, IWebHostEnvironment environment)
        {
            _service = service;
            _file = file;
            _environment = environment;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var projects = await _service.GetAsync();
            return Ok(projects);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDetailDTO user)
        {            
            var projects = await _service.CreateAsync(user);
            return Ok(projects);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var projects = await _service.GetByIdAsync(id);
            return Ok(projects);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var projects = await _service.DeleteAsync(id);
            return Ok(projects);
        }

        [HttpPut]        
        public async Task<ActionResult> UpdateAsync([FromBody] UserDTO user)
        {
            var result = await _service.UpdateAsync(user);            
            return Ok(result);           
        }

        [HttpGet]
        [Route("download")]
        public IActionResult DownloadAsync([FromQuery] string file, int id)
        {
            string contentType = "";
            new FileExtensionContentTypeProvider().TryGetContentType(file, out contentType);
            string filePath = _file.GetFileDownloadAsync(file, id);
            return new PhysicalFileResult(filePath, contentType);

        }






    }
}
