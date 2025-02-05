using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonKrasoty
{
    public class Appointment
    {
        public Client Client { get; set; }
        public Service Service { get; set; }
        public string Master { get; set; }
        public DateTime Date { get; set; }

        public Appointment(Client client, Service service, string master, DateTime date)
        {
            Client = client;
            Service = service;
            Master = master;
            Date = date;
        }
    }
}
