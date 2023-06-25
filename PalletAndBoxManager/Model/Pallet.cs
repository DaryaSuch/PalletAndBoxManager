using System.ComponentModel.DataAnnotations;
using ConsoleApp2.Controller;

namespace ConsoleApp2.Model;

public class Pallet
{
    [Key]
    public int IdPallet { get; set; }
    public int PalletHeight { get; set; }
    public int PalletWidth { get; set; }
    public int PalletDepth { get; set; }
    public int PalletWeight { get; set; }
    public DateOnly PalletDate { get; set; }

    public Pallet(){}

    public Pallet(int palletHeight, int palletWidth, int palletDepth, List<Box> boxes=null)
    {
        BoxController boxController = new BoxController();
        DBContext context = new DBContext();
        List<Box> matchBoxes = new List<Box>();
        this.PalletHeight = palletHeight;
        this.PalletWidth = palletWidth;
        this.PalletDepth = palletDepth;
        this.PalletWeight = 30;
        if (boxes.Count > 0)
        {
            foreach (Box box in boxes)
            {
                if (boxController.IsBoxMatchesToPallet(box, this))
                {
                    this.PalletWeight += box.BoxWeight;
                    matchBoxes.Add(box);
                }
            }
        }
        if (matchBoxes.Count()>0)
        {
            this.PalletDate = GetPalletDate(matchBoxes);
        }

        context.Pallets.Add(this);
        context.SaveChanges();
        boxController.AddBoxesToPallets(matchBoxes, this);
    }

    public DateOnly GetPalletDate(List<Box> matchBoxes)
    {
        matchBoxes = matchBoxes.OrderBy(b => b.BestBefore).ToList();
        return matchBoxes.LastOrDefault().BestBefore;
    }
}