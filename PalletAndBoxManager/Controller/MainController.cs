using ConsoleApp2.Model;

namespace ConsoleApp2.Controller;

public class MainController
{
    DBContext context = new DBContext();
    PalletController palletController = new PalletController();
    BoxController boxController = new BoxController();
    public List<DateOnly> GetDates()
    {
        List<DateOnly> result = new List<DateOnly>();
        var a= context.Pallets.GroupBy(p => p.PalletDate).Select(g=>new {g.Key});
        foreach (var item in a)
        {
            result.Add(DateOnly.Parse(item.Key.ToString()));
        }
        return result;
    }

    public bool WritePallets()
    {
        try
        {
            List<DateOnly> dates = GetDates();
            foreach (DateOnly date in dates)
            {
                Console.WriteLine("\n" + date + " Номера паллет:");
                List<Pallet> pallets = palletController.GetPalletsByDate(date);
                palletController.SortPalletsByWeight(pallets);
                foreach (Pallet pallet in pallets)
                {
                    Console.Write(pallet.IdPallet + " ");
                }
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool WriteBoxes()
    {
        try
        {
            List<Pallet> pallets = context.Pallets.ToList();
            if (pallets.Count > 3)
            {
                Console.WriteLine("\n3 паллеты с наибольшим сроком годности");
                for (int i = 1; i < 4; i++)
                {
                    printCycle(pallets, i);
                }
            }
            else
            {
                Console.WriteLine("\n"+pallets.Count+" паллеты с наибольшим сроком годности");
                for (int i = 1; i < context.Pallets.Count(); i++)
                {
                    printCycle(pallets, i);
                }
            }

            return true;
        }
        catch
        {
            return false;
        }

        void printCycle(List<Pallet> pallets, int i)
        {
            Pallet pallet = pallets[pallets.Count - i];
            Console.WriteLine("\n"+pallet.IdPallet+" номер паллеты \n");
            List<Box> boxes = boxController.SortBoxByVolume(boxController.GetBoxesByPalletId(pallet.IdPallet));
            foreach (Box box in boxes)
            {
                Console.Write(box.IdBox + " ");
            }
        }
    }
}