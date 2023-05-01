using Project;
using System.Linq;
using Project.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace UnitTests
{
    [TestClass]
    public class PlanningPokerPage_UnitTests
    {

        [WpfTestMethod]
        public void UserStory6_Test_1()
        {
            // Arrange
            List<int> requiredBySpec= new List<int>() { 0, 1, 2, 3, 5, 8, 13, 20, 40, 100};
            PlanningPokerPage Page = new PlanningPokerPage();

            // Act

            // Assert
            Assert.AreEqual(requiredBySpec.Count(), Page.ratingList.Count());

            foreach(var req in requiredBySpec)
            {
                Assert.IsTrue(Page.ratingList.Contains(req));
            }
        }

        [WpfTestMethod]
        public void UserStory7_Test_1()
        {
            // Arrange
            ComboBox select;
            PlanningPokerPage Page = new PlanningPokerPage(); 
            Page.NewPlanningPokerPage(
                new String("Task Name"),
                new String("Task Desciption"), 
                new ObservableCollection<string>() { "name 0", "name 1", "name 2", "name 3" }
            );

            int defaultValue = 0;

            // Act
            foreach (var dock in Page.dockPanels)
            {
                select = dock.Children.OfType<ComboBox>().First();
                select.SelectedValue = 5;
            }
            Page.ClearSelection(new object(), new System.Windows.RoutedEventArgs());

            // Assert
            foreach (var dock in Page.dockPanels)
            {
                select = dock.Children.OfType<ComboBox>().First();
                Assert.AreEqual(defaultValue, select.SelectedValue);
            }
        }
    }
}