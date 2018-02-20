using Microsoft.VisualStudio.TestTools.UnitTesting;
using template.Models;

namespace template.Models.Tests
{
  [TestClass]
  public class ProjectTest
  {
    [TestMethod]
    public void Test_JustATest_String()
    {
      Assert.AreEqual("this is a string from the model", templateModel.GetString());
    }
  }
}