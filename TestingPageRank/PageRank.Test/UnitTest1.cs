using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PageRank.Test;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Test_1()
    {
       MainClass pr = new MainClass();
       pr.run();
    }
}