using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public interface IPlanningPokerPage
    {
        public void NewPlanningPokerPage(string taskName, string taskDescription, ObservableCollection<string> employeeList);
    }
}
