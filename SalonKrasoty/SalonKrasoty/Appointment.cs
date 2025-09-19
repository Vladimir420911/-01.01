using System;
using System.Collections.Generic;
using System.Globalization;
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

        public override string ToString()
        {
            return $"{Client.Name};{Service.Name};{Master};{Date:yyyy-MM-dd}";
        }

        public static Appointment Parse(string line, Salon salon)
        {
            var parts = line.Split(';');
            if (parts.Length != 4)
            {
                throw new FormatException("Неверный формат строки для Appointment.");
            }

            string clientName = parts[0];
            string serviceName = parts[1];
            string master = parts[2];
            DateTime date;

            if (!DateTime.TryParseExact(parts[3], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                throw new FormatException("Неверный формат даты и времени. Ожидается формат Round-trip (O).");
            }

            Client client = salon.GetOrCreateClient(clientName);

            Service service = salon.Services.FirstOrDefault(s => s.Name == serviceName);
            if (service == null)
            {
                throw new FormatException($"Услуга с именем '{serviceName}' не найдена.");
            }

            return new Appointment(client, service, master, date);
        }
    }
}
