using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel; // INotifyPropertyChanged
using System.Collections.ObjectModel; // Observable Collections.
using zzz_Simple_MVVM_Project.Models; 


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

        // Selected employee. 
        private EmployeeM selectedEmployee;
        public EmployeeM SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; OnPropertyChanged("SelectedEmployee"); }
        }

        #endregion

        #region Constructor. 
        // Constructor. 
        public EmployeeVM()
        {
            myEmployeeService = new EmployeeService();
            LoadData();

            SelectedEmployee = new EmployeeM();
        }
        #endregion 

        #region Display operation.
        // List of employees. 
        private ObservableCollection<EmployeeM> myEmployees;
        public ObservableCollection<EmployeeM>  MyEmployees
        {
            get { return myEmployees; }
            set { myEmployees = value; OnPropertyChanged("MyEmployees"); }
        }

        private void LoadData()
        {
            MyEmployees = new ObservableCollection<EmployeeM>(myEmployeeService.GetAll());  
        }
        #endregion
    
        
    }
}
