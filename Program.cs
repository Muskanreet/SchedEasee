using System;
using System.Collections.Generic;

namespace SchedEase
{
    public class Appointment
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }

        public Appointment(string title, DateTime startTime, DateTime endTime, string description)
        {// Constructor for the Appointment class.
// Initializes a new instance of the Appointment class with the specified title, start time, end time, and description.
// Parameters:
// - title: A string representing the title of the appointment.
// - startTime: A DateTime object indicating when the appointment starts.
// - endTime: A DateTime object indicating when the appointment ends.
// - description: A string providing additional details about the appointment.
public Appointment(string title, DateTime startTime, DateTime endTime, string description)

            Title = title;
            StartTime = startTime;
            EndTime = endTime;
            Description = description;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Start Time: {StartTime}");
            Console.WriteLine($"End Time: {EndTime}");
            Console.WriteLine($"Description: {Description}");
        }
    }

    public class AppointmentScheduler
    {
        private List<Appointment> appointments = new List<Appointment>();

        public void AddAppointment(Appointment appointment)
        {
            appointments.Add(appointment);
            Console.WriteLine("Appointment added successfully.");
        }

        public void DisplayAllAppointments()
        {
            Console.WriteLine("\nScheduled Appointments:");
            foreach (var appointment in appointments)
            {
                appointment.DisplayDetails();
                Console.WriteLine("---------------");
            }
        }

        public void RemoveAppointment(string title)
        {
            appointments.RemoveAll(a => a.Title == title);
            Console.WriteLine("Appointment removed successfully.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AppointmentScheduler scheduler = new AppointmentScheduler();

            while (true)
            {
                Console.WriteLine("\n1. Add Appointment");
                Console.WriteLine("2. Display All Appointments");
                Console.WriteLine("3. Remove Appointment");
                Console.WriteLine("4. Exit");

                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter appointment title: ");
                        string title = Console.ReadLine();

                        Console.Write("Enter start time (yyyy-mm-dd hh:mm): ");
                        DateTime startTime = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter end time (yyyy-mm-dd hh:mm): ");
                        DateTime endTime = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter description: ");
                        string description = Console.ReadLine();

                        Appointment appointment = new Appointment(title, startTime, endTime, description);
                        scheduler.AddAppointment(appointment);
                        break;

                    case "2":
                        scheduler.DisplayAllAppointments();
                        break;

                    case "3":
                        Console.Write("Enter title of the appointment to remove: ");
                        string removeTitle = Console.ReadLine();
                        scheduler.RemoveAppointment(removeTitle);
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
