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

namespace Project
{
    /// <summary>
    /// Interaction logic for AddParticipantsPage.xaml
    /// </summary>
    public partial class AddParticipantsPage : Page, IAddParticipantsPage
    {
        uint numberOfcrollListItems = 0;
        public string ProjectName { get { return Global.ProjectName; } }
        public void NewParticipantsPage(object parent)
        {
            InitializeComponent();

            this.DataContext = this;
            ((Window)parent).Content = this;
        }
        private void AddPersonButton(object sender, RoutedEventArgs e)
        {
            if(false == string.IsNullOrEmpty(PersonNameInput.Text))
            {
                NamesListOutput.Children.Add(CreateScrollListChild(PersonNameInput.Text));
                numberOfcrollListItems++;
            }
            else
            {

            }
        }

        UIElement CreateScrollListChild(string text)
        {
            TextBlock child = new TextBlock();
            child.Text = text;
            child.HorizontalAlignment = HorizontalAlignment.Center;
            return child;
        }

        private void NextPageButton(object sender, RoutedEventArgs e)
        {
            if(numberOfcrollListItems > 0)
            {
                INewTaskPage newTaskPage = new NewTaskPage();
                newTaskPage.NewTaskPage(this);
            }
        }
    }
}
