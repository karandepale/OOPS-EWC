using System;

namespace OOPEWC
{
    internal class Employee
    {
        private bool isPresent;
        private bool isPartTime;
        private int wagePerHour;
        private int workingHours;

        public Employee(bool isPresent, bool isPartTime, int wagePerHour, int workingHours)
        {
            this.isPresent = isPresent;
            this.isPartTime = isPartTime;
            this.wagePerHour = wagePerHour;
            this.workingHours = workingHours;
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

        public static int CalculateMonthlyWage(int totalWorkingHours, int totalWorkingDays, int wagePerHour, int workingHours)
        {
            int monthlyWage = 0;
            int workingHoursCounter = 0;
            int workingDaysCounter = 0;

            while (workingHoursCounter < totalWorkingHours && workingDaysCounter < totalWorkingDays)
            {
                Employee employee = new Employee(true, false, wagePerHour, workingHours);
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

    internal class Company
    {
        private string name;
        private int wagePerHour;
        private int workingHoursPerMonth;
        private int workingDaysPerMonth;

        public Company(string name, int wagePerHour, int workingHoursPerMonth, int workingDaysPerMonth)
        {
            this.name = name;
            this.wagePerHour = wagePerHour;
            this.workingHoursPerMonth = workingHoursPerMonth;
            this.workingDaysPerMonth = workingDaysPerMonth;
        }

        public string GetName()
        {
            return name;
        }

        public int GetWagePerHour()
        {
            return wagePerHour;
        }

        public int GetWorkingHoursPerMonth()
        {
            return workingHoursPerMonth;
        }

        public int GetWorkingDaysPerMonth()
        {
            return workingDaysPerMonth;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create instances of companies
            Company company1 = new Company("Company 1", 10, 160, 20); // Assuming 160 working hours per month (8 hours per day, 20 days per month)
            Company company2 = new Company("Company 2", 12, 180, 22); // Assuming 180 working hours per month (9 hours per day, 20 days per month)

            Employee employee = new Employee(true, false, company1.GetWagePerHour(), company1.GetWorkingHoursPerMonth());

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

                int totalWorkingHours = company1.GetWorkingHoursPerMonth();
                int totalWorkingDays = company1.GetWorkingDaysPerMonth();
                int monthlyWage = Employee.CalculateMonthlyWage(totalWorkingHours, totalWorkingDays, company1.GetWagePerHour(), company1.GetWorkingHoursPerMonth());
                Console.WriteLine($"Monthly Wage for {company1.GetName()}: {monthlyWage}");

                totalWorkingHours = company2.GetWorkingHoursPerMonth();
                totalWorkingDays = company2.GetWorkingDaysPerMonth();
                monthlyWage = Employee.CalculateMonthlyWage(totalWorkingHours, totalWorkingDays, company2.GetWagePerHour(), company2.GetWorkingHoursPerMonth());
                Console.WriteLine($"Monthly Wage for {company2.GetName()}: {monthlyWage}");
            }
            else
            {
                Console.WriteLine("Employee is Absent");
            }
        }
    }
}
