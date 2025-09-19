using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonKrasoty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var salon = new Salon();
            const string servicesFile = "services.txt";
            const string appointmentsFile = "appointments.txt";

            try
            {
                salon.LoadServicesFromFile(servicesFile);
                salon.LoadAppointmentsFromFile(appointmentsFile);
                Console.WriteLine("Данные услуг успешно загружены");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки услуг: {ex.Message}");
            }

            while (true)
            {
                Console.WriteLine("\n=== САЛОН КРАСОТЫ ===");
                Console.WriteLine("1. Управление услугами");
                Console.WriteLine("2. Запись клиентов");
                Console.WriteLine("3. Отчеты");
                Console.WriteLine("4. Выход");
                Console.Write("Выберите действие: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ServicesMenu(salon, servicesFile);
                        break;
                    case "2":
                        AppointmentsMenu(salon, appointmentsFile);
                        break;
                    case "3":
                        ReportsMenu(salon);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
      
        }

        static void ServicesMenu(Salon salon, string servicesFile)
        {
            while (true)
            {
                Console.WriteLine("\n--- УПРАВЛЕНИЕ УСЛУГАМИ ---");
                Console.WriteLine("1. Показать все услуги");
                Console.WriteLine("2. Добавить услугу");
                Console.WriteLine("3. Сохранить в файл");
                Console.WriteLine("4. Назад");
                Console.Write("Выберите действие: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowAllServices(salon);
                        break;
                    case "2":
                        AddService(salon);
                        break;
                    case "3":
                        salon.SaveServicesToFile(servicesFile);
                        Console.WriteLine("Услуги сохранены в файл");
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }

        static void ShowAllServices(Salon salon)
        {
            Console.WriteLine("\nСписок услуг:");
            foreach (var service in salon.Services)
            {
                Console.WriteLine($"{service.Name} - {service.Price:C} (Мастера: {string.Join(", ", service.Masters)})");
            }
        }

        static void AddService(Salon salon)
        {
            Console.Write("Название услуги: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Название не должно быть пустым!");
                return;
            }

            Console.Write("Цена: ");
            decimal price;
            bool success = decimal.TryParse(Console.ReadLine(), out price);
            if(!success)
            {
                Console.WriteLine("Неверный формат цены. Введите число");
                return;
            }

            Console.Write("Мастера (через запятую): ");
            var masters = Console.ReadLine().Split(',').Select(m => m.Trim()).ToList();

            salon.Services.Add(new Service(name, price, masters));
            Console.WriteLine("Услуга добавлена!");
        }

        static void AppointmentsMenu(Salon salon, string appointmentsFile)
        {
            while (true)
            {
                Console.WriteLine("\n--- ЗАПИСЬ КЛИЕНТОВ ---");
                Console.WriteLine("1. Новая запись");
                Console.WriteLine("2. Список всех записей");
                Console.WriteLine("3. Сохранить записи в файл");
                Console.WriteLine("4. Назад");
                Console.Write("Выберите действие: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddAppointment(salon);
                        break;
                    case "2":
                        ShowAllAppointments(salon);
                        break;
                    case "3":
                        salon.SaveAppointmentsToFile(appointmentsFile);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }

        static void AddAppointment(Salon salon)
        {
            Console.Write("Имя клиента: ");
            string clientName = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(clientName))
            {
                Console.WriteLine("Введите имя");
                return;
            }
            var client = salon.GetOrCreateClient(clientName);

            Console.WriteLine("\nДоступные услуги:");
            for (int i = 0; i < salon.Services.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {salon.Services[i].Name}");
            }

            Console.Write("Выберите услугу: ");
            int serviceIndex;
            bool isInt = int.TryParse(Console.ReadLine(), out serviceIndex);
            if(!isInt || serviceIndex > salon.Services.Count)
            {
                Console.WriteLine("Не правильный номер");
                return;
            }
            serviceIndex = serviceIndex - 1;

            var service = salon.Services[serviceIndex];

            Console.WriteLine($"Доступные мастера: {string.Join(", ", service.Masters)}");
            Console.Write("Выберите мастера: ");
            string master = Console.ReadLine();
            if(!service.Masters.Any(m => m.Equals(master.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Данного мастера нет в списке");
                return;
            }
            

            Console.Write("Дата (гггг-мм-дд): ");
            DateTime date;
            bool isDate = DateTime.TryParse(Console.ReadLine(), out date);
            if (!isDate)
            {
                Console.WriteLine("Неверный формат даты");
                return;
            }

            salon.AddAppointment(client, service, master, date);
            Console.WriteLine("Запись добавлена!");
        }

        static void ShowAllAppointments(Salon salon)
        {
            Console.WriteLine("\nВсе записи:");
            foreach (var app in salon.Appointments)
            {
                Console.WriteLine($"{app.Date:d}: {app.Client.Name} - {app.Service.Name} ({app.Master})");
            }
        }

        static void ReportsMenu(Salon salon)
        {
            while (true)
            {
                Console.WriteLine("\n--- ОТЧЕТЫ ---");
                Console.WriteLine("1. Рейтинг клиентов");
                Console.WriteLine("2. Выручка за период");
                Console.WriteLine("3. Отчет по сотрудникам");
                Console.WriteLine("4. Назад");
                Console.Write("Выберите отчет: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Начальная дата (гггг-мм-дд): ");
                        DateTime start = DateTime.Parse(Console.ReadLine());
                        Console.Write("Конечная дата (гггг-мм-дд): ");
                        DateTime end = DateTime.Parse(Console.ReadLine());

                        string clientReport = salon.GenerateClientRating(start, end);
                        Console.WriteLine($"{clientReport}");
                        salon.SaveReportToFile("client_rating.txt", clientReport);
                        break;
                    case "2":
                        Console.Write("Начальная дата (гггг-мм-дд): ");
                        start = DateTime.Parse(Console.ReadLine());
                        Console.Write("Конечная дата (гггг-мм-дд): ");
                        end = DateTime.Parse(Console.ReadLine());

                        string revenueReport = salon.GenerateRevenueReport(start, end);
                        Console.WriteLine($"{revenueReport}");
                        salon.SaveReportToFile("revenue_report.txt", revenueReport);
                        break;
                    case "3":
                        Console.Write("Начальная дата (гггг-мм-дд): ");
                        start = DateTime.Parse(Console.ReadLine());
                        Console.Write("Конечная дата (гггг-мм-дд): ");
                        end = DateTime.Parse(Console.ReadLine());

                        string employeeReport = salon.GenerateEmployeeReport(start, end);
                        Console.WriteLine($"{employeeReport}");
                        salon.SaveReportToFile("employee_report.txt", employeeReport);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }
    }
}
 
