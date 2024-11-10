﻿using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IEventService
    {
        public Event GetEventById(int id);
        public List<Event> GetEvents();
        public void AddEvent(Event ev);
        public void UpdateEvent(Event ev);
        public void RemoveEvent(Event ev);
    }
}
