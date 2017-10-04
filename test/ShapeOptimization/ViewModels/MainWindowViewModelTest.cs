using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeOptimization.Models;

namespace ShapeOptimization.ViewModels
{
    [TestClass]
    public class MainWindowViewModelTest
    {
        private MainWindowViewModel ViewModel { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            ViewModel = new MainWindowViewModel();
        }

        [TestMethod]
        public void SetIsInAddLineModeToTrueShouldChangeModeToAddLine()
        {
            ViewModel.IsInAddLineMode = true;

            Assert.IsTrue(ViewModel.IsInAddLineMode, "want IsInAddLineMode == true; got false");
            Assert.AreEqual(ViewModel.Mode, EditMode.AddLine, "want ViewModel.Mode == AddLine; got ViewModel.Mode == {0}", ViewModel.Mode);
            Assert.IsFalse(ViewModel.IsInAddPointMode, "want IsInAddPointMode == false; got true");
            Assert.IsFalse(ViewModel.IsInSelectItemMode, "want IsInSelectItemMode == false; got true");
            Assert.AreNotEqual(ViewModel.Mode, EditMode.None, "want ViewModel.Mode != None; got ViewModel.Mode == None");
        }

        [TestMethod]
        public void SetIsInAddPointModeToTrueShouldChangeModeToAddPoint()
        {
            ViewModel.IsInAddPointMode = true;

            Assert.IsTrue(ViewModel.IsInAddPointMode, "want IsInAddPointMode == true; got false");
            Assert.AreEqual(ViewModel.Mode, EditMode.AddPoint, "want ViewModel.Mode == AddLine; got ViewModel.Mode == {0}", ViewModel.Mode);
            Assert.IsFalse(ViewModel.IsInAddLineMode, "want IsInAddLineMode == false; got true");
            Assert.IsFalse(ViewModel.IsInSelectItemMode, "want IsInSelectItemMode == false; got true");
            Assert.AreNotEqual(ViewModel.Mode, EditMode.None, "want ViewModel.Mode != None; got ViewModel.Mode == None");
        }

        [TestMethod]
        public void SetIsInSelectItemModeToTrueShouldChangeModeToSelectItem()
        {
            ViewModel.IsInSelectItemMode = true;

            Assert.IsTrue(ViewModel.IsInSelectItemMode, "want IsInSelectItemMode == true; got false");
            Assert.AreEqual(ViewModel.Mode, EditMode.SelectItem, "want ViewModel.Mode == AddLine; got ViewModel.Mode == {0}", ViewModel.Mode);
            Assert.IsFalse(ViewModel.IsInAddLineMode, "want IsInAddLineMode == false; got true");
            Assert.IsFalse(ViewModel.IsInAddPointMode, "want IsInAddPointMode == false; got true");
            Assert.AreNotEqual(ViewModel.Mode, EditMode.None, "want ViewModel.Mode != None; got ViewModel.Mode == None");
        }
    }
}
