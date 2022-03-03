using System;
using static System.Console;

namespace TicketingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            char moreEntries = 'Y';

            double totalFines = 0;
            int numFines = 0;

            while (Char.ToUpper(moreEntries) == 'Y')
            {
                GetTicketDetails(out string studentId, out char studentCat, out int speedReported, out int speedLimit);
                Ticket ticket = new Ticket(studentId, studentCat, speedLimit, speedReported);
                WriteLine(ticket);

                Write("Would you like to enter more tickets?\n" +
                    "Y - Yes\n" +
                    "N - No\n" +
                    "Select Option: ");

                while (!char.TryParse(ReadLine(), out moreEntries) || (!(Char.ToUpper(moreEntries) == 'Y')
                        && !(Char.ToUpper(moreEntries) == 'N')))
                {
                    Write("Invalid option, please enter Y (Yes) or N (No): ");
                }

                numFines++;
                totalFines += ticket.Fine;
            }

            WriteLine($"\n\nFines average: {(totalFines / numFines):C}");

        }

        static void GetTicketDetails(out string studentId, out char studentCat, out int speedReported, out int speedLimit)
        {
            Write("Please enter Student ID: ");
            studentId = ReadLine();

            while (studentId == "")
            {
                WriteLine("Student ID cannot be blank!");
                Write("\nPlease re-enter Student ID: ");
                studentId = ReadLine();
            }

            Write("Please enter Student Category number\n" +
                "1 - Freshman\n" +
                "2 - Sophomore\n" +
                "3 - Junior\n" +
                "4 - Senior\n" +
                "Select option: ");
            char[] studentCatOpts = { '1', '2', '3', '4' };

            while (!char.TryParse(ReadLine(), out studentCat) || !(Array.IndexOf(studentCatOpts, studentCat) > -1))
            {
                WriteLine($"Student Category must be one of the following: {string.Join(", ", studentCatOpts)}");
                Write("\nPlease re-enter Student Category: ");
            }

            Write("Please enter speed limit: ");

            while (!int.TryParse(ReadLine(), out speedLimit) || !(speedLimit > 0))
            {
                WriteLine($"Speed limit must be a integer > 0!");
                Write("\nPlease re-enter speed limit: ");
            }

            Write("Please enter reported speed: ");

            while (!int.TryParse(ReadLine(), out speedReported) || !(speedReported > speedLimit))
            {
                WriteLine($"Reported speed must be a valid integer greater than speedLimit ({speedLimit} mph)!");
                Write("\nPlease re-enter reported speed: ");
            }
        }
    }
}
