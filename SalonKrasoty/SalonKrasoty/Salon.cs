using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace SalonKrasoty
{
    public class Salon
    {
        public List<Service> Services = new List<Service>();
        public List<Client> Clients = new List<Client>();
        public List<Appointment> Appointments = new List<Appointment>();

        public void LoadServicesFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"Файл {filename} не найден. Убедитесь, что файл существует и указан правильный путь.");
                return;
            }
            try
            {
                var lines = File.ReadAllLines(filename);
                Services.Clear();
                foreach (var line in lines)
                {
                    try
                    {
                        Services.Add(Service.Parse(line));
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine($"Ошибка при чтении строки: '{line}'. Ошибка:{e.Message}");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла {filename}: {ex.Message}");
            }
        }

        public void SaveServicesToFile(string filename)
        {
            try
            {
                File.WriteAllLines(filename, Services.Select(s => s.ToString()));
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении отчета в файл {filename}: {ex.Message}");
            }
        }

        public void SaveReportToFile(string filename, string report)
        {
            try
            {
                File.WriteAllText(filename, report);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении отчета в файл {filename}: {ex.Message}");
            }
        }

        public Client GetOrCreateClient(string name)
        {
            var client = Clients.FirstOrDefault(c => c.Name == name);
            if (client == null)
            {
                client = new Client(name);
                Clients.Add(client);
            }
            return client;
        }

        public void AddAppointment(Client client, Service service, string master, DateTime date)
        {
            Appointments.Add(new Appointment(client, service, master, date));
        }

        public string GenerateClientRating(DateTime startDate, DateTime endDate)
        {
            var rating = Appointments
                .Where(a => a.Date >= startDate && a.Date <= endDate)
                .GroupBy(a => a.Client)
                .OrderByDescending(g => g.Count())
                .Select(g => $"{g.Key.Name}: {g.Count()} посещений");

            return $"Рейтинг клиентов за период {startDate:d} - {endDate:d}:\n" + string.Join("\n", rating);
        }

        public string GenerateRevenueReport(DateTime startDate, DateTime endDate)
        {
            decimal revenue = Appointments
                .Where(a => a.Date >= startDate && a.Date <= endDate)
                .Sum(a => a.Service.Price);

            return $"Выручка за период {startDate:d} - {endDate:d}: {revenue:C}";
        }

        public string GenerateEmployeeReport(DateTime startDate, DateTime endDate)
        {
            var report = Appointments
                .Where(a => a.Date >= startDate && a.Date <= endDate)
                .GroupBy(a => a.Master)
                .OrderByDescending(g => g.Sum(a => a.Service.Price))
                .Select(g => $"{g.Key}: {g.Sum(a => a.Service.Price):C}");

            return "Отчет по сотрудникам:\n" + string.Join("\n", report);
        }

        public void SaveAppointmentsToFile(string filename)
        {
            try
            {
                File.WriteAllLines(filename, Appointments.Select(a => a.ToString()));
                Console.WriteLine("Записи сохранены в файл");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении записей в файл: {ex.Message}");
            }
        }

        public void LoadAppointmentsFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"Файл {filename} не найден. Убедитесь, что файл существует и указан правильный путь.");
                return;
            }

            try
            {
                var lines = File.ReadAllLines(filename);
                Appointments.Clear();
                foreach (var line in lines)
                {
                    try
                    {
                        Appointments.Add(Appointment.Parse(line, this));
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine($"Ошибка при чтении строки: '{line}'. Ошибка: {e.Message}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Общая ошибка при обработке строки: '{line}'. Ошибка: {e.Message}");
                    }
                }
                Console.WriteLine("Записи загружены из файла");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла {filename}: {ex.Message}");
            }
        }
    }
}
