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
            Global.Window = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool nameValidationResult = (ValidateName(ProjectNameInput.Text) && ValidateName(ScrumMasterName.Text));
            
            if (false == ValidateName(ProjectNameInput.Text))
            {
                MessageBox.Show("Invalid project name", "Invalid project details");
            }
            else if( false == ValidateName(ScrumMasterName.Text))
            {
                MessageBox.Show("Invalid SCRUM master name", "Invalid project details");
            }
            else
            {
                Global.ProjectName = ProjectNameInput.Text;
                Global.ScrumMasterName = ScrumMasterName.Text;

                IAddParticipantsPage addParticipantPage = new AddParticipantsPage();
                addParticipantPage.NewParticipantsPage();
            }
        }
        static bool ValidateName(string name)
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
