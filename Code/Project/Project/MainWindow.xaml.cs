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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool nameValidationResult = ValidateProjectName(ProjectNameInput.Text);

            Console.WriteLine("AddParticipantsPage");
            if (true == nameValidationResult)
            {
                ErrorTextOutput.Text = "";
                Global.ProjectName = ProjectNameInput.Text;

                IAddParticipantsPage addParticipantPage = new AddParticipantsPage();
                addParticipantPage.NewParticipantsPage();
            }
            else
            {
                ErrorTextOutput.Text = "Invalid project name";
            }
        }
        static bool ValidateProjectName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
