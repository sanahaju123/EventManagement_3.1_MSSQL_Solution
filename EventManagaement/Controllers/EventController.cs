using EventManagement.BusinessLayer.Interfaces;
using EventManagement.BusinessLayer.ViewModels;
using EventManagement.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagaement.Controllers
{
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventServices _eventServices;

        public EventController(IEventServices eventServices)
        {
            _eventServices = eventServices;
        }

      
        /// <summary>
        /// Create a new event
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("events")]
        public async Task<IActionResult> Register([FromBody] EventViewModel model)
        {
            var eventExists = await _eventServices.GetByName(model.Name);
            if (eventExists.Count()!= 0)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Event already exists!" });
            Event evenntDetails = new Event()
            {

                Name = model.Name,
                Description = model.Description,
                Status = model.Status
            };
            var result = await _eventServices.Create(evenntDetails);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Event creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Event created successfully!" });

        }

        /// <summary>
        /// Update a existing Event
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("events/{id}")]
        public async Task<IActionResult> UpdateEvent(long id, [FromBody] EventViewModel model)
        {
            var eventDetails = await _eventServices.GetById(id);
            if (eventDetails == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Event With Id = {id} cannot be found" });
            }
            else
            {
                model.Id = id;
                var result = await _eventServices.Update(id,model);
                return Ok(new Response { Status = "Success", Message = "Event Edited successfully!" });
            }
        }


        /// <summary>
        /// Delete a existing Event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("event/{id}")]
        public async Task<IActionResult> DeleteEvent(long id)
        {
            var evnt = await _eventServices.GetById(id);
            if (evnt == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Event with Id = {id} cannot be found" });
            }
            else
            {
                var result = await _eventServices.Delete(id);
                return Ok(new Response { Status = "Success", Message = "Event deleted successfully!" });
            }
        }

        /// <summary>
        /// Get Event by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("event/{id}")]
        public async Task<IActionResult> GetEventById(long id)
        {
            var politicalParty = await _eventServices.GetById(id);
            if (politicalParty == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Political Party With Id = {id} cannot be found" });
            }
            else
            {
                return Ok(politicalParty);
            }
        }

        /// <summary>
        /// Get Event By Status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("events/searchByStatus")]
        public async Task<IEnumerable<Event>> GetEventByStatus([FromQuery] string status)
        {
            var eventDetails = await _eventServices.GetByStatus(status);
            if (eventDetails == null)
            {
                return (IEnumerable<Event>)StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Event With Status = {status} cannot be found" });
            }
            else
            {
                return (IEnumerable<Event>)(eventDetails);
            }
        }

        /// <summary>
        /// Get Event By Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("events/searchByName")]
        public async Task<IEnumerable<Event>> GetEventByName([FromQuery] string name)
        {
            var eventDetails = await _eventServices.GetByName(name);
            if (eventDetails == null)
            {
                return (IEnumerable<Event>)StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Event With  Name = {name} cannot be found" });
            }
            else
            {
                return (IEnumerable<Event>)(eventDetails);
            }
        }

        /// <summary>
        /// List All Events
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("events")]
        public async Task<IEnumerable<Event>> ListAllEvents()
        {
            return await _eventServices.GetAll();
        }
       
    }
}
