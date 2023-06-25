using ConsoleApp2.Model;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Controller;

public class BoxController
{
    DBContext context = new DBContext();
    public List<Box> SortBoxByVolume(List<Box> input)
    {
        return input.OrderBy(b => b.BoxVolume).ToList();
    }

    public bool IsBoxMatchesToPallet(Box box, Pallet pallet)
    {
        if ((box.BoxWidth <= pallet.PalletWidth) && (box.BoxDepth <= pallet.PalletDepth))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<Box> GetBoxesByPalletId(int id)
    {
        try
        {
            return context.Boxes.Where(b => b.IdPallet == id).ToList();
        }
        catch
        {
            return new List<Box>();
        }
    }
    
    public void AddBoxesToPallets(List<Box> boxes, Pallet pallet)
    {
        foreach (Box box in boxes)
        {
            box.IdPallet = pallet.IdPallet;
            context.Entry(box).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}