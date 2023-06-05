using System;
using System.Collections.Generic;

namespace EmployeeWageCalculator
{
    internal interface IComputeWage
    {
        void AddCompany(string name, int wagePerHour, int workingHoursPerMonth, int workingDaysPerMonth);
        void CalculateWages();
    }

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

    internal class CompanyEmpWage
    {
        private string name;
        private int wagePerHour;
        private int workingHoursPerMonth;
        private int workingDaysPerMonth;

        public CompanyEmpWage(string name, int wagePerHour, int workingHoursPerMonth, int workingDaysPerMonth)
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

    internal class EmpWageBuilder : IComputeWage
    {
        private List<CompanyEmpWage> companies;

        public EmpWageBuilder()
        {
            companies = new List<CompanyEmpWage>();
        }

        public void AddCompany(string name, int wagePerHour, int workingHoursPerMonth, int workingDaysPerMonth)
        {
            companies.Add(new CompanyEmpWage(name, wagePerHour, workingHoursPerMonth, workingDaysPerMonth));
        }

        public void CalculateWages()
        {
            foreach (var company in companies)
            {
                Employee employee = new Employee(true, false, company.GetWagePerHour(), company.GetWorkingHoursPerMonth());

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

                    employee.CalculateMonthlyWage(company.GetWorkingHoursPerMonth(), company.GetWorkingDaysPerMonth());
                    int monthlyWage = employee.GetTotalWage();
                    Console.WriteLine($"Monthly Wage for {company.GetName()}: {monthlyWage}");
                }
                else
                {
                    Console.WriteLine("Employee is Absent");
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IComputeWage empWageBuilder = new EmpWageBuilder();

            // Add companies
            empWageBuilder.AddCompany("Company 1", 10, 160, 20); // Assuming 160 working hours per month (8 hours per day, 20 days per month)
            empWageBuilder.AddCompany("Company 2", 12, 180, 22); // Assuming 180 working hours per month (9 hours per day, 20 days per month)

            // Calculate wages for all companies
            empWageBuilder.CalculateWages();
        }
    }
}
