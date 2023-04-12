using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Task
    {
        private string _Name = "";
        private string _Description = "";
        private int _Rating;

        public string Name { get { return _Name; } set { _Name = value; } }
        public string Description { get { return _Description; } set { _Description = value; } }
        public int Rating { get { return _Rating; } set { _Rating = value; } }
    }
}
