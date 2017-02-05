using System;

namespace TimeCalculator
{
    class Program
    {
        static bool isNumeric(string text)
        {
            int temp;
            return !int.TryParse(text, out temp);
        }

        static string userInput(bool isDate)
        {
            if (isDate == true)
                Console.Write("\nPlease enter the date: ");
            else
                Console.Write("\nPlease enter the time: ");
            string dateTo = Console.ReadLine();
            Console.WriteLine();
            return dateTo;
        }

        static void printError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to TimeTo!\n");
            bool end = false;

            while (end == false)
            {

                string dateTo = "";
                string timeTo = "";
                bool again = false;
                bool validDate = false;
                bool validTime = false;
                int day = 0;
                int month = 0;
                int year = 0;

                //START OF DATE CHECKING

                while (validDate == false)
                {
                    if (dateTo.Length != 10 || (isNumeric(dateTo.Substring(0, 2)) || isNumeric(dateTo.Substring(3, 2)) ||
                        isNumeric(dateTo.Substring(6, 4)) || dateTo.Substring(2, 1) != "/" || dateTo.Substring(5, 1) != "/"))
                    {
                        if (again == true)
                            printError("\n\nPlease use the correct date format!");

                        Console.WriteLine("\nPlease enter the date-to (dd/mm/yyyy)");
                        Console.WriteLine("Example: 05/10/2017");

                        dateTo = userInput(true);
                        again = true;
                    }
                    else
                    {
                        day = Convert.ToInt32(dateTo.Substring(0, 2));
                        month = Convert.ToInt32(dateTo.Substring(3, 2));
                        year = Convert.ToInt32(dateTo.Substring(6, 4));
                        again = true;

                        if (year > 2099 || year < 2017)
                        {
                            printError("Please use a valid year (2017-2099)!");
                            dateTo = userInput(true);
                        }
                        else if (month > 12 || month < 1)
                        {
                            printError("Please use a valid month (01-12)!");
                            dateTo = userInput(true);
                        }
                        else
                        {
                            validDate = true;
                            if (month != 2)
                            {
                                if (month < 8)
                                {
                                    if (month % 2 == 1)
                                    {
                                        if (day < 1 || day > 31)
                                        {
                                            validDate = false;
                                            printError("Please enter a valid day number for this month (01-31)!");
                                            dateTo = userInput(true);
                                        }
                                    }
                                    else
                                    {
                                        if (day < 1 || day > 30)
                                        {
                                            validDate = false;
                                            printError("Please enter a valid day number for this month (01-30)!");
                                            dateTo = userInput(true);
                                        }
                                    }
                                }
                                else
                                {
                                    if (Convert.ToInt32(dateTo.Substring(3, 2)) % 2 == 0)
                                    {
                                        if (day < 1 || day > 31)
                                        {
                                            validDate = false;
                                            printError("Please enter a valid day number for this month (0-31)!");
                                            dateTo = userInput(true);
                                        }
                                    }
                                    else
                                    {
                                        if (day < 1 || day > 30)
                                        {
                                            validDate = false;
                                            printError("Please enter a valid day number for this month (0-30)!");
                                            dateTo = userInput(true);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (year % 4 == 0)
                                {
                                    if (day < 1 || day > 29)
                                    {
                                        validDate = false;
                                        printError("This is a leap year. Please use a valid number of days (01-29)!");
                                        dateTo = userInput(true);
                                    }
                                }
                                else if (day < 1 || day > 28)
                                {
                                    validDate = false;
                                    printError("This is not a leap year. Please use a valid number of days (01-28)!");
                                    dateTo = userInput(true);
                                }
                            }
                        }
                    }
                }

                //END OF DATE CHECKING


                //START OF OPTIONAL TIME QUESTION AND VALIDITY CHECKING

                Console.Clear();
                string useTime = "";
                again = false;

                while (useTime.ToUpper() != "Y" && useTime.ToUpper() != "N")
                {
                    if (again == true)
                        printError("\n\nPlease type Y (Yes) or N (No)!");
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\nYou chose date: {0}\n", dateTo);
                        Console.ResetColor();
                    }

                    Console.WriteLine("Would you like to specify the time of the date you chose, as well ?");
                    Console.Write("Specify time (Y/N): ");
                    useTime = Console.ReadLine();
                    again = true;
                }

                again = false;
                int hour = 0;
                int minute = 0;
                int second = 0;

                if (useTime.ToUpper() == "Y")
                {
                    while (validTime == false)
                    {
                        if (timeTo.Length != 8 || (isNumeric(timeTo.Substring(0, 2)) || isNumeric(timeTo.Substring(3, 2)) ||
                            isNumeric(timeTo.Substring(6, 2)) || timeTo.Substring(2, 1) != ":" || timeTo.Substring(5, 1) != ":"))
                        {
                            if (again == true)
                                printError("\n\nPlease use the correct time format!");

                            Console.WriteLine("\nPlease enter the time-to (hh:mm:ss)");
                            Console.WriteLine("Example: 17:23:46");

                            timeTo = userInput(false);
                            again = true;
                        }
                        else
                        {
                            hour = Convert.ToInt32(timeTo.Substring(0, 2));
                            minute = Convert.ToInt32(timeTo.Substring(3, 2));
                            second = Convert.ToInt32(timeTo.Substring(6, 2));
                            again = true;

                            if (hour < 0 || hour > 23)
                            {
                                printError("Please enter a valid hours number (00-23)!");
                                timeTo = userInput(false);
                            }
                            else if (minute < 0 || minute > 59)
                            {
                                printError("Please enter a valid minutes number (00-59)!");
                                timeTo = userInput(false);
                            }
                            else if (second < 0 || second > 59)
                            {
                                printError("Please enter a valid seconds number (00-59)!");

                                timeTo = userInput(false);
                            }
                            else
                                validTime = true;
                        }
                    }
                }

                //END OF OPTIONAL TIME QUESTION AND VALIDITY CHECKING


                int finalYears = 0;
                int finalMonths = 0;
                int finalDays = 0;
                int finalHours = 0;
                int finalMinutes = 0;
                int finalSeconds = 0;
                int temp = 0;
                DateTime futureDate;

                if (useTime.ToUpper() == "Y")
                    futureDate = new DateTime(year, month, day, hour, minute, second);
                else
                    futureDate = new DateTime(year, month, day, 0, 0, 0);

                ConsoleKey key = ConsoleKey.A;

                while (!(key == ConsoleKey.Escape || key == ConsoleKey.Enter))
                {
                    if (Console.KeyAvailable)
                    {
                        key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.Escape)
                            end = true;
                            
                    }
                        
                    if (futureDate > DateTime.Now)
                    {
                        finalYears = Convert.ToInt32(Math.Floor(futureDate.Subtract(DateTime.Now).Days / 365.25));
                        finalMonths = Convert.ToInt32(Math.Floor(futureDate.Subtract(DateTime.Now).Days / 30.4167));
                        finalDays = futureDate.Subtract(DateTime.Now).Days;
                        finalHours = futureDate.Subtract(DateTime.Now).Hours;
                        finalMinutes = futureDate.Subtract(DateTime.Now).Minutes;
                        finalSeconds = futureDate.Subtract(DateTime.Now).Seconds;
                    }
                    else
                    {
                        finalYears = Convert.ToInt32(Math.Ceiling(futureDate.Subtract(DateTime.Now).Days / 365.25));
                        finalMonths = Convert.ToInt32(Math.Ceiling(futureDate.Subtract(DateTime.Now).Days / 30.4167));
                        finalDays = futureDate.Subtract(DateTime.Now).Days;
                        finalHours = futureDate.Subtract(DateTime.Now).Hours;
                        finalMinutes = futureDate.Subtract(DateTime.Now).Minutes;
                        finalSeconds = futureDate.Subtract(DateTime.Now).Seconds;
                    }

                    if (temp != finalSeconds)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        if (futureDate > DateTime.Now)
                            Console.WriteLine("\nThe calculations show that there are:\n");
                        else
                            Console.WriteLine("\nThe calculations show that this date was:\n");
                        Console.ResetColor();

                        if (finalYears > 0)
                            Console.WriteLine("\t{0}\tyears left.", finalYears);
                        else if (finalYears < 0)
                            Console.WriteLine("\t{0}\tyears ago.", Math.Abs(finalYears));
                        finalMonths -= 12 * finalYears;

                        if (finalMonths > 0)
                            Console.WriteLine("\t{0}\tmonths left.", finalMonths);
                        else if (finalMonths < 0)
                            Console.WriteLine("\t{0}\tmonths ago.", Math.Abs(finalMonths));
                        finalDays -= Convert.ToInt32(Math.Floor((30.4167 * finalMonths) + (30.4167 * 12 * finalYears)));

                        if (finalDays > 0)
                            Console.WriteLine("\t{0}\tdays left.", finalDays);
                        else if (finalDays < 0)
                            Console.WriteLine("\t{0}\tdays ago.", Math.Abs(finalDays));

                        if (finalHours > 0)
                            Console.WriteLine("\t{0}\thours left.", finalHours);
                        else if (finalHours < 0)
                            Console.WriteLine("\t{0}\thours ago.", Math.Abs(finalHours));

                        if (finalMinutes > 0)
                            Console.WriteLine("\t{0}\tminutes left.", finalMinutes);
                        else if (finalMinutes < 0)
                            Console.WriteLine("\t{0}\tminutes ago.", Math.Abs(finalMinutes));

                        if (finalSeconds > 0)
                            Console.WriteLine("\t{0}\tseconds left.", finalSeconds);
                        else if (finalSeconds < 0)
                            Console.WriteLine("\t{0}\tseconds ago.", Math.Abs(finalSeconds));

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\n\n\t\t\tThank you for using TimeTo! (Press Esc to exit or Enter to start again!)");
                        Console.ResetColor();
                        temp = finalSeconds;
                    }
                }
                Console.Clear();
            }
        }
    }
}


/* 1)Restrict year: 2017-2099. =
 * 2)Restrict months: 1-12. =
 * 3)Restrict days per month (even for leap years). =
 * 4)Restrict hours: 0-23 =
 * 5)Restrict minutes: 0-59 =
 * 6)Restrict seconds: 0-59 =
 * 7)Make option to use time or not. =
 * 8)Simplyfied converting. Now it happens once not in every check. =
 * 9)Made two new functions to print an error msg and another for the repeating user input. =
 * 10)Fixed a bug where if time left was less than a day (hours,minutes,seconds) and timeTo wasnt specified it wouldn't print anything. =
 * 11)Fixed a bug where time didnt work (simple stupidity):/ . =
 * 12)Added checking if the entered values are numbers and not characters or symbols. =
 * 13)Removed the two character arrays using other method to make sure of the symbols in strigns. =
 * 14)Made the calculations a lot more accurate, even for long dates. =
 * 15)Now the programm will conineu to update the left over time until the user presses Esc every second. =
 * 16)Added the option to start all over again. +
 * 17)Added reverse calculation. You can enter a past date and it will calculate the time passed. +
 * 
 * NOTE: I know the code can be possibly improved a lot. This is just a simple console application for practice perposes.
 */
