﻿using BusinessObjects.Models;
using DAO;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class EventRepo : IEventRepo
    {
        public void AddEvent(Event ev)
        => EventDAO.Instance.AddEvent(ev);

        public Event GetEventById(int id)
        => EventDAO.Instance.GetEventById(id);

        public List<Event> GetEvents()
        => EventDAO.Instance.GetEvents();

        public void RemoveEvent(Event ev)
        => EventDAO.Instance.RemoveEvent(ev);

        public void UpdateEvent(Event ev)
        => EventDAO.Instance.UpdateEvent(ev);
    }
}
