using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace SalonKrasoty
{
    public class Salon
    {
        private List<Service> services = new List<Service>();
    private List<Client> clients = new List<Client>();
    private List<Appointment> appointments = new List<Appointment>();
    
     public void LoadServicesFromFile(string fileName)
    {
            
        if (!File.Exists(fileName))
        {
            Console.WriteLine($"Файл {fileName} не найден. Убедитесь, что файл существует и указан правильный путь.");
            return;
        }
        try
        {
          var lines = File.ReadAllLines(fileName);
            services.Clear();
           foreach (var line in lines)
            {
                try
                {
                    services.Add(Service.Parse(line));
                }
                catch (FormatException e)
                {
                     Console.WriteLine($"Ошибка при чтении строки: '{line}'. Ошибка:{e.Message}");
                }
                
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла {fileName}: {ex.Message}");
        }
    }
    
    public void SaveServicesToFile(string fileName)
    {
        try
        {
            var lines = services.Select(s=>s.ToString()).ToList();
            File.WriteAllLines(fileName, lines);
        }
        catch(Exception e)
        {
             Console.WriteLine($"Ошибка при сохранении файла {fileName}: {e.Message}");
        }
    }

    public void AddService(Service service)
    {
        services.Add(service);
    }

    public void AddClient(Client client)
    {
        clients.Add(client);
    }

     public Client GetOrCreateClient(string name)
    {
       var client =  clients.FirstOrDefault(c => c.Name == name);
       if (client == null)
       {
            client = new Client(name);
            clients.Add(client);
       }
       return client;
    }

     public Service GetServiceByName(string name)
     {
         return services.FirstOrDefault(s=>s.Name == name);
     }

    public void AddAppointment(Appointment appointment)
    {
        appointments.Add(appointment);
    }
    
      public List<Service> GetAllServices()
    {
        return services;
    }

    public string GenerateClientRating()
    {
        var clientVisits = appointments
            .GroupBy(a => a.Client)
            .ToDictionary(g => g.Key, g => g.Count())
            .OrderByDescending(pair => pair.Value);

        var report = "Рейтинг клиентов по частоте посещений:\n";
        foreach (var clientVisit in clientVisits)
        {
            report += $"{clientVisit.Key.Name}: {clientVisit.Value} посещений\n";
        }

        return report;
    }
    

    public string GenerateRevenueReport(DateTime startDate, DateTime endDate)
    {
        var revenue = appointments
            .Where(a => a.Date >= startDate && a.Date <= endDate)
            .Sum(a => a.Service.Price);
        return $"Выручка за период с {startDate:d} по {endDate:d}: {revenue:C}";
    }
    
      public string GenerateEmployeeReport(DateTime startDate, DateTime endDate)
    {
           var employeeRevenue = appointments
                .Where(a => a.Date >= startDate && a.Date <= endDate)
                .GroupBy(a => a.Master)
                .Select(g=> new {Master = g.Key, Revenue = g.Sum(a=>a.Service.Price)})
                .OrderByDescending(e=>e.Revenue)
                .ToList();

        var report = $"Отчет по сотрудникам за период с {startDate:d} по {endDate:d}:\n";
            foreach (var employee in employeeRevenue)
            {
                report += $"{employee.Master}: {employee.Revenue:C}\n";
            }
           return report;
    }


    public void SaveReportToFile(string report, string fileName)
    {
        try
        {
             File.WriteAllText(fileName, report);
        }
        catch (Exception e)
        {
              Console.WriteLine($"Ошибка при сохранении отчета в файл {fileName}: {e.Message}");
        }
    }
    }
}
