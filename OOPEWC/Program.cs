using System;

namespace EmployeeWageCalculator
{
    internal class Employee
    {
        private bool isPresent;
        private bool isPartTime;
        private int wagePerHour;
        private int workingHours;
        private int totalWage;

        public Employee(bool isPresent, bool isPartTime, int wagePerHour, int workingHours)
        {
            this.isPresent = isPresent;
            this.isPartTime = isPartTime;
            this.wagePerHour = wagePerHour;
            this.workingHours = workingHours;
            this.totalWage = 0;
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

        public void CalculateMonthlyWage(int totalWorkingHours, int totalWorkingDays)
        {
            int workingHoursCounter = 0;
            int workingDaysCounter = 0;

            while (workingHoursCounter < totalWorkingHours && workingDaysCounter < totalWorkingDays)
            {
                if (IsPresent())
                {
                    workingDaysCounter++;
                    int dailyWage = CalculateDailyWage();
                    totalWage += dailyWage;
                    workingHoursCounter += workingHours;
                }
            }
        }

        public int GetTotalWage()
        {
            return totalWage;
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
            Company company1 = new Company("Company 1", 10, 160, 20);
            Company company2 = new Company("Company 2", 12, 180, 22);

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

                employee.CalculateMonthlyWage(company1.GetWorkingHoursPerMonth(), company1.GetWorkingDaysPerMonth());
                int monthlyWage = employee.GetTotalWage();
                Console.WriteLine($"Monthly Wage for {company1.GetName()}: {monthlyWage}");

                employee.CalculateMonthlyWage(company2.GetWorkingHoursPerMonth(), company2.GetWorkingDaysPerMonth());
                monthlyWage = employee.GetTotalWage();
                Console.WriteLine($"Monthly Wage for {company2.GetName()}: {monthlyWage}");
            }
            else
            {
                Console.WriteLine("Employee is Absent");
            }
        }
    }
}
