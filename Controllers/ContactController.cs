using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using csharp_webapi.Services;
using csharp_webapi.Entities;

namespace csharp_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly ContactService _service;

        public ContactController(ILogger<ContactController> logger, ContactService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetAll()
        {
            _logger.LogInformation("get contact");
            return Ok(_service.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> GetById(int id)
        {
            var contact = _service.FindById(id);
            if (contact != null) {
                _logger.LogInformation($"get contact/{id}");
                return Ok(contact);
            }

            _logger.LogInformation($"get contact/{id} not found");
            return NotFound();
        }
    }
}
