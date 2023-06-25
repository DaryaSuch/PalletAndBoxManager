namespace ConsoleApp2.Model;

public class DBInit
{
    DBContext context = new DBContext();
    public bool InitializeDataBase()
    {
        try
        {
            List<Box> boxesOne = new List<Box>
            {
                new Box(10, 20, 20, 10, "31.03.2010"),
                new Box(10, 10, 10, 10, "31.03.2010"),
            };
            List<Box> boxesTwo = new List<Box>
            {
                new Box(10, 10, 10, 10, "31.03.2013"),
            };
            List<Box> boxesThree = new List<Box>
            {
                new Box(10, 30, 30, 10, "31.03.2006"),
                new Box(10, 20, 20, 10, "31.03.2001"),
                new Box(10, 20, 20, 10, "31.03.2001")
            };
            List<Box> boxesFour = new List<Box>
            {
                new Box(10, 10, 10, 10, "31.03.2001"),
                new Box(10, 20, 20, 10, "31.03.2001"),
            };
            Pallet palletOne = new Pallet(10, 10, 10, boxesOne);
            Pallet palletTwo = new Pallet(10, 40, 40, boxesTwo);
            Pallet palletThree = new Pallet(10, 20, 20, boxesThree);
            Pallet palletFour = new Pallet(10, 20, 20, boxesFour);
            context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}