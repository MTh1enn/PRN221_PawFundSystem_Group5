using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class EventDAO
    {
        public PawFundContext dbContext;
        public static EventDAO instance;
        public static EventDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventDAO();
                }
                return instance;
            }
        }
        public EventDAO()
        {
            dbContext = new PawFundContext();
        }
        public Event GetEventById(int id)
        {
            return dbContext.Events.SingleOrDefault(m => m.Id.Equals(id));
        }
        public List<Event> GetEvents()
        {
            return dbContext.Events.ToList();
        }
        public void AddEvent(Event ev)
        {
            Event checkEvent = GetEventById(ev.Id);
            try
            {
                if (checkEvent == null)
                {
                    dbContext.Events.Add(ev);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateEvent(Event ev)
        {
            try
            {
                Event checkEvent = GetEventById(ev.Id);
                if (checkEvent != null)
                {
                    dbContext.Entry(checkEvent).State = EntityState.Detached;
                    dbContext.Events.Attach(ev);
                    dbContext.Entry(ev).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void RemoveEvent(Event ev)
        {
            Event checkEvent = GetEventById(ev.Id);
            try
            {
                if (checkEvent != null)
                {
                    dbContext.Events.Remove(ev);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
