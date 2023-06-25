using ConsoleApp2.Model;

namespace TestProject;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        DBInit dbInit = new DBInit();
        dbInit.InitializeDataBase();
        Assert.Pass();
        Assert.Pass();
    }
}