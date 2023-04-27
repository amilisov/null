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
using Project.Interfaces;
using Project.Other;

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
            if (Global.ValidateText(TaskName.Text) &&
                Global.ValidateText(TaskDescription.Text))
            {
                if (null == Global.Tasks.FirstOrDefault(x => string.Equals(x.Name, TaskName.Text)))
                {
                    IPlanningPokerPage newPokerPage = new PlanningPokerPage();
                    newPokerPage.NewPlanningPokerPage(TaskName.Text, TaskDescription.Text, employees);
                }
                else
                {
                    MessageBox.Show("Task with the same name already exists!", "Task exists");
                }
            }
            else
            {
                MessageBox.Show("Task name or description is empty!", "Task empty");
            }
        }
    }
}
