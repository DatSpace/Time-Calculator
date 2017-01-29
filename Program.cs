using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeToCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to TimeTo!\n");

            string dateTo = "";
            string timeTo = "";
            bool again = false;
            bool validDate = false;
            bool validTime = false;
            char[] dateChar = dateTo.ToCharArray();
            char[] timeChar = timeTo.ToCharArray();

            while (validDate == false)
            {
                if (dateTo.Length != 10 ||
                    (dateChar[2] != '/' || dateChar[5] != '/'))
                {
                    if (again == true)
                        Console.WriteLine("\n\nPlease use the correct date format...");
                    Console.WriteLine("Please enter the date-to (dd/mm/yyyy)...");
                    Console.WriteLine("Example: 05/10/2017...");
                    Console.Write("\nPlease enter the date: ");
                    again = true;
                    dateTo = Console.ReadLine();
                    Console.WriteLine();
                    dateChar = dateTo.ToCharArray();
                }
                else
                    validDate = true;
            }

            again = false;

            while (validTime == false)
            {
                if (timeTo.Length != 8 ||
                    (timeChar[2] != ':' || timeChar[5] != ':'))
                {
                    if (again == true)
                        Console.WriteLine("\n\nPlease use the correct time format...");
                    Console.WriteLine("Please enter the time-to (hh:mm:ss)");
                    Console.WriteLine("Example: 17:23:46 !");
                    Console.Write("\nPlease enter the time: ");
                    again = true;
                    timeTo = Console.ReadLine();
                    Console.WriteLine();
                    timeChar = timeTo.ToCharArray();
                }
                else
                    validTime = true;
            }

            DateTime futureDate = new DateTime(Convert.ToInt32(dateTo.Substring(6, 4)), Convert.ToInt32(dateTo.Substring(3, 2)),
                Convert.ToInt32(dateTo.Substring(0, 2)), Convert.ToInt32(timeTo.Substring(0, 2)),
                Convert.ToInt32(timeTo.Substring(3, 2)), Convert.ToInt32(timeTo.Substring(6, 2)));

            int finalYears = futureDate.Subtract(DateTime.Now).Days / 365;
            int finalMonths = futureDate.Subtract(DateTime.Now).Days / 30;
            int finalDays = futureDate.Subtract(DateTime.Now).Days;
            int finalHours = futureDate.Subtract(DateTime.Now).Hours;
            int finalMinutes = futureDate.Subtract(DateTime.Now).Minutes;
            int finalSeconds = futureDate.Subtract(DateTime.Now).Seconds;

            if (finalYears > 0)
            {
                Console.Write("Years left: -{0}- / ", finalYears);
                finalMonths -= 12 * finalYears;
            }
            if (finalMonths > 0)
            {
                Console.Write("Months left: -{0}- / ", finalMonths);
                finalDays -= (30 * finalMonths) + (30 * 12 * finalYears);
            }
            if (finalDays > 0)
                Console.Write("Days left: -{0}- / ", finalDays);
            if (finalHours > 0)
                Console.Write("Hours left: -{0}- / ", finalHours);
            if (finalMinutes > 0)
                Console.Write("Minutes left: -{0}- / ", finalMinutes);
            if (finalSeconds > 0)
                Console.Write("Seconds left: -{0}-", finalSeconds);

            Console.ReadLine();
        }
    }
}
