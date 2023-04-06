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

namespace Project
{
    /// <summary>
    /// Interaction logic for PlanningPokerPage.xaml
    /// </summary>
    public partial class PlanningPokerPage : Page, IPlanningPokerPage
    {
        private string taskName = "";
        private string taskDescription = "";
        private List<string> employeeList = new List<string>();

        public void NewPlanningPokerPage(string taskName, string taskDescription, List<string> employeeList)
        {
            this.taskName = taskName;
            this.taskDescription = taskDescription;
            this.employeeList = employeeList;

            if (null == Global.Window)
            {
                return;
            }
            InitializeComponent();

            this.DataContext = this;
            Global.Window.Content = this;
        }

        public string TaskName { get {  return taskName; } }
        public string TaskDescription { get {  return taskDescription; } }
    }
}
