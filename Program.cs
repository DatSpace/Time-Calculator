using System;

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

            //START OF DATE CHECKING

            while (validDate == false)
            {
                if (dateTo.Length != 10 ||
                    (dateChar[2] != '/' || dateChar[5] != '/'))
                {
                    if (again == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nPlease use the correct date format");
                        Console.ResetColor();
                    }
                    
                    Console.WriteLine("\nPlease enter the date-to (dd/mm/yyyy)");
                    Console.WriteLine("Example: 05/10/2017");
                    Console.Write("\nPlease enter the date: ");
                    again = true;
                    dateTo = Console.ReadLine();
                    Console.WriteLine();
                    dateChar = dateTo.ToCharArray();
                }
                else if (Convert.ToInt32(dateTo.Substring(6, 4)) > 2099 || Convert.ToInt32(dateTo.Substring(6, 4)) < 2017)
                {
                    again = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please use a valid year (2017-2099)");
                    Console.ResetColor();
                    
                    Console.Write("\nPlease enter the date: ");
                    dateTo = Console.ReadLine();
                    Console.WriteLine();
                }
                else if (Convert.ToInt32(dateTo.Substring(3, 2)) > 12 || Convert.ToInt32(dateTo.Substring(3, 2)) < 1)
                {
                    again = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please use a valid month (01-12)");
                    Console.ResetColor();
                    
                    Console.Write("\nPlease enter the date: ");
                    dateTo = Console.ReadLine();
                    Console.WriteLine();
                }
                else
                {
                    validDate = true;
                    if (Convert.ToInt32(dateTo.Substring(3, 2)) != 2)
                    {
                        if (Convert.ToInt32(dateTo.Substring(3, 2)) <= 7)
                        {
                            if (Convert.ToInt32(dateTo.Substring(3, 2)) % 2 == 1)
                            {
                                if (Convert.ToInt32(dateTo.Substring(0, 2)) < 1 || Convert.ToInt32(dateTo.Substring(0, 2)) > 31)
                                {
                                    validDate = false;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Please enter a valid day number for this month (01-31)");
                                    Console.ResetColor();
                                    
                                    Console.Write("\nPlease enter the date: ");
                                    dateTo = Console.ReadLine();
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(dateTo.Substring(0, 2)) < 1 || Convert.ToInt32(dateTo.Substring(0, 2)) > 30)
                                {
                                    validDate = false;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Please enter a valid day number for this month (01-30)");
                                    Console.ResetColor();
                                    
                                    Console.Write("\nPlease enter the date: ");
                                    dateTo = Console.ReadLine();
                                    Console.WriteLine();
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(dateTo.Substring(3, 2)) % 2 == 0)
                            {
                                if (Convert.ToInt32(dateTo.Substring(0, 2)) < 1 || Convert.ToInt32(dateTo.Substring(0, 2)) > 31)
                                {
                                    validDate = false;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Please enter a valid day number for this month (0-31)");
                                    Console.ResetColor();
                                    
                                    Console.Write("\nPlease enter the date: ");
                                    dateTo = Console.ReadLine();
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(dateTo.Substring(0, 2)) < 1 || Convert.ToInt32(dateTo.Substring(0, 2)) > 30)
                                {
                                    validDate = false;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Please enter a valid day number for this month (0-30)");
                                    Console.ResetColor();
                                    
                                    Console.Write("\nPlease enter the date: ");
                                    dateTo = Console.ReadLine();
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(dateTo.Substring(6, 4)) % 4 == 0)
                        {
                            if (Convert.ToInt32(dateTo.Substring(0, 2)) < 1 || Convert.ToInt32(dateTo.Substring(0, 2)) > 29)
                            {
                                validDate = false;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("This is a leap year. Please use a valid number of days (01-29)");
                                Console.ResetColor();
                                
                                Console.Write("\nPlease enter the date: ");
                                dateTo = Console.ReadLine();
                                Console.WriteLine();
                            }
                        }
                        else if (Convert.ToInt32(dateTo.Substring(0, 2)) < 1 || Convert.ToInt32(dateTo.Substring(0, 2)) > 28)
                        {
                            validDate = false;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("This is not a leap year. Please use a valid number of days (01-28)");
                            Console.ResetColor();
                            
                            Console.Write("\nPlease enter the date: ");
                            dateTo = Console.ReadLine();
                            Console.WriteLine();
                        }
                    }

                }
                again = false;
            }

            //END OF DATE CHECKING


            //START OF OPTIONAL TIME QUESTION AND VALIDITY CHECKING

            Console.Clear();
            string useTime = "";
            again = false;

            while (useTime.ToUpper() != "Y" && useTime.ToUpper() != "N")
            {
                if (again == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nPlease type Y (Yes) or N (No)!");
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nYou chose date: {0}\n", dateTo);
                Console.ResetColor();
                
                Console.WriteLine("Would you like to specify the time of the date you chose, as well ?");
                Console.Write("Specify time (Y/N): ");
                useTime = Console.ReadLine();
                again = true;
            }

            again = false;

            if (useTime.ToUpper() == "Y")
            {
                while (validTime == false)
                {
                    if (timeTo.Length != 8 ||
                        (timeChar[2] != ':' || timeChar[5] != ':'))
                    {
                        if (again == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\nPlease use the correct time format");
                            Console.ResetColor();
                        }
                            
                        Console.WriteLine("\nPlease enter the time-to (hh:mm:ss)");
                        Console.WriteLine("Example: 17:23:46");
                        Console.Write("\nPlease enter the time: ");
                        again = true;
                        timeTo = Console.ReadLine();
                        Console.WriteLine();
                        timeChar = timeTo.ToCharArray();
                    }
                    else if (Convert.ToInt32(timeTo.Substring(0,2)) < 0 || Convert.ToInt32(timeTo.Substring(0,2)) > 23)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid hours number (00-23)");
                        Console.ResetColor();
                        
                        Console.Write("\nPlease enter the time: ");
                        again = true;
                        timeTo = Console.ReadLine();
                        Console.WriteLine();
                        timeChar = timeTo.ToCharArray();
                    }
                    else if (Convert.ToInt32(timeTo.Substring(3, 2)) < 0 || Convert.ToInt32(timeTo.Substring(3, 2)) > 59)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid minutes number (00-59)");
                        Console.ResetColor();
                        
                        Console.Write("\nPlease enter the time: ");
                        again = true;
                        timeTo = Console.ReadLine();
                        Console.WriteLine();
                        timeChar = timeTo.ToCharArray();
                    }
                    else if (Convert.ToInt32(timeTo.Substring(6, 2)) < 0 || Convert.ToInt32(timeTo.Substring(6, 2)) > 59)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid seconds number (00-59)");
                        Console.ResetColor();
                        
                        Console.Write("\nPlease enter the time: ");
                        again = true;
                        timeTo = Console.ReadLine();
                        Console.WriteLine();
                        timeChar = timeTo.ToCharArray();
                    }
                    else
                        validTime = true;
                }
            }

            //END OF OPTIONAL TIME QUESTION AND VALIDITY CHECKING


            int finalYears = 0;
            int finalMonths = 0;
            int finalDays = 0;
            int finalHours = 0;
            int finalMinutes = 0;
            int finalSeconds = 0;


            if (useTime.ToUpper() == "Y")
            {
                DateTime futureDate = new DateTime(Convert.ToInt32(dateTo.Substring(6, 4)), Convert.ToInt32(dateTo.Substring(3, 2)),
                    Convert.ToInt32(dateTo.Substring(0, 2)), Convert.ToInt32(timeTo.Substring(0, 2)),
                    Convert.ToInt32(timeTo.Substring(3, 2)), Convert.ToInt32(timeTo.Substring(6, 2)));
                finalYears = futureDate.Subtract(DateTime.Now).Days / 365;
                finalMonths = futureDate.Subtract(DateTime.Now).Days / 30;
                finalDays = futureDate.Subtract(DateTime.Now).Days;
                finalHours = futureDate.Subtract(DateTime.Now).Hours;
                finalMinutes = futureDate.Subtract(DateTime.Now).Minutes;
                finalSeconds = futureDate.Subtract(DateTime.Now).Seconds;
            }
            else
            {
                DateTime futureDate = new DateTime(Convert.ToInt32(dateTo.Substring(6, 4)), 
                    Convert.ToInt32(dateTo.Substring(3, 2)), Convert.ToInt32(dateTo.Substring(0, 2)));
                finalYears = futureDate.Subtract(DateTime.Now).Days / 365;
                finalMonths = futureDate.Subtract(DateTime.Now).Days / 30;
                finalDays = futureDate.Subtract(DateTime.Now).Days;
            }

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nThe calculations show that there are:\n");

            Console.ResetColor();

            if (finalYears > 0)
            {
                Console.WriteLine("{0}\tyears left.", finalYears);
                finalMonths -= 12 * finalYears;
            }
            if (finalMonths > 0)
            {
                Console.WriteLine("{0}\tmonths left.", finalMonths);
                finalDays -= (30 * finalMonths) + (30 * 12 * finalYears);
            }
            if (finalDays > 0)
                Console.WriteLine("{0}\tdays left.", finalDays);
            if (finalHours > 0)
                Console.WriteLine("{0}\thours left.", finalHours);
            if (finalMinutes > 0)
                Console.WriteLine("{0}\tminutes left.", finalMinutes);
            if (finalSeconds > 0)
                Console.WriteLine("{0}\tseconds left.", finalSeconds);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\n\t\t\t\tThank you for using TimeTo! (Press enter to exit)");
            Console.ReadLine();
        }
    }
}


/* 1)Restrict year: 2017-2099. +
 * 2)Restrict months: 1-12. +
 * 3)Restrict days per month (even for leap years). +
 * 4)Restrict hours: 0-23 +
 * 5)Restrict minutes: 0-59 +
 * 6)Restrict seconds: 0-59 +
 * 7)Make option to use time or not. +
 * 8)
 */
