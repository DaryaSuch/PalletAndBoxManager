using ConsoleApp2.Model;

namespace ConsoleApp2.Controller;

public class PalletController
{
    public List<Pallet> SortPalletsByWeight(List<Pallet> input)
    {
        return input.OrderBy(p => p.PalletWeight).ToList();
    }

    public List<Pallet> GetPalletsByDate(DateOnly date)
    {
        DBContext context = new DBContext();
        return context.Pallets.Where(p => p.PalletDate == date).ToList();
    }
    
    public Pallet GetPalletById(int id)
    {
        DBContext context = new DBContext();
        return context.Pallets.Where(p => p.IdPallet == id).FirstOrDefault();
    }
}