﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

        public static bool ValidateText(string text)
        {
            if (string.IsNullOrEmpty(text.Trim()))
            {
                // Not valid if string is null or empty
                return false;
            }
            else
            {
                char[] chars = text.ToCharArray();

                if (Char.IsDigit(chars[0]))
                {
                    // Not valid if first char is numeric
                    return false;
                }

                // Valid
                return true;
            }
        }
    }
}
