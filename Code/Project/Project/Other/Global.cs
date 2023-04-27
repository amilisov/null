using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Project.Other
{
    public static class Global
    {
        public static string ProjectName = "";
        public static string ScrumMasterName = "";
        public static List<Task> Tasks = new List<Task>();
        public static Window? Window = null;
        static Global()
        {
        }
        public static bool ValidateText(string text)
        {
            if (string.IsNullOrEmpty(text.Trim()))
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
