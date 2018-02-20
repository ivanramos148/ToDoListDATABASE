using Microsoft.VisualStudio.TestTools.UnitTesting;
using _template_.Models;

namespace _template_.Models.Tests
{
  [TestClass]
  public class ProjectTest
  {
    [TestMethod]
    public void Test_JustATest_String()
    {
      Assert.AreEqual("this is a string from the model", _template_Model.GetString());
    }
  }
}