using Microsoft.VisualBasic;
using Project.Interfaces;
using Project.Other;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
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
using static System.Net.Mime.MediaTypeNames;

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
            if(true == Global.ValidateText(PersonNameInput.Text))
            {
                if (null == ScrollViewItems.FirstOrDefault(x => string.Equals(x, PersonNameInput.Text)))
                {
                    ScrollViewItems.Add(PersonNameInput.Text);
                    PersonNameInput.Text = "";
                }
                else
                {
                    MessageBox.Show("Participant present in list! Please input a different name", "Participant present");  
                }
            }
            else
            {
                MessageBox.Show("Name cannot be empty", "Participant without name");
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
                newTaskPage.NewTaskPage(ScrollViewItems);
            }
        }

        private void Input_EnterKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddPersonButton(sender, new RoutedEventArgs());
            }
        }
    }
}
