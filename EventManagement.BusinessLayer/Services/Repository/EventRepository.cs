using EventManagement.BusinessLayer.ViewModels;
using EventManagement.DataLayer;
using EventManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.BusinessLayer.Services.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly EventManagementDbContext _DbContext;
        public EventRepository(EventManagementDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<Event> GetById(long id)
        {
            try
            {
                return await _DbContext.Events.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Event>> GetByName(string name)
        {
            try
            {
                var result = _DbContext.Events.Where(p => p.Name.ToLower() == name.ToLower()).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Event>> GetByStatus(string status)
        {
            try
            {
                var result = _DbContext.Events.Where(p => p.Status.ToLower() == status.ToLower()).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            try
            {
                var result = _DbContext.Events.
                OrderByDescending(x => x.Id).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Event> Create(Event eventDetails)
        {
            try
            {
                var result = await _DbContext.Events.AddAsync(eventDetails);
                await _DbContext.SaveChangesAsync();
                return eventDetails;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Event> Update(long eventId, EventViewModel model)
        {
            var Event = await _DbContext.Events.FindAsync(eventId);
            try
            {

                Event.Name = model.Name;
                Event.Description = model.Description;
                Event.Status = model.Status;


                _DbContext.Events.Update(Event);
                await _DbContext.SaveChangesAsync();
                return Event;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Event> Delete(long eventId)
        {
            var Event = await _DbContext.Events.FindAsync(eventId);
            try
            {
                _DbContext.Events.Remove(Event);
                await _DbContext.SaveChangesAsync();
                return Event;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
