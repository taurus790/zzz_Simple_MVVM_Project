using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel; // INotifyPropertyChanged
using System.Collections.ObjectModel; // Observable Collections.
using zzz_Simple_MVVM_Project.Models; // My models.
using zzz_Simple_MVVM_Project.Commands; // My Commands. 


namespace zzz_Simple_MVVM_Project.ViewModels
{
    public class EmployeeVM : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation.
        // Notifies everything that is bounded to a property. 
        public event PropertyChangedEventHandler PropertyChanged;

        // This method will be called from setters of properties, 
        // and calls the PropertyChanged event everytime any property has been changed. 
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Properties. 
        // Employee Service of this VM. 
        EmployeeService myEmployeeService;

        // List of employees. 
        private ObservableCollection<EmployeeM> myEmployees;
        public ObservableCollection<EmployeeM> MyEmployees
        {
            get { return myEmployees; }
            set { myEmployees = value; OnPropertyChanged("MyEmployees"); }
        }

        // Selected employee. 
        private EmployeeM selectedEmployee;
        public EmployeeM SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; OnPropertyChanged("SelectedEmployee"); }
        }

        // Message to show to user.
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }
        #endregion

        #region Relay Commands.
        // Command for adding a new employee.
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get { return addCommand; }
            // set { saveCommand = value; } // There is no need in setter in commands. 
        }

        // Command for searching an employee by id. 
        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
            // set { searchCommand = value; } // There is no need in setter in commands. 
        }

        // Command for updating an employee.
        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
            // set { updateCommand = value; } // There is no need in setter in commands.
        }

        #endregion

        #region Constructor. 
        // Constructor. 
        public EmployeeVM()
        {
            myEmployeeService = new EmployeeService();
            LoadData();

            SelectedEmployee = new EmployeeM();

            addCommand = new RelayCommand(Add);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
        }
        #endregion 

        #region Display operation.
        private void LoadData()
        {
            MyEmployees = new ObservableCollection<EmployeeM>(myEmployeeService.GetAll());  
        }
        #endregion

        #region Add operation. 
        public void Add()
        {
            try
            {
                var IsAdded = myEmployeeService.Add(SelectedEmployee);
                LoadData();

                if (IsAdded)
                {
                    Message = "Employee added.";
                }
                else
                {
                    Message = "Add operation failed.";
                }
            }
            catch (Exception ex)
            {
                Message= ex.Message;
            }
        }
        #endregion

        #region Search operation.
        public void Search ()
        {
            try
            {
                var foundEmployee = myEmployeeService.Search(SelectedEmployee.Id);
                if (foundEmployee != null)
                {
                    SelectedEmployee.Name = foundEmployee.Name;
                    SelectedEmployee.Age = foundEmployee.Age;
                    Message = "Employee found.";
                }
                else
                {
                    SelectedEmployee.Name = null;
                    SelectedEmployee.Age = 0;
                    Message = "Employee not found.";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region Update operation. 
        public void Update()
        {
            try
            {
                var IsUpdated = myEmployeeService.Update(SelectedEmployee);
                if (IsUpdated)
                {
                    Message = "Employee updated.";
                    LoadData();
                }
                else
                {
                    Message = "Update operation failed.";
                }
            }
            catch (Exception ex)
            {
                Message=ex.Message;
            }
        }
        #endregion
    }
}
