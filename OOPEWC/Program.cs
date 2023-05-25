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
            }
            else
            {
                Console.WriteLine("Employee is Absent");
            }
        }
    }
}
