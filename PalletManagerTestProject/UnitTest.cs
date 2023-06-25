using ConsoleApp2.Controller;
using ConsoleApp2.Model;

namespace TestProject1;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod()
    {
        BoxController boxController = new BoxController();
        MainController mainController = new MainController();
        PalletController palletController = new PalletController();
        DBInit dbInit = new DBInit();
        List<Box> newBoxes = new List<Box>();
        List<DateOnly> newDates = new List<DateOnly>();
        Assert.AreEqual(dbInit.InitializeDataBase(), true);
        CollectionAssert.AreEqual(boxController.SortBoxByVolume(newBoxes), newBoxes);
        CollectionAssert.AreEqual(boxController.GetBoxesByPalletId(-1), newBoxes);
        CollectionAssert.AreNotEqual(mainController.GetDates(),newDates);
        Assert.IsTrue(mainController.WritePallets());
        Assert.IsTrue(mainController.WriteBoxes());
        Assert.AreEqual(palletController.GetPalletById(-1), null);
    }
}