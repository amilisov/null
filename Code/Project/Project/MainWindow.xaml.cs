﻿using System;
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
using Project.Interfaces;
using Project.Other;

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
            if (false == Global.ValidateText(ProjectNameInput.Text))
            {
                MessageBox.Show("Невалидно име на проект! \nИмето не трябва да е празно или да започва с цифра.", "Невалидни детайли за проект");
            }
            else if( false == Global.ValidateText(ScrumMasterName.Text))
            {
                MessageBox.Show("Невалидно име на SCRUM master! \nИмето не трябва да е празно или да започва с цифра.", "Невалидни детайли за проект");
            }
            else
            {
                // If everything is ok, create new page
                Global.ProjectName = ProjectNameInput.Text;
                Global.ScrumMasterName = ScrumMasterName.Text;

                IAddParticipantsPage addParticipantPage = new AddParticipantsPage();
                addParticipantPage.NewParticipantsPage();
            }
        }
    }
}
