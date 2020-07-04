using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using zzz_Simple_MVVM_Project.ViewModels; // View models. 

namespace zzz_Simple_MVVM_Project
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeVM MyEmployeeVM;
        public MainWindow()
        {
            InitializeComponent();
            MyEmployeeVM = new EmployeeVM();
            this.DataContext = MyEmployeeVM;
        }
    }
}
