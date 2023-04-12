using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Project
{
    /// <summary>
    /// Interaction logic for NewTaskPage.xaml
    /// </summary>
    public partial class NewTaskPage : Page, INewTaskPage
    {
        private ObservableCollection<string> employees = new ObservableCollection<string>();

        void INewTaskPage.NewTaskPage(ObservableCollection<string> children)
        {
            employees = children;

            if (null == Global.Window)
            {
                return;
            }
            InitializeComponent();

            this.DataContext = this;
            Global.Window.Content = this;
        }

        private void NextPageButton(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(TaskName.Text) || 
                  string.IsNullOrEmpty(TaskDescription.Text)))
            {
                IPlanningPokerPage newPokerPage = new PlanningPokerPage();
                newPokerPage.NewPlanningPokerPage(TaskName.Text, TaskDescription.Text, employees);
            }
        }
    }
}
