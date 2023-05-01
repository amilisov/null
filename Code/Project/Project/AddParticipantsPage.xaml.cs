using Microsoft.VisualBasic;
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
                    // add user to list if they are not already on it and if their name is valid
                    ScrollViewItems.Add(PersonNameInput.Text);
                    PersonNameInput.Text = "";
                }
                else
                {
                    MessageBox.Show("Участникът вече е в списъка! Моля въведете друго име.", "Участникът вече е добавен");  
                }
            }
            else
            {
                MessageBox.Show("Невалидно име! \nИмето не трябва да е празно или да започва с число.", "Невалидно име на участник");
            }
        }
        private void RemovePersonButton(object sender, RoutedEventArgs e)
        {
            if(ScrollViewItems.Count > 0)
            {
                // remove last user from list if list is not empty
                ScrollViewItems.Remove(ScrollViewItems.Last());
            }
        }

        private void NextPageButton(object sender, RoutedEventArgs e)
        {
            if(ScrollViewItems.Count > 0)
            {
                // if there are valid users added, create new page
                INewTaskPage newTaskPage = new NewTaskPage();
                newTaskPage.NewTaskPage(ScrollViewItems);
            }
            else
            {
                MessageBox.Show("Трябва да има поне един въведен участник.", "Невалиден брой участници");
            }
        }

        private void Input_EnterKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // if enter key is pressed, add new user
                AddPersonButton(sender, new RoutedEventArgs());
            }
        }
    }
}
