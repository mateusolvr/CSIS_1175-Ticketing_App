using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp
{
    class Ticket
    {
        const double FEE_OVER_LIMIT = 87.5;
        const int SPEED_OVER_LIMIT = 5;

        public string StudentId { get; set; }
        public char StudentCategory { get; set; }
        public int SpeedLimit { get; set; }
        public int SpeedReported { get; set; }
        public string CategoryName { get
            {
                switch (StudentCategory)
                {
                    case '1':
                        return "Freshman";
                    case '2':
                        return "Sophomore";
                    case '3':
                        return "Junior";
                    case '4':
                        return "Senior";
                    default:
                        return "Error";
                }
            } }
        public double Fine { get
            {
                double initialValue = 75;
                double speedFee = SpeedFee(out int speedAboveLimit);
                int feeModifier = FeeModifier(speedAboveLimit);

                return initialValue + speedFee + feeModifier;
            } }

        private double SpeedFee(out int speedAboveLimit)
        {
            speedAboveLimit = SpeedReported - SpeedLimit;
            double speedFeed = Math.Floor((double)speedAboveLimit / SPEED_OVER_LIMIT) * FEE_OVER_LIMIT;
            return speedFeed;
        }

        private int FeeModifier(int speedAboveLimit)
        {
            switch (CategoryName)
            {
                case "Senior":
                    if (speedAboveLimit >= 20) { return 200; }
                    return 50;
                case "Freshman":
                    if (speedAboveLimit < 20) { return -50; }
                    return 100;
                default:
                    if (speedAboveLimit >= 20) { return 100; }
                    return 0;
            }
        }

        public Ticket() { }
        public Ticket(string studentId, char studentCategory, int speedLimit, int speedReported)
        {
            StudentId = studentId;
            StudentCategory = studentCategory;
            SpeedLimit = speedLimit;
            SpeedReported = speedReported;
        }

        public override string ToString()
        {
            // Formatted string to be used when viewing the cart
            string ticketDetails = string.Format($"Student Id: {StudentId}\n" +
                                                    $"Student Category: {StudentCategory}\n" +
                                                    $"Speed Limit: {SpeedLimit}\n" +
                                                    $"Speed Reported: {SpeedReported}\n" +
                                                    $"Category Name: {CategoryName}\n" +
                                                    $"Fine: {Fine}\n");
            return ticketDetails;
        }
    }
}
