using System;

namespace OOPEWC
{
    internal class Employee
    {
        private bool isPresent;
        private int wagePerHour;
        private int workingHours;

        public Employee()
        {
            Random random = new Random();
            isPresent = random.Next(0, 2) == 0 ? false : true;
            wagePerHour = 10; // Assuming the wage per hour is $10
            workingHours = isPresent ? random.Next(1, 9) : 0; // If present, generate a random working hour between 1 and 8, else 0
        }

        public bool IsPresent()
        {
            return isPresent;
        }

        public int CalculateDailyWage()
        {
            return wagePerHour * workingHours;
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
                Console.WriteLine($"Employee is Present. Daily Wage: {dailyWage}");
            }
            else
            {
                Console.WriteLine("Employee is Absent");
            }
        }
    }
}
