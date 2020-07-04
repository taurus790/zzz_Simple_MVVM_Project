using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel; // INotifyPropertyChanged

namespace zzz_Simple_MVVM_Project.Models
{
    public class EmployeeM : INotifyPropertyChanged
    {
        #region InOtifyPropertyChanged implementation. 
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
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged("Age"); }
        }
        #endregion

        #region Constructor. 
        // Constructor. 
        public EmployeeM()
        {
            Id = 0;
            Name = "John Smith";
            Age = 21;
        }
        #endregion
    }
}
