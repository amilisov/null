﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Project.Interfaces;
using Project.Other;
using Task = Project.Other.Task;

namespace Project
{
    /// <summary>
    /// Interaction logic for PlanningPokerPage.xaml
    /// </summary>
    public partial class PlanningPokerPage : Page, IPlanningPokerPage
    {
        private string taskName = "";
        private string taskDescription = "";
        private int taskRating = 0;
        private ObservableCollection<string> employeeList = new ObservableCollection<string>();
        public readonly ObservableCollection<int> ratingList = new ObservableCollection<int>() {0, 1, 2, 3, 5, 8, 13, 20, 40, 100};
        public readonly List<DockPanel> dockPanels = new List<DockPanel>();

        public void NewPlanningPokerPage(string taskName, string taskDescription, ObservableCollection<string> employeeList)
        {
            this.taskName = taskName;
            this.taskDescription = taskDescription;
            this.employeeList = employeeList;

            if (null == Global.Window)
            {
                return;
            }
            
            InitializeComponent();

            // Add every employee
            foreach (var employee in this.employeeList)
            {
                // Create new panel to grou employee and rating
                DockPanel stackPanel = new DockPanel()
                {
                    Margin = new Thickness(0,5,0,5),
                    Name = employee
                };
                // Create new box to store rating
                ComboBox ratingBox = new ComboBox()
                {
                    ItemsSource = ratingList,
                    SelectedValue = ratingList[0],
                    Name = "Rating",
                    HorizontalAlignment = HorizontalAlignment.Right,
                    MinWidth = 35,
                    MaxHeight = 20
                };

                // Add handler for selection value changed
                ratingBox.SelectionChanged += new SelectionChangedEventHandler(Fibonacci_SelectionChanged);

                // Create new box to display user
                TextBlock employeeBlock = new TextBlock()
                {
                    Text = employee,
                    TextWrapping = TextWrapping.Wrap,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    MaxWidth = 200
                };

                // Add employee and rating to group panel
                stackPanel.Children.Add(employeeBlock);
                stackPanel.Children.Add(ratingBox);

                // Add group panel to main panel
                Dock.Children.Add(stackPanel);

                dockPanels.Add(stackPanel);
            }

            this.DataContext = this;
            Global.Window.Content = this;
        }
        public string TaskName { get {  return taskName; } }
        public string TaskDescription { get {  return taskDescription; } }
        public string ScrumMasterName { get { return Global.ScrumMasterName; } }
        public int TaskRating { get { return taskRating; } }
        public void ClearSelection(object sender, RoutedEventArgs e)
        {
            // Set every rating to 0 when clicked
            foreach (var stackPanel in dockPanels)
            {
                ComboBox dropdown = stackPanel.Children.OfType<ComboBox>().Single();
                dropdown.SelectedValue = ratingList[0];
            }
        }
        private void Fibonacci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int val = 0;
            double sum = 0;
            double avg = 0;
            foreach (var stackPanel in dockPanels)
            {
                // Calculate sum for all ratings
                ComboBox dropdown = stackPanel.Children.OfType<ComboBox>().Single();
                Int32.TryParse(dropdown.SelectedValue.ToString(), out val);
                sum += val;
            }

            if(dockPanels.Count > 0)
            {
                // Calculate average rating
                taskRating = (int)Math.Ceiling(sum / dockPanels.Count);
                avg = Math.Round((sum / dockPanels.Count),1);
            }

            foreach (var num in ratingList)
            {
                if(num >= taskRating)
                {
                    // Get closest number from rating list,
                    taskRating = num;
                    break;
                }
            }

            AverageRating.Text = taskRating.ToString() + " (" + avg.ToString() + ")";
        }
        private void NewTask(object sender, RoutedEventArgs e)
        {
            int val = -1;
            int prevVal = -1;

            Boolean error = false;
            foreach (var stackPanel in dockPanels)
            {
                // Check if all users agree on a rating
                ComboBox dropdown = stackPanel.Children.OfType<ComboBox>().Single();
                Int32.TryParse(dropdown.SelectedValue.ToString(), out val);
                if(prevVal != -1)
                {
                    if(val != prevVal)
                    {
                        error = true;
                        break;
                    }
                }
                prevVal = val;
            }

            if(error == false)
            {
                // If all users agree, create new task window
                Task task = new Task();
                task.Name = TaskName;
                task.Description = TaskDescription;
                task.Rating = taskRating;
                    
                Global.Tasks.Add(task);

                INewTaskPage newTaskPage = new NewTaskPage();
                newTaskPage.NewTaskPage(employeeList);
            }
            else
            {
                // If users don't agree, display popup
                MessageBox.Show("Всички участници трябва да се съгласят на еднаква оценка!", "Разлика в оценките");
            }
        }
        private void LoadNextPage(object sender, RoutedEventArgs e)
        {
            int val = -1;
            int prevVal = -1;

            Boolean error = false;
            foreach (var stackPanel in dockPanels)
            {
                // Check if all users agree on a rating
                ComboBox dropdown = stackPanel.Children.OfType<ComboBox>().Single();
                Int32.TryParse(dropdown.SelectedValue.ToString(), out val);
                if (prevVal != -1)
                {
                    if (val != prevVal)
                    {
                        error = true;
                        break;
                    }
                }
                prevVal = val;
            }

            if (error == false)
            {
                // If all users agree, create new file window
                Task task = new Task();
                task.Name = TaskName;
                task.Description = TaskDescription;
                task.Rating = taskRating;

                Global.Tasks.Add(task);

                IFileWritePage newFilePage = new FileWritePage();
                newFilePage.NewFileWritePage(employeeList.ToList());
            }
            else
            {
                // If users don't agree, display popup
                MessageBox.Show("Всички участници трябва да се съгласят на еднаква оценка!", "Разлика в оценките");
            }
        }
    }
}
