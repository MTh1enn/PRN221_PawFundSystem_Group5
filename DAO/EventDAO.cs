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
        public bool AddEvent(Event ev)
        {
            bool isSuccess = false;
            Event checkEvent = GetEventById(ev.Id);
            try
            {
                if (checkEvent == null)
                {
                    ev.Status = "SCHEDULED";
                    dbContext.Events.Add(ev);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Lỗi xảy ra khi lưu thay đổi:");
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }
        public bool UpdateEvent(Event ev)
        {
            try
            {
                bool isSuccess = false;
                Event checkEvent = GetEventById(ev.Id);
                if (checkEvent != null)
                {
                    dbContext.Entry(checkEvent).State = EntityState.Detached;
                    dbContext.Events.Attach(ev);
                    dbContext.Entry(ev).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool RemoveEvent(Event ev)
        {
            Event checkEvent = GetEventById(ev.Id);
            try
            {
                bool isSuccess = false;
                if (checkEvent != null && ev.Status.Equals("SCHEDULED"))
                {
                    ev.Status = "CANCELLED";
                    dbContext.Entry(checkEvent).State = EntityState.Detached;
                    dbContext.Events.Attach(ev);
                    dbContext.Entry(ev).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
