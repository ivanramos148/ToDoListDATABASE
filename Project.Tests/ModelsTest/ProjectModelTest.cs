using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Models;

namespace Project.Models.Tests
{
  [TestClass]
  public class ProjectTest
  {
    [TestMethod]
    public void Test_JustATest_True()
    {
      Assert.AreEqual(true, ProjectModel.Test(true));
      Assert.AreEqual(false, ProjectModel.Test(false));
    }
  }
}