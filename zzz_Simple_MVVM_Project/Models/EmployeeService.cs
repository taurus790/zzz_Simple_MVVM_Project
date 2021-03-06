﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzz_Simple_MVVM_Project.Models
{
    class EmployeeService
    {
        #region Properties. 
        private static List<EmployeeM> MyEmployees;
        #endregion

        #region Constructor. 
        public EmployeeService()
        {
            MyEmployees = new List<EmployeeM>()
            {
                new EmployeeM { Id=101, Name="Ali", Age=21}
            };
        }
        #endregion

        #region Methods. 
        public List<EmployeeM> GetAll()
        {
            return MyEmployees;
        }

        public bool Add(EmployeeM freshEmployee)
        {
            // Age must be between 18 and 65. 
            if (freshEmployee.Age < 18 || freshEmployee.Age > 65)
            {
                throw new ArgumentException("Invalid age. Must be between 18 and 65.");
            }

            // Adds a new employee with the same details.
            MyEmployees.Add(new EmployeeM() { Id = freshEmployee.Id, Name = freshEmployee.Name, Age = freshEmployee.Age });

            return true;
        }
        public EmployeeM Search(int id)
        {
            return MyEmployees.FirstOrDefault(e => e.Id == id);
        }

        public bool Update(EmployeeM updEmployee)
        {
            bool isUpdated = false;
            bool isFound = false;

            // Age must be between 18 and 65. 
            if (updEmployee.Age < 18 || updEmployee.Age > 65)
            {
                throw new ArgumentException("Invalid age. Must be between 18 and 65.");
            }

            for (int i = 0; i < MyEmployees.Count; i++)
            {
                if (MyEmployees[i].Id == updEmployee.Id)
                {
                    MyEmployees[i].Name = updEmployee.Name;
                    MyEmployees[i].Age = updEmployee.Age;

                    isUpdated = true;
                    isFound = true;
                    break;
                }
            }

            // Error message in case the employee not found. 
            if (!isFound)
            {
                throw new ArgumentException("Employee not found.");
            }

            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;

            for (int i = 0; i < MyEmployees.Count; i++)
            {
                if (MyEmployees[i].Id == id)
                {
                    MyEmployees.RemoveAt(i);

                    isDeleted = true;
                    break;
                }
            }

            return isDeleted;
        }
        #endregion
    }
}
