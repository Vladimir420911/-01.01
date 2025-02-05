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
            Salon salon = new Salon();
            string servicesFileName = "services.txt";
            salon.LoadServicesFromFile(servicesFileName);



            while (true)
            {
                Console.WriteLine("\n--- Меню Салона Красоты ---");
                Console.WriteLine("1. Добавить услугу");
                Console.WriteLine("2. Записать клиента на услугу");
                Console.WriteLine("3. Сохранить список услуг");
                Console.WriteLine("4. Вывести рейтинг клиентов");
                Console.WriteLine("5. Вывести отчет о выручке за период");
                Console.WriteLine("6. Вывести отчет о сотрудниках");
                Console.WriteLine("7. Выход");

                Console.Write("Выберите пункт меню: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите название услуги: ");
                        string serviceName = Console.ReadLine();

                        Console.Write("Введите стоимость услуги: ");
                        if (!decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal servicePrice))
                        {
                            Console.WriteLine("Некорректный формат цены.");
                            break;
                        }

                        Console.Write("Введите список мастеров через запятую: ");
                        string masters = Console.ReadLine();

                        salon.AddService(new Service(serviceName, servicePrice, masters.Split(',').ToList()));
                        Console.WriteLine("Услуга добавлена.");
                        break;

                    case "2":
                        Console.Write("Введите имя клиента: ");
                        string clientName = Console.ReadLine();
                        var client = salon.GetOrCreateClient(clientName);


                        Console.WriteLine("Список доступных услуг:");
                        var allServices = salon.GetAllServices();
                        for (int i = 0; i < allServices.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {allServices[i].Name} ({allServices[i].Price:C})");
                        }
                        Console.Write("Выберите номер услуги: ");
                        if (!int.TryParse(Console.ReadLine(), out int selectedServiceIndex) ||
                           selectedServiceIndex < 1 || selectedServiceIndex > allServices.Count)
                        {
                            Console.WriteLine("Некорректный выбор услуги.");
                            break;
                        }
                        var selectedService = allServices[selectedServiceIndex - 1];

                        Console.Write("Выберите мастера из списка ({0}): ", string.Join(", ", selectedService.Masters));
                        string selectedMaster = Console.ReadLine();

                        if (!selectedService.Masters.Contains(selectedMaster))
                        {
                            Console.WriteLine("Некорректный выбор мастера");
                            break;
                        }

                        Console.Write("Введите дату визита (гггг-мм-дд): ");
                        if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime appointmentDate))
                        {
                            Console.WriteLine("Некорректный формат даты");
                            break;
                        }


                        salon.AddAppointment(new Appointment(client, selectedService, selectedMaster, appointmentDate));
                        Console.WriteLine("Запись добавлена.");
                        break;
                    case "3":
                        salon.SaveServicesToFile(servicesFileName);
                        Console.WriteLine("Список услуг сохранен");
                        break;
                    case "4":
                        {
                            string clientReport = salon.GenerateClientRating();
                            salon.SaveReportToFile(clientReport, "client_rating.txt");
                            Console.WriteLine("Рейтинг клиентов сохранен в файл client_rating.txt");
                            Console.WriteLine(clientReport);
                        }
                        break;
                    case "5":
                        {
                            Console.Write("Введите начальную дату периода (гггг-мм-дд): ");
                            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate))
                            {
                                Console.WriteLine("Некорректный формат даты");
                                break;
                            }

                            Console.Write("Введите конечную дату периода (гггг-мм-дд): ");
                            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate))
                            {
                                Console.WriteLine("Некорректный формат даты");
                                break;
                            }
                            string revenueReport = salon.GenerateRevenueReport(startDate, endDate);
                            salon.SaveReportToFile(revenueReport, "revenue_report.txt");
                            Console.WriteLine("Отчет о выручке сохранен в файл revenue_report.txt");
                            Console.WriteLine(revenueReport);
                        }
                        break;
                    case "6":
                        {
                            Console.Write("Введите начальную дату периода (гггг-мм-дд): ");
                            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate))
                            {
                                Console.WriteLine("Некорректный формат даты");
                                break;
                            }

                            Console.Write("Введите конечную дату периода (гггг-мм-дд): ");
                            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate))
                            {
                                Console.WriteLine("Некорректный формат даты");
                                break;
                            }
                            string employeeReport = salon.GenerateEmployeeReport(startDate, endDate);
                            salon.SaveReportToFile(employeeReport, "employee_report.txt");
                            Console.WriteLine("Отчет по сотрудникам сохранен в файл employee_report.txt");
                            Console.WriteLine(employeeReport);
                        }
                        break;
                    case "7":
                        Console.WriteLine("Завершение работы программы.");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте еще раз.");
                        break;
                }
            }
        }
    }
}
 
