using System;

namespace OOPEWC
{
    internal class Employee
    {
        private bool isPresent;

        public Employee()
        {
            Random random = new Random();
            isPresent = random.Next(0, 2) == 0 ? false : true;
        }

        public bool IsPresent()
        {
            return isPresent;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();

            if (employee.IsPresent())
            {
                Console.WriteLine("Employee is Present");
            }
            else
            {
                Console.WriteLine("Employee is Absent");
            }
        }
    }
}
