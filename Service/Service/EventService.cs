using BusinessObjects.Models;
using Repository.IRepository;
using Repository.Repository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class EventService : IEventService
    {
        private IEventRepo eventRepo;
        public EventService()
        {
            eventRepo = new EventRepo();
        }
        public bool AddEvent(Event ev)
        {
            return eventRepo.AddEvent(ev);
        }

        public Event GetEventById(int id)
        {
            return eventRepo.GetEventById(id);
        }

        public List<Event> GetEvents()
        {
            return eventRepo.GetEvents();
        }

        public bool RemoveEvent(Event ev)
        {
            return eventRepo.RemoveEvent(ev);
        }

        public bool UpdateEvent(Event ev)
        {
            return eventRepo.UpdateEvent(ev);
        }
    }
}
