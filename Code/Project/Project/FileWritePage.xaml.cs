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
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Project.Other;
using Project.Interfaces;
using Task = Project.Other.Task;

namespace Project
{
    /// <summary>
    /// Interaction logic for FileWritePage.xaml
    /// </summary>
    public partial class FileWritePage : Page, IFileWritePage
    {
        private List<string> employees = new List<string>();    
        public void NewFileWritePage(List<string> employees)
        {
            this.employees = employees;
            if (null == Global.Window)
            {
                return;
            }
            InitializeComponent();

            this.DataContext = this;
            Global.Window.Content = this;
        }

        public int TaskCount { get { return Global.Tasks.Count; } }

        private void TxtExport(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                string path = dialog.SelectedPath + "\\SCRUM Сесия " + Global.ProjectName + " " + DateTime.Now.ToString("dd/MM/yyyy") + ".txt";
                StreamWriter writer = new StreamWriter(path);

                writer.WriteLine(DateTime.Now.ToString());
                writer.WriteLine("==================================");
                writer.WriteLine("Проект: " + Global.ProjectName);
                writer.WriteLine("SCRUM master: " + Global.ScrumMasterName);
                writer.WriteLine("==================================");

                writer.WriteLine("Участници:");
                foreach (var employee in employees)
                {
                    writer.WriteLine(employee);
                }
                writer.WriteLine("==================================");

                foreach (Task task in Global.Tasks)
                {
                    writer.WriteLine(task.Name);
                    writer.WriteLine(task.Description);
                    writer.WriteLine("Точки на историята: " + task.Rating);
                    writer.WriteLine("==================================");
                }

                writer.WriteLine("Генерирани " + Global.Tasks.Count + " задачи");
                writer.Close();
            }
        }

        private void JsonExport(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string path = dialog.SelectedPath + "\\SCRUM Сесия " + Global.ProjectName + " " + DateTime.Now.ToString("dd/MM/yyyy") + ".json";
                StreamWriter writer = new StreamWriter(path);

                JsonOutput json = new JsonOutput
                {
                    ProjectName = Global.ProjectName,
                    ScrumMasterName = Global.ScrumMasterName,
                    CurrentDate = DateTime.Now.ToString(),
                    TaskCount = Global.Tasks.Count,
                    Tasks = Global.Tasks,
                    Employees = employees
                };

                writer.WriteLine(JsonConvert.SerializeObject(json, Formatting.Indented));

                writer.Close();
            }
        }

        private void ExitPoker(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

    }

    internal class JsonOutput
    {
        public string ProjectName = "";
        public string ScrumMasterName = "";
        public string CurrentDate = "";
        public int TaskCount;
        public List<Task> Tasks = new List<Task>();
        public List<string> Employees = new List<string>();
    }
}
