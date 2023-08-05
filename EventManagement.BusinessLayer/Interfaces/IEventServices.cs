using EventManagement.BusinessLayer.ViewModels;
using EventManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.BusinessLayer.Interfaces
{
    public interface IEventServices
    {
        Task<Event> Create(Event eventDatails);
        Task<Event> GetById(long eventId);
        Task<IEnumerable<Event>> GetByName(string name);
        Task<IEnumerable<Event>> GetByStatus(string status);
        Task<Event> Update(long eventId,EventViewModel model);
        Task<Event> Delete(long eventId);
        Task<IEnumerable<Event>> GetAll();
    }
}
