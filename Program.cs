using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Salary_Adjuster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> employeeNames = new List<string>();
            List<float> salaries = new List<float>();
            List<float> adjustedSalaries = new List<float>();
            List<string> highEarners = new List<string>();

            Console.WriteLine("Enter employee names and salaries (type 'done' to finish):");

            while (true)
            {
                Console.Write("Employee name: ");
                string name = Console.ReadLine();

                if (name.ToLower() == "done")
                    break;

                Console.Write("Salary: ");
                if (float.TryParse(Console.ReadLine(), out float salary))
                {
                    employeeNames.Add(name);
                    salaries.Add(salary);
                }
                else
                {
                    Console.WriteLine("Invalid salary. Please enter a valid number.");
                }
            }
            for (int i = 0; i < salaries.Count; i++)
            {
                float newSalary = salaries[i];

                if (salaries[i] < 15000)
                {
                    newSalary = salaries[i] * 1.05f; 
                }
                else if (salaries[i] <= 30000)
                {
                    newSalary = salaries[i] * 1.03f; 
                }

                adjustedSalaries.Add(newSalary);
              
                if (newSalary > 25000)
                {
                    highEarners.Add(employeeNames[i]);
                }
            }
            Console.WriteLine("\nAdjusted Salaries:");
            for (int i = 0; i < employeeNames.Count; i++)
            {
                Console.WriteLine($"{employeeNames[i]}: {salaries[i]:C} → {adjustedSalaries[i]:C}");
            }

            Console.WriteLine("\nEmployees earning above 25,000 after adjustment:");
            if (highEarners.Count > 0)
            {
                foreach (string name in highEarners)
                {
                    Console.WriteLine(name);
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}
