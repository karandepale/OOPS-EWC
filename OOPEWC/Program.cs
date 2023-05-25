using System;

namespace OOPEWC
{
    internal class Employee
    {
        private bool isPresent;
        private bool isPartTime;
        private int wagePerHour;
        private int workingHours;

        public Employee()
        {
            Random random = new Random();
            isPresent = random.Next(0, 2) == 0 ? false : true;
            isPartTime = random.Next(0, 2) == 0 ? false : true;
            wagePerHour = 10; // Assuming the wage per hour is $10
            workingHours = CalculateWorkingHours(isPartTime, random);
        }

        public bool IsPresent()
        {
            return isPresent;
        }

        public bool IsPartTime()
        {
            return isPartTime;
        }

        public int CalculateDailyWage()
        {
            return wagePerHour * workingHours;
        }

        private int CalculateWorkingHours(bool isPartTime, Random random)
        {
            switch (isPartTime)
            {
                case true:
                    return 8; // Assuming part-time hours are 8
                case false when isPresent:
                    return random.Next(1, 9); // If full-time, generate a random working hour between 1 and 8
                default:
                    return 0; // Absent, no working hours
            }
        }

        public static int CalculateMonthlyWage(int totalWorkingHours, int totalWorkingDays)
        {
            int monthlyWage = 0;
            int workingHoursCounter = 0;
            int workingDaysCounter = 0;

            while (workingHoursCounter < totalWorkingHours && workingDaysCounter < totalWorkingDays)
            {
                Employee employee = new Employee();
                if (employee.IsPresent())
                {
                    workingDaysCounter++;
                    int dailyWage = employee.CalculateDailyWage();
                    monthlyWage += dailyWage;
                    workingHoursCounter += employee.workingHours;
                }
            }

            return monthlyWage;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();

            if (employee.IsPresent())
            {
                int dailyWage = employee.CalculateDailyWage();
                Console.WriteLine("Employee is Present.");

                switch (employee.IsPartTime())
                {
                    case true:
                        Console.WriteLine($"Part-Time Employee. Daily Wage: {dailyWage}");
                        break;
                    case false:
                        Console.WriteLine($"Full-Time Employee. Daily Wage: {dailyWage}");
                        break;
                }

                int totalWorkingHours = 100; // Set the total working hours for the month
                int totalWorkingDays = 20; // Set the total working days for the month
                int monthlyWage = Employee.CalculateMonthlyWage(totalWorkingHours, totalWorkingDays);
                Console.WriteLine($"Monthly Wage: {monthlyWage}");
            }
            else
            {
                Console.WriteLine("Employee is Absent");
            }
        }
    }
}
