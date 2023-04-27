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
            if (Global.ValidateText(TaskName.Text))
            {
                if (null == Global.Tasks.FirstOrDefault(x => string.Equals(x.Name, TaskName.Text)))
                {
                    if(Global.ValidateText(TaskDescription.Text))
                    {
                        IPlanningPokerPage newPokerPage = new PlanningPokerPage();
                        newPokerPage.NewPlanningPokerPage(TaskName.Text, TaskDescription.Text, employees);
                    }
                    else
                    {
                        MessageBox.Show("Невалидно описание на задача! \nОписанието не трябва да е празно или да започва с цифра.", "Невалидно описание на задача");
                    }
                }
                else
                {
                    MessageBox.Show("Задача със същото име вече съществува!", "Задачата съществува");
                }
            }
            else
            {
                MessageBox.Show("Невалидно име на задача! \nИмето не трябва да е празно или да започва с цифра.", "Невалидно име на задача");
            }
        }
    }
}
