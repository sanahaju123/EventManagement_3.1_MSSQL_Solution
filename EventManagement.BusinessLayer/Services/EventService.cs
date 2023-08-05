using EventManagement.BusinessLayer.Interfaces;
using EventManagement.BusinessLayer.Services.Repository;
using EventManagement.BusinessLayer.ViewModels;
using EventManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.BusinessLayer.Services
{
    public class EventService : IEventServices
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<Event>> GetByName(string name)
        {
            return await _eventRepository.GetByName(name);
        }

        public async Task<IEnumerable<Event>> GetByStatus(string status)
        {
            return await _eventRepository.GetByStatus(status);
        }

        public async Task<Event> GetById(long id)
        {
            return await _eventRepository.GetById(id);
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _eventRepository.GetAll();
        }

        public async Task<Event> Create(Event eventDetails)
        {
            return await _eventRepository.Create(eventDetails);
        }

        public async Task<Event> Update(long id, EventViewModel model)
        {
            return await _eventRepository.Update(id,model);
        }
        public async Task<Event> Delete(long id)
        {
            return await _eventRepository.Delete(id);
        }
    }
}
