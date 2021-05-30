using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using csharp_webapi.Services;
using csharp_webapi.Entities;
using csharp_webapi.Models;

namespace csharp_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase, IContactController
    {
        private readonly ILogger<ContactController> _logger;
        private readonly ContactService _service;

        public ContactController(ILogger<ContactController> logger, ContactService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Contact>), 200)]
        public ActionResult<IEnumerable<Contact>> GetAll()
        {
            _logger.LogInformation("get contact");
            return Ok(_service.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Contact), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        public ActionResult<Contact> GetById([Required] int id)
        {
            var contact = _service.FindById(id);
            if (contact != null) {
                _logger.LogInformation($"get contact/{id}");
                return Ok(contact);
            }

            _logger.LogInformation($"get contact/{id} not found");
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public ActionResult<int> Save([FromBody] ContactModel model)
        {
            _logger.LogInformation("save contact");
            var newId = _service.Save(model.ToContact());
            return Ok(newId);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EmptyResult), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        public ActionResult<EmptyResult> Delete([Required] int id)
        {
            var success = _service.Delete(id);
            if (success) {
                _logger.LogInformation($"delete contact {id}");
                return Ok();
            }

            _logger.LogInformation($"fail to delete contact {id}");
            return NotFound();
        }
    }
}
