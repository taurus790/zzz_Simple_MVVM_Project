using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzz_Simple_MVVM_Project.Models
{
    class EmployeeService
    {
        private static List<Employee> Employees;

        public EmployeeService()
        {
            Employees = new List<Employee>()
            {
                new Employee { Id=101, Name="Ali", Age=21}
            };
        }

        public List<Employee> GetAll()
        {
            return Employees;
        }

        public bool Add(Employee freshEmployee)
        {
            // Age must be between 18 and 65. 
            if (freshEmployee.Age < 18 || freshEmployee.Age > 65)
            {
                throw new ArgumentException("invalid age. Must be 18 < x < 65");
            }

            Employees.Add(freshEmployee);
            return true;
        }

        public bool Update(Employee updEmployee)
        {
            bool isUpdated = false;

            for (int i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].Id == updEmployee.Id)
                {
                    Employees[i].Name = updEmployee.Name;
                    Employees[i].Age = updEmployee.Age;

                    isUpdated = true;
                    break;
                }
            }

            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;

            for (int i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].Id == id)
                {
                    Employees.RemoveAt(i);

                    isDeleted = true;
                    break;
                }
            }

            return isDeleted;
        }
    
        public Employee Search(int id)
        {
            return Employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
