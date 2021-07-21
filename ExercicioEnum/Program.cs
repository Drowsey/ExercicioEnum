using System;
using System.Globalization;
using ExercicioEnum.Entities;
using ExercicioEnum.Entities.Enums;
namespace ExercicioEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            Console.Write("Enter worker data\nName: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("How may contracts to this worker? ");
            int numContracts = int.Parse(Console.ReadLine());

            Department department = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, department);

            for(int i = 1; i <= numContracts; i++)
            {
                Console.WriteLine($"\nEnter #{i} contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (Hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.Write("\nEnter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.Write($"Name: {worker.Name}\nDepartment: {worker.Department.Name}\nIncome for {monthAndYear}: {worker.Income(year, month)}");
        }
    }
}
