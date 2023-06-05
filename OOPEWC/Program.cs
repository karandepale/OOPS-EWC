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

    internal class EmpWageBuilder
    {
        private CompanyEmpWage[] companies;

        public EmpWageBuilder()
        {
            companies = new CompanyEmpWage[2]; // Assuming 2 companies for demonstration
        }

        public void AddCompany(string name, int wagePerHour, int workingHoursPerMonth, int workingDaysPerMonth)
        {
            for (int i = 0; i < companies.Length; i++)
            {
                if (companies[i] == null)
                {
                    companies[i] = new CompanyEmpWage(name, wagePerHour, workingHoursPerMonth, workingDaysPerMonth);
                    break;
                }
            }
        }

        public void CalculateWages()
        {
            for (int i = 0; i < companies.Length; i++)
            {
                if (companies[i] != null)
                {
                    Employee employee = new Employee(true, false, companies[i].GetWagePerHour(), companies[i].GetWorkingHoursPerMonth());

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

                        employee.CalculateMonthlyWage(companies[i].GetWorkingHoursPerMonth(), companies[i].GetWorkingDaysPerMonth());
                        int monthlyWage = employee.GetTotalWage();
                        Console.WriteLine($"Monthly Wage for {companies[i].GetName()}: {monthlyWage}");
                    }
                    else
                    {
                        Console.WriteLine("Employee is Absent");
                    }
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            EmpWageBuilder empWageBuilder = new EmpWageBuilder();

            // Add companies
            empWageBuilder.AddCompany("Company 1", 10, 160, 20); // Assuming 160 working hours per month (8 hours per day, 20 days per month)
            empWageBuilder.AddCompany("Company 2", 12, 180, 22); // Assuming 180 working hours per month (9 hours per day, 20 days per month)

            // Calculate wages for all companies
            empWageBuilder.CalculateWages();
        }
    }
}
