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
        public void AddEvent(Event ev)
        {
            eventRepo.AddEvent(ev);
        }

        public Event GetEventById(int id)
        {
            return eventRepo.GetEventById(id);
        }

        public List<Event> GetEvents()
        {
            return eventRepo.GetEvents();
        }

        public void RemoveEvent(Event ev)
        {
            eventRepo.RemoveEvent(ev);
        }

        public void UpdateEvent(Event ev)
        {
            eventRepo.UpdateEvent(ev);
        }
    }
}
