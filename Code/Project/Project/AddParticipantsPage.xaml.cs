using Microsoft.VisualBasic;
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
    /// Interaction logic for AddParticipantsPage.xaml
    /// </summary>
    public partial class AddParticipantsPage : Page, IAddParticipantsPage
    {
        public static string ProjectName { get { return Global.ProjectName; } }
        public ObservableCollection<string> ScrollViewItems { get; set; }

        public AddParticipantsPage()
        {
            ScrollViewItems = new ObservableCollection<string>();
        }

        public void NewParticipantsPage()
        {
            if (null == Global.Window)
            {
                return;
            }
            InitializeComponent();

            this.DataContext = this;
            Global.Window.Content = this;
        }
        private void AddPersonButton(object sender, RoutedEventArgs e)
        {
            if(false == string.IsNullOrEmpty(PersonNameInput.Text))
            {
                ScrollViewItems.Add(PersonNameInput.Text);
            }
            else
            {

            }
        }
        private void RemovePersonButton(object sender, RoutedEventArgs e)
        {
            if(ScrollViewItems.Count > 0)
            {
                ScrollViewItems.Remove(ScrollViewItems.Last());
            }
        }

        private void NextPageButton(object sender, RoutedEventArgs e)
        {
            if(ScrollViewItems.Count > 0)
            {
                INewTaskPage newTaskPage = new NewTaskPage();
                newTaskPage.NewTaskPage(ScrollViewItems.ToList());
            }
        }
    }
}
