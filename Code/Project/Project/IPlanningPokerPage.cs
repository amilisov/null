using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal interface IPlanningPokerPage
    {
        public void NewPlanningPokerPage(string taskName, string taskDescription, List<string> employeeList);
    }
}
